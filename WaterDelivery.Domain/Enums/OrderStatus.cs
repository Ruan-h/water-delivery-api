namespace WaterDelivery.Domain.Entities;

public enum OrderStatus
{
    Pending = 1,
    Confirmed = 2,
    OutForDelivery = 3,
    Delivered = 4,
    Canceled = 5
}