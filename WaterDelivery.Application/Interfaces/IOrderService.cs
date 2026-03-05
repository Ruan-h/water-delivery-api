using WaterDelivery.Application.DTOs;
using WaterDelivery.Domain.Entities;

namespace WaterDelivery.Application.Interfaces;

public interface IOrderService
{
    Task<OrderResponse> CreateAsync(OrderRequest request);
    Task<OrderResponse?> GetByIdAsync(int id);
    Task<IEnumerable<OrderResponse>> GetOrdersAsync();
    Task<IEnumerable<OrderResponse>> GetOrdersByClientIdAsync(int clientId);
    Task<OrderResponse> UpdateStatusAsync(int id, OrderStatus newStatus);
}