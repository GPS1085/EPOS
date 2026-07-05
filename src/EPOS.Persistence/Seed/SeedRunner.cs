using EPOS.Persistence.Context;

namespace EPOS.Persistence.Seed;

public static class SeedRunner
{
    public static async Task SeedAsync(EPOSDbContext context)
    {
        await OrganizationSeeder.SeedAsync(context);

        // Next seeders will be added here
        // await GeographySeeder.SeedAsync(context);
        // await DepartmentSeeder.SeedAsync(context);
        // await DesignationSeeder.SeedAsync(context);
        // await RoleSeeder.SeedAsync(context);
        // await PermissionSeeder.SeedAsync(context);
        // await AdminSeeder.SeedAsync(context);
    }
}