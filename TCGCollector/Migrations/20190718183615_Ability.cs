using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TCGCollector.Migrations
{
    public partial class Ability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    AbilityID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AbilityName = table.Column<string>(nullable: true),
                    AbilityText = table.Column<string>(maxLength: 1024, nullable: true),
                    AbilityType = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.AbilityID);
                });

            migrationBuilder.CreateTable(
                name: "PokemonCardAbilities",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false),
                    AbilityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCardAbilities", x => new { x.CardID, x.AbilityID });
                    table.ForeignKey(
                        name: "FK_PokemonCardAbilities_Abilities_AbilityID",
                        column: x => x.AbilityID,
                        principalTable: "Abilities",
                        principalColumn: "AbilityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonCardAbilities_Cards_CardID",
                        column: x => x.CardID,
                        principalTable: "Cards",
                        principalColumn: "CardID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCardAbilities_AbilityID",
                table: "PokemonCardAbilities",
                column: "AbilityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonCardAbilities");

            migrationBuilder.DropTable(
                name: "Abilities");
        }
    }
}
