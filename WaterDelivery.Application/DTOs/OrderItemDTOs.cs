using WaterDelivery.Domain.Entities;

namespace WaterDelivery.Application.DTOs;


public record OrderItemRequest(
    int ItemId,
    int Quantity
);

public record OrderItemResponse(
    int Id,
    int ItemId,
    int Quantity,
    decimal UnitPrice
);