using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaGestaoMedica.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSobrenomeFromPacienteAndMedico2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Convenios");

            migrationBuilder.DropColumn(
                name: "Convenio",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "ConvenioId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "NumeroConvenio",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "PagamentoRealizado",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "Procedimento",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "ValidadeConvenio",
                table: "Agendamentos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Convenio",
                table: "Agendamentos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ConvenioId",
                table: "Agendamentos",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroConvenio",
                table: "Agendamentos",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "PagamentoRealizado",
                table: "Agendamentos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Procedimento",
                table: "Agendamentos",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidadeConvenio",
                table: "Agendamentos",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Convenios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    RegistroANS = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenios", x => x.Id);
                });
        }
    }
}
