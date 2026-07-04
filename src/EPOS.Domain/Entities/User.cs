using EPOS.Domain.Common;
using EPOS.Domain.Enums;

namespace EPOS.Domain.Entities;

public class User : AuditableEntity
{
    public Guid OrganizationId { get; set; }

    public Organization? Organization { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string FullName => $"{FirstName} {LastName}".Trim();

    public string Email { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public UserType UserType { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsLocked { get; set; }

    public DateTime? LastLoginOn { get; set; }
}