using AchePacientes.Application.Validation.Paciente;
using AchePacientes.Domain.Pacientes.Interfaces;
using AchePacientes.Domain.Pacientes.ValueObjects;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace AchePacientes.Application.Handlers.Paciente
{
    public class CreatePacienteHandler : IRequestHandler<CreatePacienteCommand, CreatePacienteResponse>
    {
        private IPacienteRepository _repositorioPaciente;
        private readonly ILogger<CreatePacienteHandler> _logger;
        public CreatePacienteHandler(IPacienteRepository repositorioPaciente, ILogger<CreatePacienteHandler> logger)
        {
            _repositorioPaciente = repositorioPaciente;
            _logger = logger;
        }

        public async Task<CreatePacienteResponse> Handle(CreatePacienteCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreatePacienteCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreatePacienteCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var paciente = await _repositorioPaciente.GetByCPF(new Cpf(command.Cpf));
                    if (paciente != null)
                        return await Task.FromResult(new CreatePacienteResponse(command.Id, "Paciente já foi cadastrado"));

                    await _repositorioPaciente.Add(command.GetEntity());
                    return await Task.FromResult(new CreatePacienteResponse(command.Id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreatePacienteResponse(command.Id, "Não foi possivel Processar solicitação."));
                }
            }

            return await Task.FromResult(new CreatePacienteResponse(command.Id, validationResult));
        }
    }
}
