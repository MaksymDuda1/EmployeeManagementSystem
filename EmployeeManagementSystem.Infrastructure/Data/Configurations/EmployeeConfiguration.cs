using EmployeeManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagementSystem.Infrastructure.Data.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> entity)
    {
        entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC0772CA2E64");

        entity.ToTable("Employee");

        entity.HasIndex(e => e.UserId, "UQ__Employee__1788CC4D9DB5F725").IsUnique();

        entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        entity.Property(e => e.Position)
            .HasMaxLength(255)
            .IsUnicode(false);
        
        entity.HasMany(d => d.Projects).WithMany(p => p.Employees)
            .UsingEntity<Dictionary<string, object>>(
                "EmployeeProject",
                r => r.HasOne<Project>().WithMany()
                    .HasForeignKey("ProjectId")
                    .HasConstraintName("FK_EmployeeProject_Project_ProjectsId"),
                l => l.HasOne<Employee>().WithMany()
                    .HasForeignKey("EmployeeId")
                    .HasConstraintName("FK_EmployeeProject_Employee_EmployeesId"),
                j =>
                {
                    j.HasKey("EmployeeId", "ProjectId");
                    j.ToTable("EmployeeProject");
                    j.HasIndex(new[] { "ProjectId" }, "IX_EmployeeProject_ProjectsId");
                });
    }
}

