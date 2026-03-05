using FluentValidation;
using WaterDelivery.Application.DTOs;

namespace WaterDelivery.Application.Validations;

public class EstablishmentRequestValidator : AbstractValidator<EstablishmentRequest>
{
    public EstablishmentRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres.")
            .MaximumLength(100).WithMessage("O nome excedeu o limite de 100 caracteres.");
    }
}