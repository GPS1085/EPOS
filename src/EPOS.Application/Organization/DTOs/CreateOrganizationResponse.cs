namespace EPOS.Application.Organization.DTOs;

public class CreateOrganizationResponse
{
    public bool Success { get; set; }

    public Guid OrganizationId { get; set; }

    public string Message { get; set; } = string.Empty;
}