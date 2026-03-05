using FluentValidation;
using WaterDelivery.Application.DTOs;
using WaterDelivery.Application.Interfaces;
using WaterDelivery.Domain.Entities;
using WaterDelivery.Domain.Interfaces;

namespace WaterDelivery.Application.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _repository;
    private readonly IValidator<ItemRequest> _validator; 

    public ItemService(IItemRepository repository, IValidator<ItemRequest> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<ItemResponse> AddAsync(ItemRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var Item = new Item(
            request.Name, 
            request.Description, 
            request.Price, 
            request.Stock, 
            request.ImageUrl);

        
        var savedItem = await _repository.CreateAsync(Item);
   
        return new ItemResponse(
            savedItem.Id, savedItem.Name, savedItem.Description,
            savedItem.Price, savedItem.Stock, savedItem.ImageUrl);
    }

    public async Task<ItemResponse?> GetByIdAsync(int id)
    {
        var Item = await _repository.GetByIdAsync(id);
        
        if (Item == null) return null;

        return new ItemResponse(
            Item.Id, Item.Name, Item.Description, 
            Item.Price, Item.Stock, Item.ImageUrl);
    }

    public async Task<IEnumerable<ItemResponse>> GetItemsAsync()
    {
        var Items = await _repository.GetItemsAsync();
        
        return Items.Select(p => new ItemResponse(
            p.Id, p.Name, p.Description, p.Price, p.Stock, p.ImageUrl));
    }
}