using EPOS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EPOS.Persistence.Context;

public class EPOSDbContext : DbContext
{
    public EPOSDbContext(DbContextOptions<EPOSDbContext> options)
        : base(options)
    {
    }

    // Foundation
    public DbSet<Organization> Organizations => Set<Organization>();
    public DbSet<SystemSetting> SystemSettings => Set<SystemSetting>();

    // Security
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<LoginHistory> LoginHistories => Set<LoginHistory>();
    public DbSet<UserSession> UserSessions => Set<UserSession>();
    public DbSet<PasswordHistory> PasswordHistories => Set<PasswordHistory>();

    // Political Geography
    public DbSet<State> States => Set<State>();
    public DbSet<District> Districts => Set<District>();
    public DbSet<Constituency> Constituencies => Set<Constituency>();
    public DbSet<Ward> Wards => Set<Ward>();
    public DbSet<Booth> Booths => Set<Booth>();

    // Organization Structure
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Designation> Designations => Set<Designation>();
    public DbSet<UserPosting> UserPostings => Set<UserPosting>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ==========================
        // Organization
        // ==========================

        modelBuilder.Entity<State>()
            .HasOne(s => s.Organization)
            .WithMany()
            .HasForeignKey(s => s.OrganizationId)
            .OnDelete(DeleteBehavior.Restrict);

        // ==========================
        // Political Geography
        // ==========================

        modelBuilder.Entity<District>()
            .HasOne(d => d.State)
            .WithMany()
            .HasForeignKey(d => d.StateId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Constituency>()
            .HasOne(c => c.District)
            .WithMany()
            .HasForeignKey(c => c.DistrictId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Ward>()
            .HasOne(w => w.Constituency)
            .WithMany()
            .HasForeignKey(w => w.ConstituencyId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Booth>()
            .HasOne(b => b.Ward)
            .WithMany()
            .HasForeignKey(b => b.WardId)
            .OnDelete(DeleteBehavior.Restrict);

        // ==========================
        // Department & Designation
        // ==========================

        modelBuilder.Entity<Designation>()
            .HasOne(d => d.Department)
            .WithMany(x => x.Designations)
            .HasForeignKey(d => d.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        // ==========================
        // User Posting
        // ==========================

        modelBuilder.Entity<UserPosting>()
            .HasOne(p => p.User)
            .WithMany(u => u.Postings)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserPosting>()
            .HasOne(p => p.Designation)
            .WithMany(d => d.UserPostings)
            .HasForeignKey(p => p.DesignationId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserPosting>()
            .HasOne(p => p.Department)
            .WithMany()
            .HasForeignKey(p => p.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserPosting>()
            .HasOne(p => p.State)
            .WithMany()
            .HasForeignKey(p => p.StateId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserPosting>()
            .HasOne(p => p.District)
            .WithMany()
            .HasForeignKey(p => p.DistrictId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserPosting>()
            .HasOne(p => p.Constituency)
            .WithMany()
            .HasForeignKey(p => p.ConstituencyId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserPosting>()
            .HasOne(p => p.Ward)
            .WithMany()
            .HasForeignKey(p => p.WardId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserPosting>()
            .HasOne(p => p.Booth)
            .WithMany(b => b.UserPostings)
            .HasForeignKey(p => p.BoothId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}