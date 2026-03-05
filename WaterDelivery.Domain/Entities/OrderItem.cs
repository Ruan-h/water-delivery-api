using WaterDelivery.Domain.Validation;

namespace WaterDelivery.Domain.Entities
{
    public class OrderItem
    {
        public int Id {get; private set;}
        public int OrderId {get; private set;}
        public int ItemId {get; private set;}
        public int Quantity {get; private set;}
        public decimal UnitPrice {get; private set;}

        public OrderItem(int orderId, int itemId, int quantity, decimal unitPrice)
        {
            ValidateDomain(orderId,itemId,quantity,unitPrice);
        }
        private void ValidateDomain(int orderId, int itemId, int quantity, decimal unitPrice)
        {
            DomainExceptionValidation.When(orderId < 0, "Pedido inválido.");
            DomainExceptionValidation.When(ItemId < 0, "Produto inválido.");
            DomainExceptionValidation.When(quantity <= 0, "Quantidade não pode ser menor que 1.");
            DomainExceptionValidation.When(unitPrice <= 0, "Preço da unidade não pode ser menor ou igual a 0");

            OrderId = orderId;
            ItemId = itemId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }


    }
}