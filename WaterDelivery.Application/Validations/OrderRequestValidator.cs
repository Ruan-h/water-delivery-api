using FluentValidation;
using WaterDelivery.Application.DTOs;

namespace WaterDelivery.Application.Validations;

public class OrderRequestValidator : AbstractValidator<OrderRequest>
{
    public OrderRequestValidator()
    {
        RuleFor(x => x.ClientId)
            .GreaterThan(0).WithMessage("Cliente inválido.");

        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("O pedido deve conter pelo menos um item.");

        RuleFor(x => x.DeliveryAddress)
            .NotEmpty().WithMessage("O endereço de entrega é obrigatório.")
            .MaximumLength(255).WithMessage("O endereço de entrega deve ter no máximo 255 caracteres.");

        RuleForEach(x => x.Items).SetValidator(new OrderItemRequestValidator());
    }
}

public class OrderItemRequestValidator : AbstractValidator<OrderItemRequest>
{
    public OrderItemRequestValidator()
    {
        RuleFor(x => x.ItemId)
            .GreaterThan(0).WithMessage("Item inválido.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.");
    }
}