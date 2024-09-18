﻿using EmployeeManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagementSystem.Infrastructure.Configurations;

public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
{
    public void Configure(EntityTypeBuilder<Manager> entity)
    {
        entity.HasKey(e => e.Id).HasName("PK__Manager__3214EC073B7374FE");

        entity.ToTable("Manager");

        entity.HasIndex(e => e.UserId, "UQ__Manager__1788CC4D93AF14AB").IsUnique();

        entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        entity.Property(e => e.Department)
            .HasMaxLength(255)
            .IsUnicode(false);

        entity.HasOne(d => d.User).WithOne(p => p.Manager)
            .HasForeignKey<Manager>(d => d.UserId)
            .HasConstraintName("FK__Manager__UserId__656C112C");
    }
}