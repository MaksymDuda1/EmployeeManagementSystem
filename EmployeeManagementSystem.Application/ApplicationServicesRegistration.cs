using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagementSystem.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile.MappingProfile));
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAuthorizationService, AuthorizationService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IManagerService, ManagerService>();
        services.AddScoped<IAdminService, AdminService>();
        return services;
    }
}