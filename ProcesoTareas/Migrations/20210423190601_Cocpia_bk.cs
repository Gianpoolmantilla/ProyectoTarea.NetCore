using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcesoTareas.Migrations
{
    public partial class Cocpia_bk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "Usuarios",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuarios",
                newName: "Apellido");

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
