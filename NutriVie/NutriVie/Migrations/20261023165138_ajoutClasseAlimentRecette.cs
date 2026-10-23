using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NutriVie.Migrations
{
    /// <inheritdoc />
    public partial class ajoutClasseAlimentRecette : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlimentRecette");

            migrationBuilder.CreateTable(
                name: "AlimentRecettes",
                columns: table => new
                {
                    RecetteId = table.Column<int>(type: "int", nullable: false),
                    AlimentId = table.Column<int>(type: "int", nullable: false),
                    Poids = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlimentRecettes", x => new { x.RecetteId, x.AlimentId });
                    table.ForeignKey(
                        name: "FK_AlimentRecettes_Aliments_AlimentId",
                        column: x => x.AlimentId,
                        principalTable: "Aliments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlimentRecettes_Recettes_RecetteId",
                        column: x => x.RecetteId,
                        principalTable: "Recettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AlimentRecettes",
                columns: new[] { "AlimentId", "RecetteId", "Poids" },
                values: new object[,]
                {
                    { 1, 1, 800.0 },
                    { 2, 1, 500.0 },
                    { 3, 1, 200.0 },
                    { 4, 1, 150.0 },
                    { 5, 2, 200.0 },
                    { 6, 2, 3.0 },
                    { 7, 2, 100.0 },
                    { 8, 2, 200.0 },
                    { 9, 3, 600.0 },
                    { 10, 3, 300.0 },
                    { 11, 3, 30.0 },
                    { 12, 3, 150.0 },
                    { 8, 4, 100.0 },
                    { 9, 4, 600.0 },
                    { 10, 4, 250.0 },
                    { 13, 4, 80.0 },
                    { 4, 5, 300.0 },
                    { 9, 5, 700.0 },
                    { 14, 5, 2.0 },
                    { 13, 6, 30.0 },
                    { 15, 6, 400.0 },
                    { 16, 6, 5.0 },
                    { 7, 7, 150.0 },
                    { 10, 7, 400.0 },
                    { 17, 7, 300.0 },
                    { 18, 7, 500.0 },
                    { 13, 8, 50.0 },
                    { 15, 8, 350.0 },
                    { 19, 8, 300.0 },
                    { 20, 8, 500.0 },
                    { 9, 9, 300.0 },
                    { 21, 9, 500.0 },
                    { 22, 9, 200.0 },
                    { 23, 9, 150.0 },
                    { 4, 10, 100.0 },
                    { 9, 10, 500.0 },
                    { 24, 10, 2.0 },
                    { 25, 10, 50.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlimentRecettes_AlimentId",
                table: "AlimentRecettes",
                column: "AlimentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlimentRecettes");

            migrationBuilder.CreateTable(
                name: "AlimentRecette",
                columns: table => new
                {
                    AlimentId = table.Column<int>(type: "int", nullable: false),
                    RecettesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlimentRecette", x => new { x.AlimentId, x.RecettesId });
                    table.ForeignKey(
                        name: "FK_AlimentRecette_Aliments_AlimentId",
                        column: x => x.AlimentId,
                        principalTable: "Aliments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlimentRecette_Recettes_RecettesId",
                        column: x => x.RecettesId,
                        principalTable: "Recettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlimentRecette_RecettesId",
                table: "AlimentRecette",
                column: "RecettesId");
        }
    }
}
