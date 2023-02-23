using AchePacientes.Application.Handlers.Paciente;
using AchePacientes.Application.ViewModels.Pacientes;
using AchePacientes.Domain.Pacientes.Models;
using AchePacientes.Domain.Pacientes.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchePacientes.Application.Services.Pacientes.Contratos
{
    public interface IPacienteService
    {
        Task<PacienteViewModel> GetCPF(Cpf cpf);

        Task Save(CreatePacienteCommand commandCreate);
    }
}
