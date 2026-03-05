using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WaterDelivery.Application.DTOs;
using WaterDelivery.Application.Interfaces;

namespace WaterDelivery.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("employee")]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateUserRequest request)
    {
        var response = await _userService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _userService.GetByIdAsync(id);
        if (response == null) return NotFound();
        return Ok(response);
    }
}