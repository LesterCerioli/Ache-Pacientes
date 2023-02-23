namespace AchePacientes.Domain.Token
{
    public interface IRequestTokenRepository
    {
        Task ExcluirPorTelefone(string telefone);
        Task Add(RequestToken requestToken);
        Task<RequestToken> GetByRequestId(Guid requestId);
        Task Update(RequestToken requestToken);
    }
}
