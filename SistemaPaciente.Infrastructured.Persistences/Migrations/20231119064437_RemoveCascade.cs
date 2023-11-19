using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPaciente.Infrastructure.Persistence.Migrations
{
    public partial class RemoveCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Medico_IdMedico",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Paciente_IdPaciente",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoLaboratorio_Cita_IdPruebaL",
                table: "ResultadoLaboratorio");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoLaboratorio_PruebaLaboratorio_IdPruebaL",
                table: "ResultadoLaboratorio");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Role_RoleId",
                table: "Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Medico_IdMedico",
                table: "Cita",
                column: "IdMedico",
                principalTable: "Medico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Paciente_IdPaciente",
                table: "Cita",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadoLaboratorio_Cita_IdPruebaL",
                table: "ResultadoLaboratorio",
                column: "IdPruebaL",
                principalTable: "Cita",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadoLaboratorio_PruebaLaboratorio_IdPruebaL",
                table: "ResultadoLaboratorio",
                column: "IdPruebaL",
                principalTable: "PruebaLaboratorio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Role_RoleId",
                table: "Usuario",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Medico_IdMedico",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Paciente_IdPaciente",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoLaboratorio_Cita_IdPruebaL",
                table: "ResultadoLaboratorio");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoLaboratorio_PruebaLaboratorio_IdPruebaL",
                table: "ResultadoLaboratorio");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Role_RoleId",
                table: "Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Medico_IdMedico",
                table: "Cita",
                column: "IdMedico",
                principalTable: "Medico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Paciente_IdPaciente",
                table: "Cita",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadoLaboratorio_Cita_IdPruebaL",
                table: "ResultadoLaboratorio",
                column: "IdPruebaL",
                principalTable: "Cita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadoLaboratorio_PruebaLaboratorio_IdPruebaL",
                table: "ResultadoLaboratorio",
                column: "IdPruebaL",
                principalTable: "PruebaLaboratorio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Role_RoleId",
                table: "Usuario",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
