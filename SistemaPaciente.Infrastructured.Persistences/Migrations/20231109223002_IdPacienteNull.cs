using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPaciente.Infrastructure.Persistence.Migrations
{
    public partial class IdPacienteNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdPaciente",
                table: "ResultadoLaboratorio",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdPaciente",
                table: "ResultadoLaboratorio",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
