namespace EPOS.Application.Users.DTOs;

public class UpdateUserRequest
{
    public string FirstName { get; set; } = string.Empty;

    public string MiddleName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;

    public string? ProfilePhotoUrl { get; set; }

    public bool IsActive { get; set; }
}