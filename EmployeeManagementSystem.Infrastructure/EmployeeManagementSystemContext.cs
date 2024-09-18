using EmployeeManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Task = EmployeeManagementSystem.Domain.Entities.Task;

namespace EmployeeManagementSystem.Infrastructure;

public partial class EmployeeManagementSystemContext : DbContext
{
    public EmployeeManagementSystemContext()
    {
    }

    public EmployeeManagementSystemContext(DbContextOptions<EmployeeManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

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