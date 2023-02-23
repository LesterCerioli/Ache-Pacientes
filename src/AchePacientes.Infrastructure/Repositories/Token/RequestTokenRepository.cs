using AchePacientes.Domain.Token;
using AchePacientes.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AchePacientes.Infrastructure.Repositories.Token
{
    public class RequestTokenRepository : IRequestTokenRepository
    {
        protected readonly AchePacientesContext Db;
        protected readonly DbSet<RequestToken> DbSet;
        public RequestTokenRepository(AchePacientesContext context)
        {
            Db = context;
            DbSet = Db.Set<RequestToken>();
        }
        public async Task ExcluirPorTelefone(string telefone)
        {
            await Task.Run(() => {
                DbSet.RemoveRange(DbSet.Where(e => e.Telefone == telefone).ToArray());
                Db.SaveChanges();
             });            
        }
        public async Task Add(RequestToken requestToken)
        {
            await Task.Run(() => {
                DbSet.Add(requestToken);
                Db.SaveChanges();
            });
                       
        }
        public async Task<RequestToken> GetByRequestId(Guid requestId)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.RequestId == requestId);
        }
        public async Task Update(RequestToken requestToken)
        {
            await Task.Run(() => {
                DbSet.Update(requestToken);
                Db.SaveChanges();
            });
        }

    }
}
