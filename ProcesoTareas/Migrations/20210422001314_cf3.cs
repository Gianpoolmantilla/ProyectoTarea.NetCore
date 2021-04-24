using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcesoTareas.Migrations
{
    public partial class cf3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Tarea_TareaId",
                table: "Estados");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Prioridades_PrioridadId",
                table: "Tarea");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoTareas_Tarea_TareaId",
                table: "TipoTareas");

            migrationBuilder.DropIndex(
                name: "IX_TipoTareas_TareaId",
                table: "TipoTareas");

            migrationBuilder.DropIndex(
                name: "IX_Tarea_PrioridadId",
                table: "Tarea");

            migrationBuilder.DropIndex(
                name: "IX_Estados_TareaId",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "TareaId",
                table: "TipoTareas");

            migrationBuilder.DropColumn(
                name: "TareaId",
                table: "Estados");

            migrationBuilder.CreateTable(
                name: "EstadoTarea",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    TareasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoTarea", x => new { x.EstadoId, x.TareasId });
                    table.ForeignKey(
                        name: "FK_EstadoTarea_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstadoTarea_Tarea_TareasId",
                        column: x => x.TareasId,
                        principalTable: "Tarea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrioridadTarea",
                columns: table => new
                {
                    PrioridadId = table.Column<int>(type: "int", nullable: false),
                    TareasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrioridadTarea", x => new { x.PrioridadId, x.TareasId });
                    table.ForeignKey(
                        name: "FK_PrioridadTarea_Prioridades_PrioridadId",
                        column: x => x.PrioridadId,
                        principalTable: "Prioridades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrioridadTarea_Tarea_TareasId",
                        column: x => x.TareasId,
                        principalTable: "Tarea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TareaTipoTarea",
                columns: table => new
                {
                    TareasId = table.Column<int>(type: "int", nullable: false),
                    TipoTareaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TareaTipoTarea", x => new { x.TareasId, x.TipoTareaId });
                    table.ForeignKey(
                        name: "FK_TareaTipoTarea_Tarea_TareasId",
                        column: x => x.TareasId,
                        principalTable: "Tarea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TareaTipoTarea_TipoTareas_TipoTareaId",
                        column: x => x.TipoTareaId,
                        principalTable: "TipoTareas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstadoTarea_TareasId",
                table: "EstadoTarea",
                column: "TareasId");

            migrationBuilder.CreateIndex(
                name: "IX_PrioridadTarea_TareasId",
                table: "PrioridadTarea",
                column: "TareasId");

            migrationBuilder.CreateIndex(
                name: "IX_TareaTipoTarea_TipoTareaId",
                table: "TareaTipoTarea",
                column: "TipoTareaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstadoTarea");

            migrationBuilder.DropTable(
                name: "PrioridadTarea");

            migrationBuilder.DropTable(
                name: "TareaTipoTarea");

            migrationBuilder.AddColumn<int>(
                name: "TareaId",
                table: "TipoTareas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TareaId",
                table: "Estados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoTareas_TareaId",
                table: "TipoTareas",
                column: "TareaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_PrioridadId",
                table: "Tarea",
                column: "PrioridadId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_TareaId",
                table: "Estados",
                column: "TareaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_Tarea_TareaId",
                table: "Estados",
                column: "TareaId",
                principalTable: "Tarea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Prioridades_PrioridadId",
                table: "Tarea",
                column: "PrioridadId",
                principalTable: "Prioridades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoTareas_Tarea_TareaId",
                table: "TipoTareas",
                column: "TareaId",
                principalTable: "Tarea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
