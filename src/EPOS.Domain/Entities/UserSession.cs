using EPOS.Domain.Common;

namespace EPOS.Domain.Entities;

public class UserSession : AuditableEntity
{
    public Guid UserId { get; set; }

    public User? User { get; set; }

    public string AccessToken { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public DateTime LoginTime { get; set; }

    public DateTime ExpiryTime { get; set; }

    public bool IsActive { get; set; } = true;

    public string IpAddress { get; set; } = string.Empty;

    public string UserAgent { get; set; } = string.Empty;
}