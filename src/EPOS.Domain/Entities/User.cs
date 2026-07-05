using EPOS.Domain.Common;
using EPOS.Domain.Enums;

namespace EPOS.Domain.Entities;

public class User : AuditableEntity
{
    public Guid OrganizationId { get; set; }

    public Organization? Organization { get; set; }

    // ===== Identity =====

    public string EmployeeCode { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string MiddleName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string FullName =>
        $"{FirstName} {MiddleName} {LastName}".Replace("  ", " ").Trim();

    public string Email { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;

    public string? ProfilePhotoUrl { get; set; }

    // ===== Authentication =====

    public string PasswordHash { get; set; } = string.Empty;

    public bool IsFirstLogin { get; set; } = true;

    public DateTime? PasswordChangedOn { get; set; }

    public DateTime? LastLoginOn { get; set; }

    public DateTime? LastActivityOn { get; set; }

    // ===== User Status =====

    public UserType UserType { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsLocked { get; set; }

    // ===== Political Posting =====

    public ICollection<UserPosting> Postings { get; set; }
        = new List<UserPosting>();
}