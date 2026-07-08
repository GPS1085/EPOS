namespace EPOS.Application.Roles.DTOs;

public class CreateRoleRequest
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsSystemRole { get; set; }

    public bool IsActive { get; set; } = true;
}