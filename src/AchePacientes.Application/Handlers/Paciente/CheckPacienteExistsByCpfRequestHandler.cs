using AchePacientes.Application.Validation.Paciente;
using AchePacientes.Domain.Pacientes.Interfaces;
using AchePacientes.Domain.Pacientes.ValueObjects;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace AchePacientes.Application.Handlers.Paciente
{
    public class CheckPacienteExistsByCpfRequestHandler : IRequestHandler<CheckPacienteExistsByCpfRequest, CheckPacienteExistsByCpfResponse>
    {
        private IPacienteRepository _repositorioPaciente;
        private readonly ILogger<CheckPacienteExistsByCpfRequestHandler> _logger;
        public CheckPacienteExistsByCpfRequestHandler(IPacienteRepository repositorioPaciente, ILogger<CheckPacienteExistsByCpfRequestHandler> logger)
        {
            _repositorioPaciente = repositorioPaciente;
            _logger = logger;
        }

        public async Task<CheckPacienteExistsByCpfResponse> Handle(CheckPacienteExistsByCpfRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckPacienteExistsByCpfRequest: {JsonSerializer.Serialize(request)}");
            var validationResult =new CheckPacienteExistsByCpfRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var paciente = await  _repositorioPaciente.GetByCPF(new Cpf(request.Cpf));
                    if (paciente != null)
                        return await Task.FromResult(new CheckPacienteExistsByCpfResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckPacienteExistsByCpfResponse(request.Id, "Não foi possivel Processar solicitação."));
                }
            }

            return await Task.FromResult(new CheckPacienteExistsByCpfResponse(request.Id, false, validationResult));
        }
    }
}
