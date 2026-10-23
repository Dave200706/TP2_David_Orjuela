using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NutriVie.Migrations
{
    /// <inheritdoc />
    public partial class ajoutClasseAliment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aliments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaloriesPour100g = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliments", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Aliments",
                columns: new[] { "Id", "CaloriesPour100g", "Nom" },
                values: new object[,]
                {
                    { 1, 250.0, "Boeuf" },
                    { 2, 85.0, "Vin rouge" },
                    { 3, 41.0, "Carottes" },
                    { 4, 40.0, "Oignons" },
                    { 5, 541.0, "Bacon" },
                    { 6, 155.0, "Oeufs" },
                    { 7, 413.0, "Fromage gruyère" },
                    { 8, 292.0, "Crème fraîche" },
                    { 9, 165.0, "Poulet" },
                    { 10, 35.0, "Sauce tomate" },
                    { 11, 282.0, "Épices tikka" },
                    { 12, 61.0, "Yogourt" },
                    { 13, 717.0, "Beurre" },
                    { 14, 29.0, "Citron" },
                    { 15, 130.0, "Riz" },
                    { 16, 354.0, "Curcuma" },
                    { 17, 371.0, "Pâtes à lasagne" },
                    { 18, 254.0, "Viande hachée" },
                    { 19, 22.0, "Champignons" },
                    { 20, 8.0, "Bouillon de poulet" },
                    { 21, 360.0, "Semoule" },
                    { 22, 17.0, "Courgettes" },
                    { 23, 364.0, "Pois chiches" },
                    { 24, 275.0, "Pain pita" },
                    { 25, 595.0, "Tahini" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlimentRecette_RecettesId",
                table: "AlimentRecette",
                column: "RecettesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlimentRecette");

            migrationBuilder.DropTable(
                name: "Aliments");
        }
    }
}
