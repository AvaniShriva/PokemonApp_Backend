using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemon_Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon_Tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type_Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon_Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeTableId = table.Column<int>(type: "int", nullable: false),
                    PokemonTableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon_Types", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemon_Types_Pokemon_Tables_PokemonTableId",
                        column: x => x.PokemonTableId,
                        principalTable: "Pokemon_Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pokemon_Types_Type_Tables_TypeTableId",
                        column: x => x.TypeTableId,
                        principalTable: "Type_Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_Types_PokemonTableId",
                table: "Pokemon_Types",
                column: "PokemonTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_Types_TypeTableId",
                table: "Pokemon_Types",
                column: "TypeTableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemon_Types");

            migrationBuilder.DropTable(
                name: "Pokemon_Tables");

            migrationBuilder.DropTable(
                name: "Type_Tables");
        }
    }
}
