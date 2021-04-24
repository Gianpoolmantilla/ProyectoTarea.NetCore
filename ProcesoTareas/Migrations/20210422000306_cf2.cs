using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcesoTareas.Migrations
{
    public partial class cf2 : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "TipoTareaId",
                table: "Tarea",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PrioridadId",
                table: "Tarea",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "TipoTareaId",
                table: "Tarea",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PrioridadId",
                table: "Tarea",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
