using AchePacientes.Application.Validation.Token;
using AchePacientes.Domain.Token;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Web.Http;

namespace AchePacientes.Application.Handlers.TokenUseCase
{
    [AllowAnonymous]
    public  class ValidateTokenHandler : IRequestHandler<ValidateTokenRequest, ValidateTokenResponse>
    {
        private IRequestTokenRepository _repositorioToken;
        private readonly ILogger<ValidateTokenHandler> _logger;

        private int maxMinutosValidos = 30;

        public ValidateTokenHandler(IRequestTokenRepository repositorioToken, ILogger<ValidateTokenHandler> logger)
        {
            _repositorioToken = repositorioToken;
            _logger = logger;
        }

        public async Task<ValidateTokenResponse> Handle(ValidateTokenRequest request, CancellationToken cancellationToken)
        {
            request.Token = request.Token.Trim();

            _logger.LogInformation($"ValidateTokenRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new ValidateTokenRequestValidation().Validate(request);
            // 1 Valida Request
            try
            {
                if (validationResult.IsValid)
                {
                    // 2 valida na base de dados se Request Id existe

                    var originalRequest = await _repositorioToken.GetByRequestId(Guid.Parse(request.RequestId));

                    if (originalRequest == null)
                    {
                        return await Task.FromResult(new ValidateTokenResponse(request.Id, false, "Token inválido"));
                    }
                    // 3 Se existir na base, valida o tempo
                    bool TempoInValido = originalRequest.Created.AddMinutes(maxMinutosValidos) < DateTime.Now;
                    // 4 Valida token
                    bool TokenDiferente = (originalRequest.Token != request.Token);

                    if (TempoInValido || TokenDiferente || originalRequest.Validated.HasValue)
                    {
                        return await Task.FromResult(new ValidateTokenResponse(request.Id, false, "Token inválido"));
                    }

                    // 5 Persistir na base que aquele RequestToken foi validado
                    originalRequest.Validated = DateTime.Now;
                    await _repositorioToken.Update(originalRequest);

                    return await Task.FromResult(new ValidateTokenResponse(request.Id, true));

                }
                // 6 Retorna Erro Validacao
                return await Task.FromResult(new ValidateTokenResponse(request.Id, false, validationResult));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return await Task.FromResult(new ValidateTokenResponse(request.Id, false, "Não foi possivel Processar solicitação."));
            }
            
        }
    }
}
