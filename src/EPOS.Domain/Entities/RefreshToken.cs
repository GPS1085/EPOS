using EPOS.Domain.Common;

namespace EPOS.Domain.Entities;

public class RefreshToken : AuditableEntity
{
    public Guid UserId { get; set; }

    public User? User { get; set; }

    public string Token { get; set; } = string.Empty;

    public DateTime ExpiryDate { get; set; }

    public bool IsRevoked { get; set; }

    public string? ReplacedByToken { get; set; }

    public string? RevokedReason { get; set; }

    public string CreatedByIp { get; set; } = string.Empty;
}