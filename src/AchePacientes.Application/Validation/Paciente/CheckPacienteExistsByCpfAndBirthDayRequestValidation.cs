using AchePacientes.Application.Handlers.Paciente;
using AchePacientes.Domain.Pacientes.ValueObjects;
using FluentValidation;

namespace AchePacientes.Application.Validation.Paciente
{
    public class CheckPacienteExistsByCpfAndBirthDayRequestValidation :AbstractValidator<CheckPacienteExistsByCpfAndDtOfBirthRequest>
    {

        public CheckPacienteExistsByCpfAndBirthDayRequestValidation()
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

            RuleFor(a => a.DtOfBirth)
                .NotEmpty()
                .WithMessage("Data de nascimento deve ser preenchido");
        }
    }
}
