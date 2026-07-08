using EPOS.Domain.Entities;
using EPOS.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EPOS.Persistence.Seed;

public static class PermissionSeeder
{
    public static async Task SeedAsync(EPOSDbContext context)
    {
        if (await context.Permissions.AnyAsync())
            return;

        var permissions = new List<Permission>
        {
            // ================= USERS =================

            new(){ Module="Users", Name="Create User", Code="USERS.CREATE", Description="Create users"},
            new(){ Module="Users", Name="Update User", Code="USERS.UPDATE", Description="Update users"},
            new(){ Module="Users", Name="Delete User", Code="USERS.DELETE", Description="Delete users"},
            new(){ Module="Users", Name="View User", Code="USERS.VIEW", Description="View users"},
            new(){ Module="Users", Name="Activate User", Code="USERS.ACTIVATE", Description="Activate users"},
            new(){ Module="Users", Name="Deactivate User", Code="USERS.DEACTIVATE", Description="Deactivate users"},

            // ================= ROLES =================

            new(){ Module="Roles", Name="Create Role", Code="ROLES.CREATE", Description="Create roles"},
            new(){ Module="Roles", Name="Update Role", Code="ROLES.UPDATE", Description="Update roles"},
            new(){ Module="Roles", Name="Delete Role", Code="ROLES.DELETE", Description="Delete roles"},
            new(){ Module="Roles", Name="View Role", Code="ROLES.VIEW", Description="View roles"},

            // ================= PERMISSIONS =================

            new(){ Module="Permissions", Name="Create Permission", Code="PERMISSIONS.CREATE", Description="Create permissions"},
            new(){ Module="Permissions", Name="Update Permission", Code="PERMISSIONS.UPDATE", Description="Update permissions"},
            new(){ Module="Permissions", Name="Delete Permission", Code="PERMISSIONS.DELETE", Description="Delete permissions"},
            new(){ Module="Permissions", Name="View Permission", Code="PERMISSIONS.VIEW", Description="View permissions"},

            // ================= ORGANIZATION =================

            new(){ Module="Organization", Name="Create Organization", Code="ORG.CREATE", Description="Create organization"},
            new(){ Module="Organization", Name="Update Organization", Code="ORG.UPDATE", Description="Update organization"},
            new(){ Module="Organization", Name="Delete Organization", Code="ORG.DELETE", Description="Delete organization"},
            new(){ Module="Organization", Name="View Organization", Code="ORG.VIEW", Description="View organization"},

            // ================= DEPARTMENT =================

            new(){ Module="Department", Name="Create Department", Code="DEPT.CREATE", Description="Create department"},
            new(){ Module="Department", Name="Update Department", Code="DEPT.UPDATE", Description="Update department"},
            new(){ Module="Department", Name="Delete Department", Code="DEPT.DELETE", Description="Delete department"},
            new(){ Module="Department", Name="View Department", Code="DEPT.VIEW", Description="View department"},

            // ================= DESIGNATION =================

            new(){ Module="Designation", Name="Create Designation", Code="DESIGNATION.CREATE", Description="Create designation"},
            new(){ Module="Designation", Name="Update Designation", Code="DESIGNATION.UPDATE", Description="Update designation"},
            new(){ Module="Designation", Name="Delete Designation", Code="DESIGNATION.DELETE", Description="Delete designation"},
            new(){ Module="Designation", Name="View Designation", Code="DESIGNATION.VIEW", Description="View designation"},

            // ================= DASHBOARD =================

            new(){ Module="Dashboard", Name="View Dashboard", Code="DASHBOARD.VIEW", Description="View dashboard"},
            new(){ Module="Dashboard", Name="View Reports", Code="REPORTS.VIEW", Description="View reports"}
        };

        await context.Permissions.AddRangeAsync(permissions);

        await context.SaveChangesAsync();
    }
}