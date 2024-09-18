using EmployeeManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagementSystem.Infrastructure.Configurations;

public class AspNetRoleClaimConfiguration : IEntityTypeConfiguration<AspNetRoleClaim>
{
    public void Configure(EntityTypeBuilder<AspNetRoleClaim> entity)
    {
        entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

        entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
    }
}