using EPOS.Application.Organization.DTOs;
using EPOS.Application.Organization.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EPOS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrganizationsController : ControllerBase
{
    private readonly IOrganizationService _organizationService;

    public OrganizationsController(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrganizationRequest request)
    {
        var result = await _organizationService.CreateAsync(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _organizationService.GetAllAsync();

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _organizationService.GetByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}