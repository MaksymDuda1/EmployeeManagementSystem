using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmployeeManagementSystem.Domain.Entities;
using Task = EmployeeManagementSystem.Domain.Entities.Task;

namespace EmployeeManagementSystem.Infrastructure.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> entity)
    {
        entity.HasKey(e => e.Id).HasName("PK__TASK__3214EC072A1619DD");

        entity.ToTable("Task");

        entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        entity.Property(e => e.Description)
            .HasMaxLength(2000)
            .IsUnicode(false);
        entity.Property(e => e.Name)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.Status).HasDefaultValue(1);

        entity.HasOne(d => d.Employee).WithMany(p => p.Tasks)
            .HasForeignKey(d => d.EmployeeId)
            .HasConstraintName("FK__TASK__EmployeeId__71D1E811");

        entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
            .HasForeignKey(d => d.ProjectId)
            .HasConstraintName("FK__TASK__ProjectId__70DDC3D8");
    }
}