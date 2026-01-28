using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_api_personas.Migrations
{
    /// <inheritdoc />
    public partial class CategoriaPersonas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaPersonas",
                columns: table => new
                {
                    personaId = table.Column<int>(type: "integer", nullable: false),
                    categoriaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaPersonas", x => new { x.categoriaId, x.personaId });
                    table.ForeignKey(
                        name: "FK_CategoriaPersonas_Categorias_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaPersonas_Personas_personaId",
                        column: x => x.personaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaPersonas_personaId",
                table: "CategoriaPersonas",
                column: "personaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaPersonas");
        }
    }
}
