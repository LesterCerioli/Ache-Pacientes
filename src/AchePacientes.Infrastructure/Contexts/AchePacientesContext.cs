using Microsoft.EntityFrameworkCore;
using AchePacientes.Domain.Pacientes.Models;
using FluentValidation.Results;
using AchePacientes.Infrastructure.Mappings.EFCore.Pacientes;
using NetDevPack.Messaging;
using AchePacientes.Domain.Token;
using AchePacientes.Infrastructure.Mappings.EFCore.Token;


namespace AchePacientes.Infrastructure.Contexts
{
    public class AchePacientesContext : DbContext //, IUnitOfWork
    {
        public AchePacientesContext(DbContextOptions<AchePacientesContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<RequestToken> RequestTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfiguration(new PacienteMap());
            modelBuilder.ApplyConfiguration(new TokenRequestMap());

            modelBuilder.Entity<Paciente>(c =>
            {
                c.ToTable("Pacientes");
            });

            modelBuilder.Entity<RequestToken>(c =>
            {
                c.ToTable("RequestToken");
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}

