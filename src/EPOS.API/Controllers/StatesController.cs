using EPOS.Application.States.DTOs;
using EPOS.Application.States.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EPOS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatesController : ControllerBase
{
    private readonly IStateService _service;

    public StatesController(IStateService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStateRequest request)
    {
        var result = await _service.CreateAsync(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var state = await _service.GetByIdAsync(id);

        if (state == null)
            return NotFound();

        return Ok(state);
    }
}