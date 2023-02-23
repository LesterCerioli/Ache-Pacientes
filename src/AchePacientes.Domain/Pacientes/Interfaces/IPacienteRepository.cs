using AchePacientes.Domain.Pacientes.Models;
using AchePacientes.Domain.Pacientes.ValueObjects;

namespace AchePacientes.Domain.Pacientes.Interfaces
{
    public interface IPacienteRepository
    {
        Task<Paciente> GetByCPF(Cpf cpf);
        Task<Paciente> GetByCPFAndDataNascimento(Cpf cpf, DateTime nascimento);

        Task Add(Paciente paciente);

        void Update(Paciente paciente);

        void Remove(Paciente paciente);
    }
}
