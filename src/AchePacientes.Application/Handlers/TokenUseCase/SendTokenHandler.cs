using AchePacientes.Application.Services.TwilioServices.Contratos;
using AchePacientes.Application.Validation.Token;
using AchePacientes.Domain.Token;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Web.Http;

namespace AchePacientes.Application.Handlers.TokenUseCase
{
    public class SendTokenHandler : IRequestHandler<SendTokenRequest, SendTokenReponse>
    {
        private IRequestTokenRepository _repositorioToken;
        private ITwilioSmsServices _twilioService;
        private readonly ILogger<SendTokenHandler> _logger;
        public SendTokenHandler(IRequestTokenRepository repositorioToken, ITwilioSmsServices twilioService, ILogger<SendTokenHandler> logger)
        {
            _repositorioToken = repositorioToken;
            _twilioService = twilioService;
            _logger = logger;
        }

        public async Task<SendTokenReponse> Handle(SendTokenRequest request, CancellationToken cancellationToken)
        {            
            _logger.LogInformation($"SendTokenRequest: {JsonSerializer.Serialize(request)}");
            request.PhoneNumber = request.PhoneNumber.Trim();
            // 1 Request valido (telefone) ??
            var validationResult = new SendTokenRequestValidation().Validate(request);
            if (validationResult.IsValid)
            {
                try
                {
                    // 2 Excluir anteriores
                    await _repositorioToken.ExcluirPorTelefone(request.PhoneNumber.Trim());

                    // 3 Cria novo token
                    RequestToken requestToken = new(request.Id, request.Name, request.PhoneRegion, request.PhoneNumber, DateTime.Now);

                    // 4 Envia sms
                    await _twilioService.SendSMS(
                        "+" + request.PhoneRegion + request.PhoneNumber,
                        "Cuidados pela vida. " + request.Name + " seu token é: " + requestToken.Token);
                    // 5 Persiste na base

                    await _repositorioToken.Add(requestToken);

                    // 6 Retorna RequestId, 
                    return await Task.FromResult(new SendTokenReponse(request.Id, validationResult, true));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new SendTokenReponse(request.Id, "Não foi possivel Processar solicitação.", false));
                }
            }
            // 7 Retorna Erro validacao, 
            return await Task.FromResult(new SendTokenReponse(request.Id,  validationResult, false));
        }
    }
}
