using Newtonsoft.Json.Linq;
using Salesforce.MarketingCloud.Api;
using Salesforce.MarketingCloud.Model;

namespace AchePacientes.Application.Services.SalesforceMc.Implementations
{
    public class MensagemTemplateUtilitario
    {
        public static Asset CreateSMSlAsset(string assunto, string mensagem)
        {
            string customerKey = $"{Guid.NewGuid()}";    // it has be unique
            string assetName = $"{Guid.NewGuid()}";      // it has be unique
            const string assetDescription = "SMS Asset created from automated C# SDK";
            const int htmlSMSAssetTypeId = 208;
            const string assetTypeName = "txtsms";
            var assetType = new AssetType(htmlSMSAssetTypeId, assetTypeName);
            const string json = @"{
                subjectline: {
                    content : '{assunto}'
                },
                html: {
                    content: '{mensagem}'
                }
            }";
            JObject views = JObject.Parse(json);
            return new Asset(customerKey: customerKey, assetType: assetType, name: assetName, description: assetDescription, views: views);
        }
        public static SmsDefinition CreateSMSDefinitionObject(AssetApi assetApi, string assunto, string mensagem)
        {
            /* Replace '<SUBSCRIBERS LIST KEY>' with the key of
            one of your subscribers lists or use 'All Subscribers'*/
            const string subscribersListKey = "<SUBSCRIBERS LIST KEY>";
            var emailAsset = CreateSMSlAsset(assunto, mensagem);
            var createAssetResult = assetApi.CreateAsset(emailAsset);
            var customerKey = createAssetResult.CustomerKey;
            var smsDefinitionName = $"{Guid.NewGuid()}";
            var smsDefinitionKey = $"{Guid.NewGuid()}";
            var content = new SmsDefinitionContent(customerKey);
            var subscriptions = new SmsDefinitionSubscriptions(subscribersListKey);
            return new SmsDefinition(smsDefinitionName, smsDefinitionKey, content: content, subscriptions: subscriptions);
        }
    }
}
