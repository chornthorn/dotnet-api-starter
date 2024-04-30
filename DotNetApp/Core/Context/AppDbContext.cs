using System;
using System.Collections.Generic;
using DotNetApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetApp.Core.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PrismaMigration> PrismaMigrations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<Simple> Simples { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("Permission")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .IsRequired()
                .HasMaxLength(191)
                .HasColumnName("action");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("deletedAt");
            entity.Property(e => e.Description)
                .HasMaxLength(191)
                .HasColumnName("description");
            entity.Property(e => e.Module)
                .IsRequired()
                .HasMaxLength(191)
                .HasColumnName("module");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<PrismaMigration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("_prisma_migrations")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.AppliedStepsCount).HasColumnName("applied_steps_count");
            entity.Property(e => e.Checksum)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnName("checksum");
            entity.Property(e => e.FinishedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("finished_at");
            entity.Property(e => e.Logs)
                .HasColumnType("text")
                .HasColumnName("logs");
            entity.Property(e => e.MigrationName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("migration_name");
            entity.Property(e => e.RolledBackAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("rolled_back_at");
            entity.Property(e => e.StartedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("started_at");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("Role")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Name, "Role_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("deletedAt");
            entity.Property(e => e.Description)
                .HasMaxLength(191)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("RolePermission")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.PermissionId, "RolePermission_permissionId_fkey");

            entity.HasIndex(e => e.RoleId, "RolePermission_roleId_fkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PermissionId).HasColumnName("permissionId");
            entity.Property(e => e.RoleId).HasColumnName("roleId");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RolePermission_permissionId_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RolePermission_roleId_fkey");
        });

        modelBuilder.Entity<Simple>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("Simple")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("deletedAt");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Email, "Users_email_key").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(191)
                .HasColumnName("id");
            entity.Property(e => e.Avatar)
                .HasMaxLength(191)
                .HasColumnName("avatar");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("deletedAt");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(191)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(191)
                .HasColumnName("password");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("UserRole")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.RoleId, "UserRole_roleId_fkey");

            entity.HasIndex(e => e.UserId, "UserRole_userId_fkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("deletedAt");
            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(191)
                .HasColumnName("userId");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserRole_roleId_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserRole_userId_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
