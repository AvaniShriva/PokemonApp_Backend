using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonTypes_Pokemons_PokemonTableId",
                table: "PokemonTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonTypes_TypeTables_TypeTableId",
                table: "PokemonTypes");

            migrationBuilder.RenameColumn(
                name: "TypeTableId",
                table: "PokemonTypes",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "PokemonTableId",
                table: "PokemonTypes",
                newName: "PokemonId");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonTypes_TypeTableId",
                table: "PokemonTypes",
                newName: "IX_PokemonTypes_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonTypes_PokemonTableId",
                table: "PokemonTypes",
                newName: "IX_PokemonTypes_PokemonId");

            migrationBuilder.InsertData(
                table: "TypeTables",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 1, "Fire" },
                    { 2, "Water" },
                    { 3, "Fire" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonTypes_Pokemons_PokemonId",
                table: "PokemonTypes",
                column: "PokemonId",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonTypes_TypeTables_TypeId",
                table: "PokemonTypes",
                column: "TypeId",
                principalTable: "TypeTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonTypes_Pokemons_PokemonId",
                table: "PokemonTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonTypes_TypeTables_TypeId",
                table: "PokemonTypes");

            migrationBuilder.DeleteData(
                table: "TypeTables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TypeTables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TypeTables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "PokemonTypes",
                newName: "TypeTableId");

            migrationBuilder.RenameColumn(
                name: "PokemonId",
                table: "PokemonTypes",
                newName: "PokemonTableId");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonTypes_TypeId",
                table: "PokemonTypes",
                newName: "IX_PokemonTypes_TypeTableId");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonTypes_PokemonId",
                table: "PokemonTypes",
                newName: "IX_PokemonTypes_PokemonTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonTypes_Pokemons_PokemonTableId",
                table: "PokemonTypes",
                column: "PokemonTableId",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonTypes_TypeTables_TypeTableId",
                table: "PokemonTypes",
                column: "TypeTableId",
                principalTable: "TypeTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
