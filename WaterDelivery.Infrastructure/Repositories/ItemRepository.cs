using Microsoft.EntityFrameworkCore;
using WaterDelivery.Domain.Entities;
using WaterDelivery.Domain.Interfaces;
using WaterDelivery.Infrastructure.Context;

namespace WaterDelivery.Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly ApplicationDbContext _context;

    public ItemRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Item> CreateAsync(Item Item)
    {    
        await _context.Items.AddAsync(Item);
        
        await _context.SaveChangesAsync();
        return Item;
    }

    public async Task<Item?> GetByIdAsync(int id)
    {
        return await _context.Items.FindAsync(id);
    }

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
        return await _context.Items.OrderBy(p => p.Name).ToListAsync();
    }

    public async Task<Item> RemoveAsync(Item Item)
    {
        _context.Items.Remove(Item);
        await _context.SaveChangesAsync();
        return Item;
    }

    public async Task<Item> UpdateAsync(Item Item)
    {
        _context.Items.Update(Item);
        await _context.SaveChangesAsync();
        return Item;
    }
}