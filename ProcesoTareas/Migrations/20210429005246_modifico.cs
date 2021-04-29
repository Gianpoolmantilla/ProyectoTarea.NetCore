using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcesoTareas.Migrations
{
    public partial class modifico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Tarea_TareaId",
                table: "Estados");

            migrationBuilder.DropForeignKey(
                name: "FK_Prioridades_Tarea_TareaId",
                table: "Prioridades");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoTareas_Tarea_TareaId",
                table: "TipoTareas");

            migrationBuilder.DropIndex(
                name: "IX_TipoTareas_TareaId",
                table: "TipoTareas");

            migrationBuilder.DropIndex(
                name: "IX_Prioridades_TareaId",
                table: "Prioridades");

            migrationBuilder.DropIndex(
                name: "IX_Estados_TareaId",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TareaId",
                table: "TipoTareas");

            migrationBuilder.DropColumn(
                name: "TareaId",
                table: "Prioridades");

            migrationBuilder.DropColumn(
                name: "Debaja",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "FechaAlta",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "FechaMod",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Estados");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "Usuarios",
                newName: "LoginErrorMessage");

            migrationBuilder.RenameColumn(
                name: "TareaId",
                table: "Estados",
                newName: "CodEstado");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreuserId",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaVencimiento",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "CodEstado", "Descripcion" },
                values: new object[,]
                {
                    { 1, 0, "Alta" },
                    { 2, 50, "Modificacion" },
                    { 3, 100, "Pendiente" },
                    { 4, 600, "Realizado" },
                    { 5, 900, "Rechazado" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Debaja", "Email", "FechaAlta", "FechaMod", "LoginErrorMessage", "Nombre", "NombreuserId", "Password", "UserId" },
                values: new object[] { 1, "", "soporte@mail.com", new DateTime(2021, 4, 28, 21, 52, 45, 944, DateTimeKind.Local).AddTicks(6029), new DateTime(2021, 4, 28, 21, 52, 45, 946, DateTimeKind.Local).AddTicks(8926), null, "Administrador", "admin", "123", "" });

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_EstadoId",
                table: "Tarea",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_PrioridadId",
                table: "Tarea",
                column: "PrioridadId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_TipoTareaId",
                table: "Tarea",
                column: "TipoTareaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Estados_EstadoId",
                table: "Tarea",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Prioridades_PrioridadId",
                table: "Tarea",
                column: "PrioridadId",
                principalTable: "Prioridades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_TipoTareas_TipoTareaId",
                table: "Tarea",
                column: "TipoTareaId",
                principalTable: "TipoTareas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Estados_EstadoId",
                table: "Tarea");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Prioridades_PrioridadId",
                table: "Tarea");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_TipoTareas_TipoTareaId",
                table: "Tarea");

            migrationBuilder.DropIndex(
                name: "IX_Tarea_EstadoId",
                table: "Tarea");

            migrationBuilder.DropIndex(
                name: "IX_Tarea_PrioridadId",
                table: "Tarea");

            migrationBuilder.DropIndex(
                name: "IX_Tarea_TipoTareaId",
                table: "Tarea");

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FechaVencimiento",
                table: "Tarea");

            migrationBuilder.RenameColumn(
                name: "LoginErrorMessage",
                table: "Usuarios",
                newName: "Apellido");

            migrationBuilder.RenameColumn(
                name: "CodEstado",
                table: "Estados",
                newName: "TareaId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NombreuserId",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TareaId",
                table: "TipoTareas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TareaId",
                table: "Prioridades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Debaja",
                table: "Estados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAlta",
                table: "Estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaMod",
                table: "Estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Estados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoTareas_TareaId",
                table: "TipoTareas",
                column: "TareaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prioridades_TareaId",
                table: "Prioridades",
                column: "TareaId");

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
                name: "FK_Prioridades_Tarea_TareaId",
                table: "Prioridades",
                column: "TareaId",
                principalTable: "Tarea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
