using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TCGCollector.Migrations
{
    public partial class Resistance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resistance",
                columns: table => new
                {
                    ResistanceID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EnergyTypeID = table.Column<int>(nullable: false),
                    ResistanceValue = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resistance", x => x.ResistanceID);
                    table.ForeignKey(
                        name: "FK_Resistance_EnergyTypes_EnergyTypeID",
                        column: x => x.EnergyTypeID,
                        principalTable: "EnergyTypes",
                        principalColumn: "EnergyTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonCardResistances",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false),
                    ResistanceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCardResistances", x => new { x.CardID, x.ResistanceID });
                    table.ForeignKey(
                        name: "FK_PokemonCardResistances_Cards_CardID",
                        column: x => x.CardID,
                        principalTable: "Cards",
                        principalColumn: "CardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonCardResistances_Resistance_ResistanceID",
                        column: x => x.ResistanceID,
                        principalTable: "Resistance",
                        principalColumn: "ResistanceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCardResistances_ResistanceID",
                table: "PokemonCardResistances",
                column: "ResistanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Resistance_EnergyTypeID",
                table: "Resistance",
                column: "EnergyTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonCardResistances");

            migrationBuilder.DropTable(
                name: "Resistance");
        }
    }
}
