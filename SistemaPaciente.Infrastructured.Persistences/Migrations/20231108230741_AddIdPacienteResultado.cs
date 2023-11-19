using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPaciente.Infrastructure.Persistence.Migrations
{
    public partial class AddIdPacienteResultado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoLaboratorio_Paciente_PacienteId",
                table: "ResultadoLaboratorio");

            migrationBuilder.DropIndex(
                name: "IX_ResultadoLaboratorio_PacienteId",
                table: "ResultadoLaboratorio");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "ResultadoLaboratorio");

            migrationBuilder.AddColumn<int>(
                name: "IdPaciente",
                table: "ResultadoLaboratorio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ResultadoLaboratorio_IdPaciente",
                table: "ResultadoLaboratorio",
                column: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadoLaboratorio_Paciente_IdPaciente",
                table: "ResultadoLaboratorio",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoLaboratorio_Paciente_IdPaciente",
                table: "ResultadoLaboratorio");

            migrationBuilder.DropIndex(
                name: "IX_ResultadoLaboratorio_IdPaciente",
                table: "ResultadoLaboratorio");

            migrationBuilder.DropColumn(
                name: "IdPaciente",
                table: "ResultadoLaboratorio");

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "ResultadoLaboratorio",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResultadoLaboratorio_PacienteId",
                table: "ResultadoLaboratorio",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadoLaboratorio_Paciente_PacienteId",
                table: "ResultadoLaboratorio",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "Id");
        }
    }
}
