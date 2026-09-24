using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriVie.Migrations
{
    /// <inheritdoc />
    public partial class ModificationRecette : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recettes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Nom",
                value: "Couscous Royal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recettes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Nom",
                value: "Couscous yoyal");
        }
    }
}
