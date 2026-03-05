using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WaterDelivery.Application.DTOs;
using WaterDelivery.Application.Interfaces;

namespace WaterDelivery.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ItemsController : ControllerBase
{
    private readonly IItemService _ItemService;

    public ItemsController(IItemService ItemService)
    {
        _ItemService = ItemService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ItemRequest request)
    {
        var response = await _ItemService.AddAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _ItemService.GetByIdAsync(id);
        
        if (response == null) 
            return NotFound(new { message = "Produto não encontrado." });

        return Ok(response); 
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _ItemService.GetItemsAsync();
        return Ok(response);
    }
}