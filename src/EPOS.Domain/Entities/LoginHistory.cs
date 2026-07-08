using EPOS.Domain.Common;

namespace EPOS.Domain.Entities;

public class LoginHistory : AuditableEntity
{
    public Guid? UserId { get; set; }

    public User? User { get; set; }

    public string LoginId { get; set; } = string.Empty;

    public DateTime LoginTime { get; set; }

    public bool IsSuccessful { get; set; }

    public string IpAddress { get; set; } = string.Empty;

    public string UserAgent { get; set; } = string.Empty;

    public string FailureReason { get; set; } = string.Empty;
}