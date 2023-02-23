using Salesforce.MarketingCloud.Model;

namespace AchePacientes.Application.Services.SalesforceMc.Contratos
{
    public interface ISendSmsSingleRecipientService
    {
        Task<GetDefinitionSendStatusForRecipientResponse> Send(string telefone, string assunto, string mensagem);
    }
}
