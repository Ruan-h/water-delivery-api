using FluentValidation;
using WaterDelivery.Application.DTOs;

namespace WaterDelivery.Application.Validations;

public class ItemRequestValidator : AbstractValidator<ItemRequest>
{
    public ItemRequestValidator()
    {
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome do produto é obrigatório.")
            .MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres.")
            .MaximumLength(100).WithMessage("O nome não pode passar de 100 caracteres.");
        
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A descrição é obrigatória.");

        
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");

        
        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("O estoque não pode ser negativo.");
            
        
        RuleFor(x => x.ImageUrl)
            .MaximumLength(250).WithMessage("A URL da imagem é muito longa.");
    }
}