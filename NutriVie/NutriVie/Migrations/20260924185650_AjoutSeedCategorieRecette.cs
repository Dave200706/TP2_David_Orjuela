using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NutriVie.Migrations
{
    /// <inheritdoc />
    public partial class AjoutSeedCategorieRecette : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recette",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempsPreparation = table.Column<int>(type: "int", nullable: false),
                    TempsCuisson = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recette", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recette_Categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorie",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Française" },
                    { 2, "Indienne" },
                    { 3, "Africaine" },
                    { 4, "Italienne" },
                    { 5, "Orientale" }
                });

            migrationBuilder.InsertData(
                table: "Recette",
                columns: new[] { "Id", "CategorieId", "Description", "Image", "Nom", "TempsCuisson", "TempsPreparation" },
                values: new object[,]
                {
                    { 1, 1, "Ragoût traditionnel français au boeuf et vin rouge.", "Boeuf_bourguignon.jpg", "Boeuf bourguignon", 180, 30 },
                    { 2, 1, "Tarte salée avec bacon, oeufs et fromage.", "Quiche_loraine.jpg", "Quiche lorraine", 45, 20 },
                    { 3, 2, "Poulet mariné dans une sauce crémeuse épicée.", "Poulet_tikka_masala.jpg", "Poulet tikka masala", 35, 40 },
                    { 4, 2, "Poulet tendre dans une sauce tomate et beurre.", "Poulet_au_beurre.jpg", "Poulet au beurre", 40, 25 },
                    { 5, 3, "Poulet mariné au citron et aux oignons.", "Poulet_Yassa.jpg", "Poulet yassa", 50, 35 },
                    { 6, 3, "accompagnement traditionnel en Afrique du Sud.", "Riz_jaune.jpg", "Riz jaune", 25, 10 },
                    { 7, 4, "Pâtes gratinées avec viande et sauce tomate.", "Lasagne.jpg", "Lasagne", 60, 45 },
                    { 8, 4, "Riz crémeux italien aux champignons.", "Risotto_Champignons.jpg", "Risotto aux champignons", 35, 15 },
                    { 9, 5, "Semoule servie avec légumes et viandes variées.", "Couscous_royal.jpg", "Couscous yoyal", 90, 40 },
                    { 10, 5, "Viande marinée grillée servie dans un pain pita.", "Shawarma.jpg", "Shawarma", 30, 25 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recette_CategorieId",
                table: "Recette",
                column: "CategorieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recette");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
