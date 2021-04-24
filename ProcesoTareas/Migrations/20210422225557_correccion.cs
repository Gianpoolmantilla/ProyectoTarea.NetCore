using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcesoTareas.Migrations
{
    public partial class correccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "loginErrorMessage",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "loginErrorMessage",
                table: "Usuarios");
        }
    }
}
