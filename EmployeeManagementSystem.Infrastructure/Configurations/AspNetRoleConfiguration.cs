using EmployeeManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagementSystem.Infrastructure.Configurations;

public class AspNetRoleConfiguration : IEntityTypeConfiguration<AspNetRole>
{
    public void Configure(EntityTypeBuilder<AspNetRole> entity)
    {
        entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
            .IsUnique()
            .HasFilter("([NormalizedName] IS NOT NULL)");

        entity.Property(e => e.Id).ValueGeneratedNever();
        entity.Property(e => e.Name).HasMaxLength(256);
        entity.Property(e => e.NormalizedName).HasMaxLength(256);
    }
}