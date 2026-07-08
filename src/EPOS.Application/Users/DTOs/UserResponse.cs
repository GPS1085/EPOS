namespace EPOS.Application.Users.DTOs;

public class UserResponse
{
    public Guid Id { get; set; }

    public string EmployeeCode { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    public string UserType { get; set; } = string.Empty;

    public DateTime? LastLoginOn { get; set; }
}