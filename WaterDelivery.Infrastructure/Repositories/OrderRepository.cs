using Microsoft.EntityFrameworkCore;
using WaterDelivery.Domain.Entities;
using WaterDelivery.Domain.Interfaces;
using WaterDelivery.Infrastructure.Context;

namespace WaterDelivery.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Order> CreateAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _context.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        return await _context.Orders
            .Include(o => o.Items)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersByClientIdAsync(int clientId)
    {
        return await _context.Orders
            .Include(o => o.Items)
            .Where(o => o.ClientId == clientId)
            .ToListAsync();
    }

    public async Task<Order> UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
        return order;
    }
}