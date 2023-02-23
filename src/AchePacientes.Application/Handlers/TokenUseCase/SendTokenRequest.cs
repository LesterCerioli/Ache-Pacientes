using MediatR;

namespace AchePacientes.Application.Handlers.TokenUseCase
{
    public class SendTokenRequest :IRequest<SendTokenReponse>
    {
        public Guid Id { get; private set; }
        public string? Name { get; set; }
        public string? PhoneRegion { get; set; }
        public string? PhoneNumber { get; set; }



        public SendTokenRequest()
        {
            Id = Guid.NewGuid();
        }
    }
}
