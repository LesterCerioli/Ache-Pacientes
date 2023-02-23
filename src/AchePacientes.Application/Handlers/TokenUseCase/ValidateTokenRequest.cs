using MediatR;

namespace AchePacientes.Application.Handlers.TokenUseCase
{
    public class ValidateTokenRequest : IRequest< ValidateTokenResponse>
    {
        public Guid Id { get; private set; }
        public string? RequestId { get; set; }

        public string? Token { get; set; }

        public ValidateTokenRequest()
        {
            Id = Guid.NewGuid();
        }
    }
}
