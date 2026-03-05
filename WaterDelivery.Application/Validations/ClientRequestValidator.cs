using FluentValidation;
using WaterDelivery.Application.DTOs;

namespace WaterDelivery.Application.Validations;

public class ClientRequestValidator : AbstractValidator<ClientRequest>
{
    public ClientRequestValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("UserId é obrigatório e deve ser maior que zero.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("O telefone é obrigatório.")
            .MaximumLength(20).WithMessage("O telefone deve ter no máximo 20 caracteres.");
    }
}