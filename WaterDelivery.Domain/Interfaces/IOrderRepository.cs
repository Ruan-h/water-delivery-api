using WaterDelivery.Domain.Entities;

namespace WaterDelivery.Domain.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(int id);
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<IEnumerable<Order>> GetOrdersByClientIdAsync(int clientId);
    Task<Order> CreateAsync(Order order);
    Task<Order> UpdateAsync(Order order);
}