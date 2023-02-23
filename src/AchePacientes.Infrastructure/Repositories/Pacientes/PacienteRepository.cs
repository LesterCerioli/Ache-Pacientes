using AchePacientes.Domain.Pacientes.Interfaces;
using AchePacientes.Domain.Pacientes.Models;
using AchePacientes.Domain.Pacientes.ValueObjects;
using AchePacientes.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AchePacientes.Infrastructure.Repositories.Pacientes
{
    public class PacienteRepository : IPacienteRepository
    {
        protected readonly AchePacientesContext Db;
        protected readonly DbSet<Paciente> DbSet;

        public PacienteRepository(AchePacientesContext context)
        {
            Db = context;
            DbSet = context.Pacientes;
        }

        public async Task<IEnumerable<Paciente>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Paciente> GetByCPF(Cpf cpf)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Cpf.CPFNumero == cpf.CPFNumero);
        }
        public async Task<Paciente> GetByCPFAndDataNascimento(Cpf cpf, DateTime nascimento)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Cpf.CPFNumero == cpf.CPFNumero && c.DataNascimento == nascimento);
        }

        public async Task Add(Paciente paciente)
        {
            await Task.Run(() => { 
                DbSet.Add(paciente);
                Db.SaveChanges();
            });
        }

        public void Update(Paciente paciente)
        {
            DbSet.Update(paciente);
        }

        public void Remove(Paciente paciente)
        {
            DbSet.Remove(paciente);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
