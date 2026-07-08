namespace EPOS.Application.Roles.DTOs;

public class RoleResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsSystemRole { get; set; }

    public bool IsActive { get; set; }
}