using AchePacientes.Domain.Pacientes.ValueObjects;
using MediatR;
using PacienteEntity = AchePacientes.Domain.Pacientes.Models.Paciente;

namespace AchePacientes.Application.Handlers.Paciente
{
    public class CreatePacienteCommand : IRequest<CreatePacienteResponse>
    {
        public Guid Id { get; private set; }
        public string? Cpf { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PhoneRegion { get; set; }

        public bool? AcceptCommunication { get; set; }
        public bool? AcceptTerms { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public CreatePacienteCommand()
        {
            Id= Guid.NewGuid();
        }

        public PacienteEntity GetEntity()
        {
            return new PacienteEntity(
                new Nome(this.Name),
                this.PhoneNumber,
                new Cpf(this.Cpf),
                this.PhoneRegion,
                this.AcceptCommunication.Value,
                this.AcceptTerms.Value,
                this.DateOfBirth.Value
                );
        }
    }
}
