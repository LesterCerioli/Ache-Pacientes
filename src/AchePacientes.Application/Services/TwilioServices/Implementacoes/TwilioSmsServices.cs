using AchePacientes.Application.Services.TwilioServices.Contratos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace AchePacientes.Application.Services.TwilioServices.Implementacoes
{
    public  class TwilioSmsServices : ITwilioSmsServices
    {
        private readonly ILogger<TwilioSmsServices> _logger;
        private readonly IConfiguration _configuration;
        public TwilioSmsServices(ILogger<TwilioSmsServices> logger, IConfiguration configuration) 
        {
            _logger = logger;
            _configuration = configuration;
        }  
        public Task SendSMS(string telefone, string msg)
        {
            string accountSid = _configuration["Twilio:AccountSid"];
            string authToken = _configuration["Twilio:AuthToken"];
            //Dados phone de envio DDI + DDD + PHONE
            string serviceId = _configuration["Twilio:ServiceID"];
            //Dados Destino DDI + DDD + PHONE
            try
            {
                TwilioClient.Init(accountSid, authToken);
                var messageOptions = new CreateMessageOptions(new PhoneNumber(telefone));
                messageOptions.MessagingServiceSid = serviceId;
                messageOptions.Body = msg;
                var message = MessageResource.Create(messageOptions);
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possivel enviar sms via Twilio: ", ex);
                throw;
            }
            
            return Task.CompletedTask;
        }
    }
}
