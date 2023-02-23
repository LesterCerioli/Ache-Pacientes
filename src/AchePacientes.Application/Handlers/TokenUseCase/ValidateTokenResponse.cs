using AchePacientes.Application.Core;
using FluentValidation.Results;

namespace AchePacientes.Application.Handlers.TokenUseCase
{
    public class ValidateTokenResponse : Response
    {
        public Guid RequestId { get; set; }

        public bool IsValid { get; set; }

        public ValidateTokenResponse(Guid requestId, bool isValid, ValidationResult validationResult)
        {
            RequestId = requestId;
            IsValid = isValid;
            foreach (var item in validationResult.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }
        public ValidateTokenResponse(Guid requestId, bool isValid, string falhaValidacao)
        {
            RequestId = requestId;
            IsValid = isValid;
            this.AddError(falhaValidacao);
        }
        public ValidateTokenResponse(Guid requestId, bool isValid)
        {
            RequestId = requestId;
            IsValid = isValid;
        }
    }
}
