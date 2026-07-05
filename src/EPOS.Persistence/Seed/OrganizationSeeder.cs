using EPOS.Domain.Entities;
using EPOS.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EPOS.Persistence.Seed;

public static class OrganizationSeeder
{
    public static async Task SeedAsync(EPOSDbContext context)
    {
        if (await context.Organizations.AnyAsync())
            return;

        var organization = new Organization
        {
            Name = "SK Foundation",
            Code = "SKF",
            IsActive = true
        };

        context.Organizations.Add(organization);

        await context.SaveChangesAsync();
    }
}