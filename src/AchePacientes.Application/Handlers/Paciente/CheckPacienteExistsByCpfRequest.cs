using MediatR;

namespace AchePacientes.Application.Handlers.Paciente
{
    public class CheckPacienteExistsByCpfRequest : IRequest<CheckPacienteExistsByCpfResponse>
    {
        public Guid Id { get; private set; }   
        public string? Cpf { get; set; }

        public CheckPacienteExistsByCpfRequest(string cpf)
        {
            Id = Guid.NewGuid();
            Cpf = cpf;
        }
    }
}
