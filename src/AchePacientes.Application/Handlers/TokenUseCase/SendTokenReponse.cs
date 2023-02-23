using AchePacientes.Application.Core;
using FluentValidation.Results;

namespace AchePacientes.Application.Handlers.TokenUseCase
{
    public class SendTokenReponse : Response
    {
        public Guid RequestId { get; set; }
        public bool Created { get; set; }
        public SendTokenReponse(Guid requestId, ValidationResult validationResult, bool created) 
        {
            RequestId = requestId;
            Created = created;
            foreach (var item in validationResult.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }
        public SendTokenReponse(Guid requestId,  string falhaValidacao,bool isValid)
        {
            RequestId = requestId;
            Created = isValid;
            this.AddError(falhaValidacao);
        }
        public SendTokenReponse(Guid requestId, bool isValid)
        {
            RequestId = requestId;
            Created = isValid;
        }
    }
}
