using EPOS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EPOS.Persistence.Context;

public class EPOSDbContext : DbContext
{
    public EPOSDbContext(DbContextOptions<EPOSDbContext> options)
        : base(options)
    {
    }

    public DbSet<Organization> Organizations => Set<Organization>();

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();

    public DbSet<Permission> Permissions => Set<Permission>();

    public DbSet<UserRole> UserRoles => Set<UserRole>();

    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
}