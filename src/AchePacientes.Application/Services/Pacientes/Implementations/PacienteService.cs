using AchePacientes.Application.Handlers.Paciente;
using AchePacientes.Application.Services.Pacientes.Contratos;
using AchePacientes.Application.ViewModels.Pacientes;
using AchePacientes.Domain.Pacientes.Interfaces;
using AchePacientes.Domain.Pacientes.ValueObjects;
using AutoMapper;
using NetDevPack.Mediator;

namespace AchePacientes.Application.Services.Pacientes.Implementations
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        

        public PacienteService(
            IPacienteRepository pacienteRepository,
            IMediatorHandler mediator,
            IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
            _mediator = mediator;
            
        }
             

        public async Task<PacienteViewModel> GetCPF(Cpf cpfNumero)
        {
            return _mapper.Map<PacienteViewModel>(await _pacienteRepository.GetByCPF(cpfNumero));
        }
               
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Save(CreatePacienteCommand commandCreate)
        {
            await _pacienteRepository.Add(commandCreate.GetEntity());
        }
    }
}
