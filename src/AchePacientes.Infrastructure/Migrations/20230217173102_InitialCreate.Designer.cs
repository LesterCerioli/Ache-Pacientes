﻿// <auto-generated />
using System;
using AchePacientes.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AchePacientes.Infrastructure.Migrations
{
    [DbContext(typeof(AchePacientesContext))]
    [Migration("20230217173102_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AchePacientes.Domain.Pacientes.Models.Paciente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<bool>("AceitouComunicacao")
                        .HasColumnType("bit")
                        .HasColumnName("AceitouComunicacao");

                    b.Property<bool>("AceitouTermo")
                        .HasColumnType("bit")
                        .HasColumnName("AceitouTermo");

                    b.Property<string>("TelefoneNumero")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)")
                        .HasColumnName("TelefonePaciente");

                    b.Property<string>("TelefoneRegiao")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("TelefoneRegiao");

                    b.HasKey("Id");

                    b.ToTable("Pacientes", (string)null);
                });

            modelBuilder.Entity("AchePacientes.Domain.Token.RequestToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("Created");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("NomeCompleto");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RequestId");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)")
                        .HasColumnName("Telefone");

                    b.Property<string>("TelefoneRegiao")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("TelefoneRegiao");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("varchar(4)")
                        .HasColumnName("Token");

                    b.Property<DateTime?>("Validated")
                        .HasColumnType("datetime")
                        .HasColumnName("Validated");

                    b.HasKey("Id");

                    b.ToTable("RequestToken", (string)null);
                });

            modelBuilder.Entity("AchePacientes.Domain.Pacientes.Models.Paciente", b =>
                {
                    b.OwnsOne("AchePacientes.Domain.Pacientes.ValueObjects.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<Guid>("PacienteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("CPFNumero")
                                .IsRequired()
                                .HasColumnType("varchar(100)")
                                .HasColumnName("CpfNumero");

                            b1.HasKey("PacienteId");

                            b1.ToTable("Pacientes");

                            b1.WithOwner()
                                .HasForeignKey("PacienteId");
                        });

                    b.OwnsOne("AchePacientes.Domain.Pacientes.ValueObjects.DataLog", "DataLog", b1 =>
                        {
                            b1.Property<Guid>("PacienteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("DataAtualizacao")
                                .HasColumnType("datetime2")
                                .HasColumnName("DataAtualizacao");

                            b1.Property<DateTime>("DataCriacao")
                                .HasColumnType("datetime2")
                                .HasColumnName("DataCriacao");

                            b1.HasKey("PacienteId");

                            b1.ToTable("Pacientes");

                            b1.WithOwner()
                                .HasForeignKey("PacienteId");
                        });

                    b.OwnsOne("AchePacientes.Domain.Pacientes.ValueObjects.Nome", "Nome", b1 =>
                        {
                            b1.Property<Guid>("PacienteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("NomeCompleto")
                                .IsRequired()
                                .HasMaxLength(40)
                                .HasColumnType("varchar(40)")
                                .HasColumnName("NomeCompleto");

                            b1.HasKey("PacienteId");

                            b1.ToTable("Pacientes");

                            b1.WithOwner()
                                .HasForeignKey("PacienteId");
                        });

                    b.Navigation("Cpf")
                        .IsRequired();

                    b.Navigation("DataLog")
                        .IsRequired();

                    b.Navigation("Nome")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
