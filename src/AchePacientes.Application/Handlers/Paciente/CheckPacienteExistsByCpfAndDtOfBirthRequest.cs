using MediatR;

namespace AchePacientes.Application.Handlers.Paciente
{
    public  class CheckPacienteExistsByCpfAndDtOfBirthRequest : IRequest<CheckPacienteExistsByCpfAndDtOfBirthResponse>
    {
        public Guid Id { get; private set; }
        public string? Cpf { get; set; }
        public DateTime? DtOfBirth { get; set; }
        public CheckPacienteExistsByCpfAndDtOfBirthRequest(string? cpf, DateTime? dtOfBirth)
        {
            Id = Guid.NewGuid();
            Cpf = cpf;
            DtOfBirth = dtOfBirth;
            
        }
    }
}
