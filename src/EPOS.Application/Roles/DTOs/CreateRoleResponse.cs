namespace EPOS.Application.Roles.DTOs;

public class CreateRoleResponse
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public Guid RoleId { get; set; }
}