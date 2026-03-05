using WaterDelivery.Domain.Entities;

namespace WaterDelivery.Domain.Interfaces;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetItemsAsync();
    

    Task<Item?> GetByIdAsync(int id); 


    Task<Item> CreateAsync(Item Item);
    Task<Item> UpdateAsync(Item Item);
    Task<Item> RemoveAsync(Item Item);
}