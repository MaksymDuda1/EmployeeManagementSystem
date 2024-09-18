using EmployeeManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagementSystem.Infrastructure.Configurations;

public class AspNetUserTokenConfiguration : IEntityTypeConfiguration<AspNetUserToken>
{
    public void Configure(EntityTypeBuilder<AspNetUserToken> entity)
    {
        entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

        entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
    }
}