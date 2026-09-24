using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriVie.Migrations
{
    /// <inheritdoc />
    public partial class AjoutSeedRecetteCategorieV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recette_Categorie_CategorieId",
                table: "Recette");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recette",
                table: "Recette");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie");

            migrationBuilder.RenameTable(
                name: "Recette",
                newName: "Recettes");

            migrationBuilder.RenameTable(
                name: "Categorie",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Recette_CategorieId",
                table: "Recettes",
                newName: "IX_Recettes_CategorieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recettes",
                table: "Recettes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recettes_Categories_CategorieId",
                table: "Recettes",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recettes_Categories_CategorieId",
                table: "Recettes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recettes",
                table: "Recettes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Recettes",
                newName: "Recette");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categorie");

            migrationBuilder.RenameIndex(
                name: "IX_Recettes_CategorieId",
                table: "Recette",
                newName: "IX_Recette_CategorieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recette",
                table: "Recette",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recette_Categorie_CategorieId",
                table: "Recette",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
