using AchePacientes.Domain.Pacientes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AchePacientes.Infrastructure.Mappings.EFCore.Pacientes
{
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.TelefoneNumero)
                .HasColumnName("TelefonePaciente")
                .HasColumnType("varchar(13)")
                .HasMaxLength(13)
                .IsRequired();

            builder.Property(c => c.TelefoneRegiao)
                .HasColumnName("TelefoneRegiao")
                .HasColumnType("varchar(2)")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(c => c.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(c => c.AceitouComunicacao)
                .HasColumnName("AceitouComunicacao")
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(c => c.AceitouTermo)
                .HasColumnName("AceitouTermo")
                .HasColumnType("bit")
                .IsRequired();

            builder.OwnsOne(p => p.Nome)
                            .Property(p => p.NomeCompleto).HasColumnName("NomeCompleto");

            builder.OwnsOne(p => p.Cpf)
                            .Property(p => p.CPFNumero).HasColumnName("CpfNumero");


            builder.OwnsOne(p => p.DataLog)
                            .Property(p => p.DataCriacao).HasColumnName("DataCriacao");

            builder.OwnsOne(p => p.DataLog) 
                            .Property(p => p.DataAtualizacao).HasColumnName("DataAtualizacao");
        }
    }
}
