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
}