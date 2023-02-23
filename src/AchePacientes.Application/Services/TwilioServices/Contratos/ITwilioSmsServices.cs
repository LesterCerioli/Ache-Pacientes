namespace AchePacientes.Application.Services.TwilioServices.Contratos
{
    public interface ITwilioSmsServices
    {
        Task SendSMS(string telefone, string msg);
    }
}
