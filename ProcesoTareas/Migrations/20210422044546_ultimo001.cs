using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcesoTareas.Migrations
{
    public partial class ultimo001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaVencimiento",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaVencimiento",
                table: "Tarea");
        }
    }
}
