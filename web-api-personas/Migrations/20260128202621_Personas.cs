using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_api_personas.Migrations
{
    /// <inheritdoc />
    public partial class Personas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "Telefonos",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CorreoId",
                table: "Personas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DirreccionId",
                table: "Personas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TelefonoId",
                table: "Personas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "Dirrecciones",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "Correos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_PersonaId",
                table: "Telefonos",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_CorreoId",
                table: "Personas",
                column: "CorreoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_DirreccionId",
                table: "Personas",
                column: "DirreccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_TelefonoId",
                table: "Personas",
                column: "TelefonoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dirrecciones_PersonaId",
                table: "Dirrecciones",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Correos_PersonaId",
                table: "Correos",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Correos_Personas_PersonaId",
                table: "Correos",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dirrecciones_Personas_PersonaId",
                table: "Dirrecciones",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Correos_CorreoId",
                table: "Personas",
                column: "CorreoId",
                principalTable: "Correos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Dirrecciones_DirreccionId",
                table: "Personas",
                column: "DirreccionId",
                principalTable: "Dirrecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Telefonos_TelefonoId",
                table: "Personas",
                column: "TelefonoId",
                principalTable: "Telefonos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefonos_Personas_PersonaId",
                table: "Telefonos",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Correos_Personas_PersonaId",
                table: "Correos");

            migrationBuilder.DropForeignKey(
                name: "FK_Dirrecciones_Personas_PersonaId",
                table: "Dirrecciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Correos_CorreoId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Dirrecciones_DirreccionId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Telefonos_TelefonoId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefonos_Personas_PersonaId",
                table: "Telefonos");

            migrationBuilder.DropIndex(
                name: "IX_Telefonos_PersonaId",
                table: "Telefonos");

            migrationBuilder.DropIndex(
                name: "IX_Personas_CorreoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_DirreccionId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_TelefonoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Dirrecciones_PersonaId",
                table: "Dirrecciones");

            migrationBuilder.DropIndex(
                name: "IX_Correos_PersonaId",
                table: "Correos");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Telefonos");

            migrationBuilder.DropColumn(
                name: "CorreoId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "DirreccionId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "TelefonoId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Dirrecciones");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Correos");
        }
    }
}
