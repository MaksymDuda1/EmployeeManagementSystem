using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagementSystem.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile.MappingProfile));

        return services;
    }
}