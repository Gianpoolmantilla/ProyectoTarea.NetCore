using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcesoTareas.Migrations
{
    public partial class cf0055 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prioridades_Tarea_TareaId",
                table: "Prioridades");

            migrationBuilder.DropIndex(
                name: "IX_Prioridades_TareaId",
                table: "Prioridades");

            migrationBuilder.DropColumn(
                name: "TareaId",
                table: "Prioridades");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_PrioridadId",
                table: "Tarea",
                column: "PrioridadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Prioridades_PrioridadId",
                table: "Tarea",
                column: "PrioridadId",
                principalTable: "Prioridades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Prioridades_PrioridadId",
                table: "Tarea");

            migrationBuilder.DropIndex(
                name: "IX_Tarea_PrioridadId",
                table: "Tarea");

            migrationBuilder.AddColumn<int>(
                name: "TareaId",
                table: "Prioridades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prioridades_TareaId",
                table: "Prioridades",
                column: "TareaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prioridades_Tarea_TareaId",
                table: "Prioridades",
                column: "TareaId",
                principalTable: "Tarea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
