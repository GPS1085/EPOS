using EPOS.Application.Roles.DTOs;
using EPOS.Application.Roles.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EPOS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleRequest request)
    {
        var result = await _roleService.CreateRoleAsync(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _roleService.GetAllRolesAsync();

        return Ok(result);
    }
}