using AchePacientes.Application.Handlers.Paciente;
using AchePacientes.Domain.Pacientes.ValueObjects;
using FluentValidation;

namespace AchePacientes.Application.Validation.Paciente
{
    public  class CheckPacienteExistsByCpfRequestValidation :AbstractValidator<CheckPacienteExistsByCpfRequest>
    {
        public CheckPacienteExistsByCpfRequestValidation()
        {
            RuleFor(a => a.Cpf).Custom((numDoc, context)=>{
                try
                {
                    new Cpf(numDoc);
                }
                catch (Exception ex)
                {
                    context.AddFailure(ex.Message);
                }
            });               
            
                
        }
    }
}
