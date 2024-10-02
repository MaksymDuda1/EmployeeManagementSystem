using EmployeeManagementSystem.API.Hubs;
using EmployeeManagementSystem.API.Middlewares;
using EmployeeManagementSystem.Application;
using EmployeeManagementSystem.Infrastructure;
using EmployeeManagementSystem.Infrastructure.Data;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace EmployeeManagementSystem.API;

public static class StartupHelperExtensions
{
    public static WebApplication ConfigureService(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSignalR();
        builder.Services.AddControllers();

        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        
        builder.Services.AddFluentValidationAutoValidation();
        Seed.SeedAdmin(builder.Services.BuildServiceProvider());
        
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(corsPolicyBuilder =>
            {
                corsPolicyBuilder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
        
        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.MapHub<ActiveAdminsHub>("api/active-admins");

        return app;
    }
}