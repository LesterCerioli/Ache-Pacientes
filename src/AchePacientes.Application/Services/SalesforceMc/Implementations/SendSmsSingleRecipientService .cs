using AchePacientes.Application.Services.SalesforceMc.Contratos;
using Microsoft.Extensions.Configuration;
using Salesforce.MarketingCloud.Model;

namespace AchePacientes.Application.Services.SalesforceMc.Implementations
{
    public class SendSmsSingleRecipientService : ISendSmsSingleRecipientService
    {
        private readonly IConfiguration Configuration;
        public SendSmsSingleRecipientService(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task<GetDefinitionSendStatusForRecipientResponse> Send(string telefone, string assunto, string mensagem)
        {
            // Replace '<CONTACT KEY>' with a real subscriber key
            var contactKey = Configuration["SalesForceMC:CONTACT_KEY"];
            /* Replace the constructor parameters with your Marketing Cloud account credentials
            (<APPLICATION DATA-ACCESS PERMISSIONS> is not a mandatory parameter) */
            var client = new Salesforce.MarketingCloud.Api.Client(
                Configuration["SalesForceMC:AUTH_BASE_URL"],
                Configuration["SalesForceMC:CLIENT_ID"],
                Configuration["SalesForceMC:CLIENT_SECRET"],
                Configuration["SalesForceMC:ACCOUNT_ID"],
                Configuration["SalesForceMC:APPLICATION_DATA_ACCESS_PERMISSIONS"]);
            // Get the asset, transactional messaging API instances:
            var assetApi = client.AssetApi;
            var transactionalMessagingApi = client.TransactionalMessagingApi;
            // Create sms send definition:
            var smsDefinitionObject = MensagemTemplateUtilitario.CreateSMSDefinitionObject(assetApi, assunto, mensagem);
            var createSMSlDefinitionResult = await transactionalMessagingApi.CreateSmsDefinitionAsync(smsDefinitionObject);
            // Get sms send definition:
            var getSMSDefinitionsResult = await transactionalMessagingApi.GetSmsDefinitionAsync(createSMSlDefinitionResult.DefinitionKey);
            // Send sms to single recipient:
            var recipientMessageKey = $"{Guid.NewGuid()}";
            var recipient = new Recipient(contactKey, telefone);
            var messageRequestBody = new SendSmsToSingleRecipientRequest(getSMSDefinitionsResult.DefinitionKey, recipient);
            await transactionalMessagingApi.SendSmsToSingleRecipientAsync(recipientMessageKey, messageRequestBody);
            // Get the send status of the sms send:
            return await transactionalMessagingApi.GetSmsSendStatusForRecipientAsync(recipientMessageKey);
        }
    }
}
