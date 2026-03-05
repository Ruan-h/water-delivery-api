using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WaterDelivery.Application.DTOs;
using WaterDelivery.Application.Interfaces;
using WaterDelivery.Domain.Entities;

namespace WaterDelivery.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IClientService _clientService;

    public OrdersController(IOrderService orderService, IClientService clientService)
    {
        _orderService = orderService;
        _clientService = clientService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderRequest request)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value 
                           ?? User.FindFirst("id")?.Value 
                           ?? User.FindFirst("sub")?.Value;

        if (!int.TryParse(userIdString, out int userId))
            return Unauthorized();

        var client = await _clientService.GetByUserIdAsync(userId);
        if (client == null)
            return BadRequest();

        var safeRequest = request with { ClientId = client.Id };

        var response = await _orderService.CreateAsync(safeRequest);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _orderService.GetByIdAsync(id);
        if (response == null) return NotFound();
        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _orderService.GetOrdersAsync();
        return Ok(response);
    }

    [HttpGet("client/{clientId}")]
    public async Task<IActionResult> GetByClient(int clientId)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value 
                           ?? User.FindFirst("id")?.Value 
                           ?? User.FindFirst("sub")?.Value;

        if (!int.TryParse(userIdString, out int userId))
            return Unauthorized();

        var client = await _clientService.GetByUserIdAsync(userId);
        if (client == null)
            return BadRequest();

        var response = await _orderService.GetOrdersByClientIdAsync(client.Id);
        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateStatusRequest request)
    {
        var response = await _orderService.UpdateStatusAsync(id, request.Status);
        return Ok(response);
    }
}