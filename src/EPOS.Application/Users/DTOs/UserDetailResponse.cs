namespace EPOS.Application.Users.DTOs;

public class UserDetailResponse
{
    public Guid Id { get; set; }

    public string EmployeeCode { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string MiddleName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;

    public Guid OrganizationId { get; set; }

    public bool IsActive { get; set; }

    public string? ProfilePhotoUrl { get; set; }
}