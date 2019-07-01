using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TCGCollector.Migrations
{
    public partial class UserCardCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardCollection",
                columns: table => new
                {
                    CardCollectionID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CardCollectionName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardCollection", x => x.CardCollectionID);
                });

            migrationBuilder.CreateTable(
                name: "UserCardCollection",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    CardCollectionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCardCollection", x => new { x.UserID, x.CardCollectionID });
                    table.ForeignKey(
                        name: "FK_UserCardCollection_CardCollection_CardCollectionID",
                        column: x => x.CardCollectionID,
                        principalTable: "CardCollection",
                        principalColumn: "CardCollectionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCardCollection_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCardCollection_CardCollectionID",
                table: "UserCardCollection",
                column: "CardCollectionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCardCollection");

            migrationBuilder.DropTable(
                name: "CardCollection");
        }
    }
}
