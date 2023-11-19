using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPaciente.Infrastructure.Persistence.Migrations
{
    public partial class ChangeRelationResultado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoLaboratorio_Cita_IdPruebaL",
                table: "ResultadoLaboratorio");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadoLaboratorio_IdCita",
                table: "ResultadoLaboratorio",
                column: "IdCita");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadoLaboratorio_Cita_IdCita",
                table: "ResultadoLaboratorio",
                column: "IdCita",
                principalTable: "Cita",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoLaboratorio_Cita_IdCita",
                table: "ResultadoLaboratorio");

            migrationBuilder.DropIndex(
                name: "IX_ResultadoLaboratorio_IdCita",
                table: "ResultadoLaboratorio");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadoLaboratorio_Cita_IdPruebaL",
                table: "ResultadoLaboratorio",
                column: "IdPruebaL",
                principalTable: "Cita",
                principalColumn: "Id");
        }
    }
}
