using EmployeeManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagementSystem.Infrastructure.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> entity)
    {
        entity.HasKey(e => e.Id).HasName("PK__Project__3214EC078F8CF647");

        entity.ToTable("Project");

        entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        entity.Property(e => e.Customer)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.Name)
            .HasMaxLength(255)
            .IsUnicode(false);

        entity.HasMany(d => d.Managers).WithMany(p => p.Projects)
            .UsingEntity<Dictionary<string, object>>(
                "ProjectManager",
                r => r.HasOne<Manager>().WithMany()
                    .HasForeignKey("ManagerId")
                    .HasConstraintName("FK__ProjectMa__Manag__6C190EBB"),
                l => l.HasOne<Project>().WithMany()
                    .HasForeignKey("ProjectId")
                    .HasConstraintName("FK__ProjectMa__Proje__6B24EA82"),
                j =>
                {
                    j.HasKey("ProjectId", "ManagerId").HasName("PK__ProjectM__75A0945E446E4E43");
                    j.ToTable("ProjectManager");
                    j.HasIndex(new[] { "ManagerId" }, "IX_ProjectManager_ManagerId");
                });
    }
}