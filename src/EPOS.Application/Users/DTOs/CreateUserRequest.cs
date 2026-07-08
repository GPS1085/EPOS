namespace EPOS.Application.Users.DTOs;

public class CreateUserRequest
{
    public Guid OrganizationId { get; set; }

    public Guid RoleId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string MiddleName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string ProfilePhotoUrl { get; set; } = string.Empty;
}