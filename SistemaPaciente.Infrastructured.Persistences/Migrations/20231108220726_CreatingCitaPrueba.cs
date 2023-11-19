using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPaciente.Infrastructure.Persistence.Migrations
{
    public partial class CreatingCitaPrueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoLaboratorio_Paciente_IdPaciente",
                table: "ResultadoLaboratorio");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoLaboratorio_PruebaLaboratorio_IdPruebaLaboratorio",
                table: "ResultadoLaboratorio");

            migrationBuilder.DropIndex(
                name: "IX_ResultadoLaboratorio_IdPaciente",
                table: "ResultadoLaboratorio");

            migrationBuilder.RenameColumn(
                name: "IdPruebaLaboratorio",
                table: "ResultadoLaboratorio",
                newName: "IdPruebaL");

            migrationBuilder.RenameColumn(
                name: "IdPaciente",
                table: "ResultadoLaboratorio",
                newName: "IdCita");

            migrationBuilder.RenameIndex(
                name: "IX_ResultadoLaboratorio_IdPruebaLaboratorio",
                table: "ResultadoLaboratorio",
                newName: "IX_ResultadoLaboratorio_IdPruebaL");

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
                name: "FK_ResultadoLaboratorio_Cita_IdPruebaL",
                table: "ResultadoLaboratorio",
                column: "IdPruebaL",
                principalTable: "Cita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadoLaboratorio_Paciente_PacienteId",
                table: "ResultadoLaboratorio",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadoLaboratorio_PruebaLaboratorio_IdPruebaL",
                table: "ResultadoLaboratorio",
                column: "IdPruebaL",
                principalTable: "PruebaLaboratorio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoLaboratorio_Cita_IdPruebaL",
                table: "ResultadoLaboratorio");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoLaboratorio_Paciente_PacienteId",
                table: "ResultadoLaboratorio");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoLaboratorio_PruebaLaboratorio_IdPruebaL",
                table: "ResultadoLaboratorio");

            migrationBuilder.DropIndex(
                name: "IX_ResultadoLaboratorio_PacienteId",
                table: "ResultadoLaboratorio");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "ResultadoLaboratorio");

            migrationBuilder.RenameColumn(
                name: "IdPruebaL",
                table: "ResultadoLaboratorio",
                newName: "IdPruebaLaboratorio");

            migrationBuilder.RenameColumn(
                name: "IdCita",
                table: "ResultadoLaboratorio",
                newName: "IdPaciente");

            migrationBuilder.RenameIndex(
                name: "IX_ResultadoLaboratorio_IdPruebaL",
                table: "ResultadoLaboratorio",
                newName: "IX_ResultadoLaboratorio_IdPruebaLaboratorio");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadoLaboratorio_IdPaciente",
                table: "ResultadoLaboratorio",
                column: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadoLaboratorio_Paciente_IdPaciente",
                table: "ResultadoLaboratorio",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadoLaboratorio_PruebaLaboratorio_IdPruebaLaboratorio",
                table: "ResultadoLaboratorio",
                column: "IdPruebaLaboratorio",
                principalTable: "PruebaLaboratorio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
