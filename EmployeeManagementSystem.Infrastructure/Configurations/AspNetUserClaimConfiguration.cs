using EmployeeManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagementSystem.Infrastructure.Configurations;

public class AspNetUserClaimConfiguration : IEntityTypeConfiguration<AspNetUserClaim>
{
    public void Configure(EntityTypeBuilder<AspNetUserClaim> entity)
    {
        entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

        entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
    }
}