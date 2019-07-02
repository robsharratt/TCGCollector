using Microsoft.EntityFrameworkCore.Migrations;

namespace TCGCollector.Migrations
{
    public partial class SpecialCardCardText3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialCardCardText_Cards_CardTextID",
                table: "SpecialCardCardText");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialCardCardText_CardText_CardTextID1",
                table: "SpecialCardCardText");

            migrationBuilder.DropIndex(
                name: "IX_SpecialCardCardText_CardTextID1",
                table: "SpecialCardCardText");

            migrationBuilder.DropColumn(
                name: "CardTextID1",
                table: "SpecialCardCardText");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialCardCardText_Cards_CardID",
                table: "SpecialCardCardText",
                column: "CardID",
                principalTable: "Cards",
                principalColumn: "CardID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialCardCardText_CardText_CardTextID",
                table: "SpecialCardCardText",
                column: "CardTextID",
                principalTable: "CardText",
                principalColumn: "CardTextID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialCardCardText_Cards_CardID",
                table: "SpecialCardCardText");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialCardCardText_CardText_CardTextID",
                table: "SpecialCardCardText");

            migrationBuilder.AddColumn<int>(
                name: "CardTextID1",
                table: "SpecialCardCardText",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialCardCardText_CardTextID1",
                table: "SpecialCardCardText",
                column: "CardTextID1");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialCardCardText_Cards_CardTextID",
                table: "SpecialCardCardText",
                column: "CardTextID",
                principalTable: "Cards",
                principalColumn: "CardID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialCardCardText_CardText_CardTextID1",
                table: "SpecialCardCardText",
                column: "CardTextID1",
                principalTable: "CardText",
                principalColumn: "CardTextID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
