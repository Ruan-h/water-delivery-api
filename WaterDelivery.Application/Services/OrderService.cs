using FluentValidation;
using WaterDelivery.Application.DTOs;
using WaterDelivery.Application.Interfaces;
using WaterDelivery.Domain.Entities;
using WaterDelivery.Domain.Interfaces;

namespace WaterDelivery.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IItemRepository _itemRepository;
    private readonly IValidator<OrderRequest> _validator;

    public OrderService(IOrderRepository orderRepository, IItemRepository itemRepository, IValidator<OrderRequest> validator)
    {
        _orderRepository = orderRepository;
        _itemRepository = itemRepository;
        _validator = validator;
    }

    public async Task<OrderResponse> CreateAsync(OrderRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        var order = new Order(request.ClientId, request.ScheduledDate, request.DeliveryAddress);

        foreach (var itemRequest in request.Items)
        {
            var item = await _itemRepository.GetByIdAsync(itemRequest.ItemId);
            if (item == null) throw new ArgumentException($"Item com ID {itemRequest.ItemId} não encontrado.");

            order.AddItem(item.Id, itemRequest.Quantity, item.Price);
        }

        var savedOrder = await _orderRepository.CreateAsync(order);

        return MapToResponse(savedOrder);
    }

    public async Task<OrderResponse?> GetByIdAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order == null) return null;

        return MapToResponse(order);
    }

    public async Task<IEnumerable<OrderResponse>> GetOrdersAsync()
    {
        var orders = await _orderRepository.GetOrdersAsync();
        return orders.Select(MapToResponse);
    }

    public async Task<IEnumerable<OrderResponse>> GetOrdersByClientIdAsync(int clientId)
    {
        var orders = await _orderRepository.GetOrdersByClientIdAsync(clientId);
        return orders.Select(MapToResponse);
    }

    public async Task<OrderResponse> UpdateStatusAsync(int id, OrderStatus newStatus)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order == null) throw new ArgumentException("Pedido não encontrado.");

        order.UpdateStatus(newStatus);
        var updatedOrder = await _orderRepository.UpdateAsync(order);

        return MapToResponse(updatedOrder);
    }

    private OrderResponse MapToResponse(Order order)
    {
        var itemsResponse = order.Items.Select(i => 
            new OrderItemResponse(i.Id, i.ItemId, i.Quantity, i.UnitPrice)).ToList();

        return new OrderResponse(
            order.Id,
            order.ClientId,
            order.TotalAmount,
            order.ScheduledDate,
            order.DeliveryAddress,
            order.Status,
            order.CreatedAt,
            itemsResponse
        );
    }
}