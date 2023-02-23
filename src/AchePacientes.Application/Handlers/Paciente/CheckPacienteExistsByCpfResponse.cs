using AchePacientes.Application.Core;
using FluentValidation.Results;

namespace AchePacientes.Application.Handlers.Paciente
{
    public class CheckPacienteExistsByCpfResponse : Response
    {
        public Guid RequestId { get; private set; }
        public bool Exists { get; set; }

        public CheckPacienteExistsByCpfResponse(Guid requestId, bool exists, ValidationResult result)
        {
            RequestId = requestId;
            Exists = exists;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }
        public CheckPacienteExistsByCpfResponse(Guid requestId, string falhaValidacao)
        {
            RequestId = requestId;
            Exists = false;
            this.AddError(falhaValidacao);
        }
        
    }
}
