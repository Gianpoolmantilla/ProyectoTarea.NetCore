using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcesoTareas.Migrations
{
    public partial class www : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodEstado",
                table: "Estados",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodEstado",
                table: "Estados");
        }
    }
}
