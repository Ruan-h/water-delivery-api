using WaterDelivery.Application.DTOs;

namespace WaterDelivery.Application.Interfaces;

public interface IItemService
{
    Task<IEnumerable<ItemResponse>> GetItemsAsync();
    Task<ItemResponse?> GetByIdAsync(int id);
    Task<ItemResponse> AddAsync(ItemRequest request);
}