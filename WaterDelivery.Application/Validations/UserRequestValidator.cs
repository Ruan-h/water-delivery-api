using FluentValidation;
using WaterDelivery.Application.DTOs;

namespace WaterDelivery.Application.Validations;

public class UserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public UserRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O e-mail é obrigatório.")
            .EmailAddress().WithMessage("E-mail inválido.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");

        RuleFor(x => x.Role)
            .InclusiveBetween(1, 2).WithMessage("Perfil de usuário inválido.");
    }
}