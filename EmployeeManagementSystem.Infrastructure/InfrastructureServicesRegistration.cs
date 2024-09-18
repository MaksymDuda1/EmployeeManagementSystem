using EmployeeManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagementSystem.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<EmployeeManagementSystemContext>(opt =>
        
            opt.UseSqlServer(configuration.GetConnectionString("EmployeeManagementSystemContext")));
        
        return services;
    }
}