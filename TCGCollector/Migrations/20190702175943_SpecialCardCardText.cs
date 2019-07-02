using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TCGCollector.Migrations
{
    public partial class SpecialCardCardText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardText",
                columns: table => new
                {
                    CardTextID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CardTextLine = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardText", x => x.CardTextID);
                });

            migrationBuilder.CreateTable(
                name: "SpecialCardCardText",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false),
                    CardTextID = table.Column<int>(nullable: false),
                    CardTextID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialCardCardText", x => new { x.CardID, x.CardTextID });
                    table.ForeignKey(
                        name: "FK_SpecialCardCardText_Cards_CardTextID",
                        column: x => x.CardTextID,
                        principalTable: "Cards",
                        principalColumn: "CardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialCardCardText_CardText_CardTextID1",
                        column: x => x.CardTextID1,
                        principalTable: "CardText",
                        principalColumn: "CardTextID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecialCardCardText_CardTextID",
                table: "SpecialCardCardText",
                column: "CardTextID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialCardCardText_CardTextID1",
                table: "SpecialCardCardText",
                column: "CardTextID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecialCardCardText");

            migrationBuilder.DropTable(
                name: "CardText");
        }
    }
}
