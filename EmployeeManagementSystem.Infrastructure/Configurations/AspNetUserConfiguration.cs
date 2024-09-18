﻿using EmployeeManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagementSystem.Infrastructure.Configurations;

public class AspNetUserConfiguration : IEntityTypeConfiguration<AspNetUser>
{
    public void Configure(EntityTypeBuilder<AspNetUser> entity)
    {
        entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

        entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
            .IsUnique()
            .HasFilter("([NormalizedUserName] IS NOT NULL)");

        entity.Property(e => e.Id).ValueGeneratedNever();
        entity.Property(e => e.Email).HasMaxLength(256);
        entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
        entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
        entity.Property(e => e.UserName).HasMaxLength(256);

        entity.HasMany(d => d.Roles).WithMany(p => p.Users)
            .UsingEntity<Dictionary<string, object>>(
                "AspNetUserRole",
                r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                j =>
                {
                    j.HasKey("UserId", "RoleId");
                    j.ToTable("AspNetUserRoles");
                    j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                });
    }
}