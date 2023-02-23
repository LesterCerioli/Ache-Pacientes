using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AchePacientes.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCompleto = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    TelefonePaciente = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    TelefoneRegiao = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    AceitouComunicacao = table.Column<bool>(type: "bit", nullable: false),
                    AceitouTermo = table.Column<bool>(type: "bit", nullable: false),
                    CpfNumero = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCompleto = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    TelefoneRegiao = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Validated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Token = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestToken", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "RequestToken");
        }
    }
}
