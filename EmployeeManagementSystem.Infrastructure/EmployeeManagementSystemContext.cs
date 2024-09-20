using EmployeeManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = EmployeeManagementSystem.Domain.Entities.Task;

namespace EmployeeManagementSystem.Infrastructure;

public class EmployeeManagementSystemContext(DbContextOptions<EmployeeManagementSystemContext> options)
    : IdentityDbContext<User, Role, Guid> (options)
{
    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }
    
    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeManagementSystemContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}