using Microsoft.EntityFrameworkCore.Migrations;

namespace TCGCollector.Migrations
{
    public partial class UpdatedCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CardNum",
                table: "Cards",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CardNum",
                table: "Cards",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
