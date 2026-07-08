namespace EPOS.Application.Organization.DTOs;

public class CreateOrganizationRequest
{
    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;
}