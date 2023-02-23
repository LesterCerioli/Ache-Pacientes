using AchePacientes.Application.Validation.Paciente;
using AchePacientes.Domain.Pacientes.Interfaces;
using AchePacientes.Domain.Pacientes.ValueObjects;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace AchePacientes.Application.Handlers.Paciente
{
    public  class CheckPacienteExistsByCpfAndDtOfBirthHandlers : IRequestHandler<CheckPacienteExistsByCpfAndDtOfBirthRequest, CheckPacienteExistsByCpfAndDtOfBirthResponse>
    {
        private IPacienteRepository _repositorioPaciente;
        private readonly ILogger<CheckPacienteExistsByCpfAndDtOfBirthHandlers> _logger;

        public CheckPacienteExistsByCpfAndDtOfBirthHandlers(IPacienteRepository repositorioPaciente, ILogger<CheckPacienteExistsByCpfAndDtOfBirthHandlers> logger)
        {
            _repositorioPaciente = repositorioPaciente;
            _logger = logger;
        }
        public async Task<CheckPacienteExistsByCpfAndDtOfBirthResponse> Handle(CheckPacienteExistsByCpfAndDtOfBirthRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckPacienteExistsByCpfAndBirthDayRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckPacienteExistsByCpfAndBirthDayRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var paciente = await _repositorioPaciente.GetByCPFAndDataNascimento(new Cpf(request.Cpf), request.DtOfBirth.Value);
                    if (paciente != null)
                        return await Task.FromResult(new CheckPacienteExistsByCpfAndDtOfBirthResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckPacienteExistsByCpfAndDtOfBirthResponse(request.Id, "Não foi possivel Processar solicitação."));
                }
            }

            return await Task.FromResult(new CheckPacienteExistsByCpfAndDtOfBirthResponse(request.Id, false, validationResult));
        }
    }
}
