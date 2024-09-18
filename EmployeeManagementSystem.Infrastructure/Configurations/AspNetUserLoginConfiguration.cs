using EmployeeManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagementSystem.Infrastructure.Configurations;

public class AspNetUserLoginConfiguration : IEntityTypeConfiguration<AspNetUserLogin>
{
    public void Configure(EntityTypeBuilder<AspNetUserLogin> entity)
    {
        entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

        entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

        entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
    }
}