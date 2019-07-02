using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCGCollector.Migrations
{
    public partial class SpecialCardCardText4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialCardCardText_CardText_CardTextID",
                table: "SpecialCardCardText");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardText",
                table: "CardText");

            migrationBuilder.RenameTable(
                name: "CardText",
                newName: "CardTexts");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "CardTexts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardTexts",
                table: "CardTexts",
                column: "CardTextID");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialCardCardText_CardTexts_CardTextID",
                table: "SpecialCardCardText",
                column: "CardTextID",
                principalTable: "CardTexts",
                principalColumn: "CardTextID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialCardCardText_CardTexts_CardTextID",
                table: "SpecialCardCardText");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardTexts",
                table: "CardTexts");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "CardTexts");

            migrationBuilder.RenameTable(
                name: "CardTexts",
                newName: "CardText");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardText",
                table: "CardText",
                column: "CardTextID");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialCardCardText_CardText_CardTextID",
                table: "SpecialCardCardText",
                column: "CardTextID",
                principalTable: "CardText",
                principalColumn: "CardTextID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
