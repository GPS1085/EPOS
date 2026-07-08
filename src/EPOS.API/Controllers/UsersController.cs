using EPOS.Application.Users.DTOs;
using EPOS.Application.Users.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EPOS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest request)
    {
        var result = await _userService.CreateUserAsync(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateUserRequest request)
    {
        var updated = await _userService.UpdateUserAsync(id, request);

        if (!updated)
            return NotFound();

        return Ok(new
        {
            Success = true,
            Message = "User updated successfully."
        });
    }

    [HttpPatch("{id:guid}/activate")]
    public async Task<IActionResult> Activate(Guid id)
    {
        var success = await _userService.ActivateUserAsync(id);

        if (!success)
            return NotFound();

        return Ok(new
        {
            Success = true,
            Message = "User activated successfully."
        });
    }

    [HttpPatch("{id:guid}/deactivate")]
    public async Task<IActionResult> Deactivate(Guid id)
    {
        var success = await _userService.DeactivateUserAsync(id);

        if (!success)
            return NotFound();

        return Ok(new
        {
            Success = true,
            Message = "User deactivated successfully."
        });
    }
}