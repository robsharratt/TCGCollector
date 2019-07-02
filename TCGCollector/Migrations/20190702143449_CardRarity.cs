using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TCGCollector.Migrations
{
    public partial class CardRarity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardRarity",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "CardRarityID",
                table: "Cards",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CardRarities",
                columns: table => new
                {
                    CardRarityID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CardRarityName = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardRarities", x => x.CardRarityID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CardRarityID",
                table: "Cards",
                column: "CardRarityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_CardRarities_CardRarityID",
                table: "Cards",
                column: "CardRarityID",
                principalTable: "CardRarities",
                principalColumn: "CardRarityID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_CardRarities_CardRarityID",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "CardRarities");

            migrationBuilder.DropIndex(
                name: "IX_Cards_CardRarityID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardRarityID",
                table: "Cards");

            migrationBuilder.AddColumn<string>(
                name: "CardRarity",
                table: "Cards",
                nullable: true);
        }
    }
}
