using WaterDelivery.Domain.Validation;

namespace WaterDelivery.Domain.Entities;

public sealed class Order
{
    public int Id { get; private set; }
    public int ClientId { get; private set; }
    public decimal TotalAmount { get; private set; }
    public DateTime? ScheduledDate { get; private set; }
    public string DeliveryAddress { get; private set; }
    public OrderStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();



    public Order(int clientId, DateTime? scheduledDate, string deliveryAddress)
    {
        ValidateDomain(clientId, scheduledDate, deliveryAddress);
        ClientId = clientId;
        ScheduledDate = scheduledDate;
        DeliveryAddress = deliveryAddress;
        Status = OrderStatus.Pending;
        CreatedAt = DateTime.UtcNow;
        TotalAmount = 0;
    }
    public void AddItem(int itemId, int quantity, decimal unitPrice)
    {
        var item = new OrderItem(Id, itemId, quantity, unitPrice);
        _items.Add(item);
        
        TotalAmount += quantity * unitPrice;
    }

    public void UpdateStatus(OrderStatus newStatus)
    {
        Status = newStatus;
    }

    private void ValidateDomain(int clientId, DateTime? scheduledDate, string deliveryAddress)
    {
        DomainExceptionValidation.When(clientId < 0, "Cliente inválido.");
        if (scheduledDate.HasValue)
        {
            DomainExceptionValidation.When(scheduledDate.Value < DateTime.Now,
                "A data agendada não pode ser no passado.");
        }
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(deliveryAddress), "Endereço de entrega é obrigatório.");
    }
}