using WaterDelivery.Domain.Entities;

namespace WaterDelivery.Application.DTOs;


public record OrderRequest(
    int ClientId,
    DateTime? ScheduledDate,
    string DeliveryAddress,
    List<OrderItemRequest> Items
);

public record UpdateStatusRequest(OrderStatus Status);

public record OrderResponse(
    int Id,
    int ClientId,
    decimal TotalAmount,
    DateTime? ScheduledDate,
    string DeliveryAddress,
    OrderStatus Status,
    DateTime CreatedAt,
    List<OrderItemResponse> Items
);