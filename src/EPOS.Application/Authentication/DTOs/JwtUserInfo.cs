namespace EPOS.Application.Authentication.DTOs;

public class JwtUserInfo
{
    public Guid UserId { get; set; }

    public Guid OrganizationId { get; set; }

    public string EmployeeCode { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;

    public string UserType { get; set; } = string.Empty;

    public List<string> Roles { get; set; } = new();
}