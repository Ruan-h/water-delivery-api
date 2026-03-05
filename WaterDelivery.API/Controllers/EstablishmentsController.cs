using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WaterDelivery.Application.DTOs;
using WaterDelivery.Application.Interfaces;

namespace WaterDelivery.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EstablishmentsController : ControllerBase
{
    private readonly IEstablishmentService _establishmentService;

    public EstablishmentsController(IEstablishmentService establishmentService)
    {
        _establishmentService = establishmentService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _establishmentService.GetAsync();
        if (response == null) return NotFound();
        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("name")]
    public async Task<IActionResult> UpdateName([FromBody] EstablishmentRequest request)
    {
        var response = await _establishmentService.UpdateNameAsync(request);
        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("open")]
    public async Task<IActionResult> Open()
    {
        var response = await _establishmentService.OpenAsync();
        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("close")]
    public async Task<IActionResult> Close()
    {
        var response = await _establishmentService.CloseAsync();
        return Ok(response);
    }
}