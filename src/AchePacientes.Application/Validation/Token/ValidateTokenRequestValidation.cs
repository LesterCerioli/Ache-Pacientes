using AchePacientes.Application.Handlers.TokenUseCase;
using FluentValidation;

namespace AchePacientes.Application.Validation.Token
{
    public class ValidateTokenRequestValidation : AbstractValidator<ValidateTokenRequest>
    {
        public ValidateTokenRequestValidation()
        {
            RuleFor(a => a.RequestId)
            .NotEmpty()
            .WithMessage("Request Id não é válido");

            RuleFor(a => a.Token)
            .NotEmpty()
            .Length(4)
            .WithMessage("Token não é válido");
        }
    }
}
