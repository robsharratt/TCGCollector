using Microsoft.EntityFrameworkCore.Migrations;

namespace TCGCollector.Migrations
{
    public partial class SpecialCardCardText2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialCardText",
                table: "Cards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpecialCardText",
                table: "Cards",
                maxLength: 1024,
                nullable: true);
        }
    }
}
