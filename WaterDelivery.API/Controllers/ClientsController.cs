using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WaterDelivery.Application.Interfaces;

namespace WaterDelivery.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _clientService.GetByIdAsync(id);
        if (response == null) return NotFound();
        return Ok(response);
    }

    [Authorize(Roles = "Admin,Client")]
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(int userId)
    {
        var response = await _clientService.GetByUserIdAsync(userId);
        if (response == null) return NotFound();
        return Ok(response);
    }
}