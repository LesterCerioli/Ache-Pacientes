using AchePacientes.Application.Core;
using FluentValidation.Results;

namespace AchePacientes.Application.Handlers.Paciente
{
    public class CreatePacienteResponse :Response
    {
        public Guid RequestId { get; private set; }

        public CreatePacienteResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }
        public CreatePacienteResponse(Guid requestId, string falhaValidacao)
        {
            RequestId = requestId;
            this.AddError(falhaValidacao);
        }
    }
}
