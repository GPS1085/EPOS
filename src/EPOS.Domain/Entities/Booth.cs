using EPOS.Domain.Common;

namespace EPOS.Domain.Entities;

public class Booth : AuditableEntity
{
    public Guid WardId { get; set; }

    public Ward? Ward { get; set; }

    public int BoothNumber { get; set; }

    public string BoothName { get; set; } = string.Empty;

    public string PollingStation { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
    public ICollection<UserPosting> UserPostings { get; set; }
    = new List<UserPosting>();
}