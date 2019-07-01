using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TCGCollector.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardCats",
                columns: table => new
                {
                    CardCatID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CardCatName = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardCats", x => x.CardCatID);
                });

            migrationBuilder.CreateTable(
                name: "CardTypes",
                columns: table => new
                {
                    CardTypeID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CardTypeName = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTypes", x => x.CardTypeID);
                });

            migrationBuilder.CreateTable(
                name: "SetSeries",
                columns: table => new
                {
                    SetSeriesID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SetSeriesName = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetSeries", x => x.SetSeriesID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserLogin = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    SetID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SetName = table.Column<string>(nullable: true),
                    SetCode = table.Column<string>(nullable: true),
                    SetPTCGOCode = table.Column<string>(nullable: true),
                    SetSeriesID = table.Column<int>(nullable: true),
                    SetTotalCards = table.Column<int>(nullable: false),
                    SetStandard = table.Column<bool>(nullable: false),
                    SetExpanded = table.Column<bool>(nullable: false),
                    SetSymbolURL = table.Column<string>(nullable: true),
                    SetLogoURL = table.Column<string>(nullable: true),
                    SetReleaseDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.SetID);
                    table.ForeignKey(
                        name: "FK_Sets_SetSeries_SetSeriesID",
                        column: x => x.SetSeriesID,
                        principalTable: "SetSeries",
                        principalColumn: "SetSeriesID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CardName = table.Column<string>(nullable: true),
                    CardImageURL = table.Column<string>(nullable: true),
                    CardImageHiURL = table.Column<string>(nullable: true),
                    CardCatID = table.Column<int>(nullable: true),
                    CardTypeID = table.Column<int>(nullable: true),
                    SetID = table.Column<int>(nullable: true),
                    CardNum = table.Column<int>(nullable: false),
                    Artist = table.Column<string>(nullable: true),
                    CardRarity = table.Column<string>(nullable: true),
                    SetReleaseDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardID);
                    table.ForeignKey(
                        name: "FK_Cards_CardCats_CardCatID",
                        column: x => x.CardCatID,
                        principalTable: "CardCats",
                        principalColumn: "CardCatID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_CardTypes_CardTypeID",
                        column: x => x.CardTypeID,
                        principalTable: "CardTypes",
                        principalColumn: "CardTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_Sets_SetID",
                        column: x => x.SetID,
                        principalTable: "Sets",
                        principalColumn: "SetID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CardCatID",
                table: "Cards",
                column: "CardCatID");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CardTypeID",
                table: "Cards",
                column: "CardTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_SetID",
                table: "Cards",
                column: "SetID");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_SetSeriesID",
                table: "Sets",
                column: "SetSeriesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CardCats");

            migrationBuilder.DropTable(
                name: "CardTypes");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "SetSeries");
        }
    }
}
