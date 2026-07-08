namespace EPOS.Application.Permissions.DTOs;

public class CreatePermissionRequest
{
    public string Module { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}