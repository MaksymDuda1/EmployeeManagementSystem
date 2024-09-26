using EmployeeManagementSystem.API.Middlewares;
using EmployeeManagementSystem.Application;
using EmployeeManagementSystem.Infrastructure;
using EmployeeManagementSystem.Infrastructure.Data;
using FluentValidation.AspNetCore;

namespace EmployeeManagementSystem.API;

public static class StartupHelperExtensions
{
    public static WebApplication ConfigureService(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();

        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);

        builder.Services.AddFluentValidationAutoValidation();
        Seed.SeedAdmin(builder.Services.BuildServiceProvider());
        
        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }
}