using AchePacientes.Application.Handlers.TokenUseCase;
using FluentValidation;

namespace AchePacientes.Application.Validation.Token
{
    public class SendTokenRequestValidation : AbstractValidator<SendTokenRequest>
    {
        public SendTokenRequestValidation()
        {
            RuleFor(a => a.Name)
           .NotEmpty()
           .MaximumLength(40)
           .WithMessage("Nome completo deve ser preenchido");

            RuleFor(a => a.PhoneRegion)
          .NotEmpty()
          .Length(1)
          .WithMessage("DDI não é válido");

            RuleFor(a => a.PhoneNumber)
          .NotEmpty()
          .MinimumLength(10)
          .WithMessage("Telefone não é válido");
        }

    }
}
