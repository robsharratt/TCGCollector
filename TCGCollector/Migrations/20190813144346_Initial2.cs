using Microsoft.EntityFrameworkCore.Migrations;

namespace TCGCollector.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MagicCards_CardCats_CardCatID",
                table: "MagicCards");

            migrationBuilder.DropForeignKey(
                name: "FK_MagicCards_CardRarities_CardRarityID",
                table: "MagicCards");

            migrationBuilder.DropForeignKey(
                name: "FK_MagicCards_CardTypes_CardTypeID",
                table: "MagicCards");

            migrationBuilder.DropIndex(
                name: "IX_MagicCards_CardCatID",
                table: "MagicCards");

            migrationBuilder.DropIndex(
                name: "IX_MagicCards_CardRarityID",
                table: "MagicCards");

            migrationBuilder.DropIndex(
                name: "IX_MagicCards_CardTypeID",
                table: "MagicCards");

            migrationBuilder.DropColumn(
                name: "CardCatID",
                table: "MagicCards");

            migrationBuilder.DropColumn(
                name: "CardRarityID",
                table: "MagicCards");

            migrationBuilder.DropColumn(
                name: "CardTypeID",
                table: "MagicCards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardCatID",
                table: "MagicCards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CardRarityID",
                table: "MagicCards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CardTypeID",
                table: "MagicCards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MagicCards_CardCatID",
                table: "MagicCards",
                column: "CardCatID");

            migrationBuilder.CreateIndex(
                name: "IX_MagicCards_CardRarityID",
                table: "MagicCards",
                column: "CardRarityID");

            migrationBuilder.CreateIndex(
                name: "IX_MagicCards_CardTypeID",
                table: "MagicCards",
                column: "CardTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_MagicCards_CardCats_CardCatID",
                table: "MagicCards",
                column: "CardCatID",
                principalTable: "CardCats",
                principalColumn: "CardCatID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MagicCards_CardRarities_CardRarityID",
                table: "MagicCards",
                column: "CardRarityID",
                principalTable: "CardRarities",
                principalColumn: "CardRarityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MagicCards_CardTypes_CardTypeID",
                table: "MagicCards",
                column: "CardTypeID",
                principalTable: "CardTypes",
                principalColumn: "CardTypeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
