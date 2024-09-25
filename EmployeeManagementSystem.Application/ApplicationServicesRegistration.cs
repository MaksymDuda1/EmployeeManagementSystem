using System.Reflection;
using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Application.Services;
using EmployeeManagementSystem.Application.Validations.EmployeeValidators;
using EmployeeManagementSystem.Application.Validations.ManagerValidators;
using EmployeeManagementSystem.Application.Validations.ProjectValidators;
using EmployeeManagementSystem.Application.Validations.TaskValidators;
using EmployeeManagementSystem.Domain.Dtos;
using FluentValidation;
using FluentValidation.AspNetCore;
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
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}