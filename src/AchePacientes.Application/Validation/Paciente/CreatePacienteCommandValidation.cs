using AchePacientes.Application.Handlers.Paciente;
using AchePacientes.Domain.Pacientes.ValueObjects;
using FluentValidation;

namespace AchePacientes.Application.Validation.Paciente
{
    public  class CreatePacienteCommandValidation : AbstractValidator<CreatePacienteCommand>
    {
        public CreatePacienteCommandValidation()
        {
            RuleFor(a => a.Cpf).Custom((numDoc, context) => {
                try
                {
                    new Cpf(numDoc);
                }
                catch (Exception ex)
                {
                    context.AddFailure(ex.Message);
                }
            });

            RuleFor(a => a.Name)
          .NotEmpty()
          .MaximumLength(40)
          .WithMessage("O nome está incorreto.");

            RuleFor(a => a.PhoneRegion)
          .NotEmpty()
          .MinimumLength(1)
          .WithMessage("O ddi deve ser preenchido");

            RuleFor(a => a.PhoneNumber)
          .NotEmpty()
          .MinimumLength(10)
          .WithMessage("O telefone deve ser preenchido");

            RuleFor(a => a.AcceptTerms)
         .NotEmpty()
         .WithMessage("Os termos de uso devem ser aceitos.");

            RuleFor(a => a.AcceptCommunication)
         .NotEmpty()
         .WithMessage("O aceite de comunicações deve ser selecionado.");

            RuleFor(a => a.DateOfBirth)
                .NotEmpty()
          .WithMessage("Data de nascimento deve ser preenchido");

            RuleFor(a => a.AcceptTerms).Custom(async (accept, context) => {
                if (!accept.HasValue || !accept.Value)
                {
                    context.AddFailure("Os termos devem ser aceitos.");
                }
            });
        }
    }
}
