namespace EPOS.Application.States.DTOs;

public class CreateStateRequest
{
    public Guid OrganizationId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;
}