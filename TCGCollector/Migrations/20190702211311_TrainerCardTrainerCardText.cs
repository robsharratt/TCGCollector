using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TCGCollector.Migrations
{
    public partial class TrainerCardTrainerCardText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCardCollection_CardCollection_CardCollectionID",
                table: "UserCardCollection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardCollection",
                table: "CardCollection");

            migrationBuilder.DropColumn(
                name: "TrainerCardText",
                table: "Cards");

            migrationBuilder.RenameTable(
                name: "CardCollection",
                newName: "CardCollections");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardCollections",
                table: "CardCollections",
                column: "CardCollectionID");

            migrationBuilder.CreateTable(
                name: "TrainerCardTexts",
                columns: table => new
                {
                    TrainerCardTextID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CardTextLine = table.Column<string>(maxLength: 1024, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerCardTexts", x => x.TrainerCardTextID);
                });

            migrationBuilder.CreateTable(
                name: "TrainerCardTrainerCardText",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false),
                    CardTextID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerCardTrainerCardText", x => new { x.CardID, x.CardTextID });
                    table.ForeignKey(
                        name: "FK_TrainerCardTrainerCardText_Cards_CardID",
                        column: x => x.CardID,
                        principalTable: "Cards",
                        principalColumn: "CardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerCardTrainerCardText_TrainerCardTexts_CardTextID",
                        column: x => x.CardTextID,
                        principalTable: "TrainerCardTexts",
                        principalColumn: "TrainerCardTextID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainerCardTrainerCardText_CardTextID",
                table: "TrainerCardTrainerCardText",
                column: "CardTextID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCardCollection_CardCollections_CardCollectionID",
                table: "UserCardCollection",
                column: "CardCollectionID",
                principalTable: "CardCollections",
                principalColumn: "CardCollectionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCardCollection_CardCollections_CardCollectionID",
                table: "UserCardCollection");

            migrationBuilder.DropTable(
                name: "TrainerCardTrainerCardText");

            migrationBuilder.DropTable(
                name: "TrainerCardTexts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardCollections",
                table: "CardCollections");

            migrationBuilder.RenameTable(
                name: "CardCollections",
                newName: "CardCollection");

            migrationBuilder.AddColumn<string>(
                name: "TrainerCardText",
                table: "Cards",
                maxLength: 1024,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardCollection",
                table: "CardCollection",
                column: "CardCollectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCardCollection_CardCollection_CardCollectionID",
                table: "UserCardCollection",
                column: "CardCollectionID",
                principalTable: "CardCollection",
                principalColumn: "CardCollectionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
