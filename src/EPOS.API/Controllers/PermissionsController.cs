using EPOS.Application.Permissions.DTOs;
using EPOS.Application.Permissions.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EPOS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionsController : ControllerBase
{
    private readonly IPermissionService _permissionService;

    public PermissionsController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePermissionRequest request)
    {
        var result = await _permissionService.CreatePermissionAsync(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _permissionService.GetAllPermissionsAsync();

        return Ok(result);
    }
}