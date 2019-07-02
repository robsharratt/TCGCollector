using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TCGCollector.Migrations
{
    public partial class Initial : Migration
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
                name: "PokemonTypes",
                columns: table => new
                {
                    PokemonTypeID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PokemonTypeName = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTypes", x => x.PokemonTypeID);
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
                name: "SpecialCardTexts",
                columns: table => new
                {
                    SpecialCardTextID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CardTextLine = table.Column<string>(maxLength: 1024, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialCardTexts", x => x.SpecialCardTextID);
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
                    CardRarityID = table.Column<int>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    TrainerCardText = table.Column<string>(maxLength: 1024, nullable: true)
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
                        name: "FK_Cards_CardRarities_CardRarityID",
                        column: x => x.CardRarityID,
                        principalTable: "CardRarities",
                        principalColumn: "CardRarityID",
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

            migrationBuilder.CreateTable(
                name: "SpecialCardSpecialCardText",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false),
                    CardTextID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialCardSpecialCardText", x => new { x.CardID, x.CardTextID });
                    table.ForeignKey(
                        name: "FK_SpecialCardSpecialCardText_Cards_CardID",
                        column: x => x.CardID,
                        principalTable: "Cards",
                        principalColumn: "CardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialCardSpecialCardText_SpecialCardTexts_CardTextID",
                        column: x => x.CardTextID,
                        principalTable: "SpecialCardTexts",
                        principalColumn: "SpecialCardTextID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CardCatID",
                table: "Cards",
                column: "CardCatID");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CardRarityID",
                table: "Cards",
                column: "CardRarityID");

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

            migrationBuilder.CreateIndex(
                name: "IX_SpecialCardSpecialCardText_CardTextID",
                table: "SpecialCardSpecialCardText",
                column: "CardTextID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCardCollection_CardCollectionID",
                table: "UserCardCollection",
                column: "CardCollectionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonTypes");

            migrationBuilder.DropTable(
                name: "SpecialCardSpecialCardText");

            migrationBuilder.DropTable(
                name: "UserCardCollection");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "SpecialCardTexts");

            migrationBuilder.DropTable(
                name: "CardCollection");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CardCats");

            migrationBuilder.DropTable(
                name: "CardRarities");

            migrationBuilder.DropTable(
                name: "CardTypes");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "SetSeries");
        }
    }
}
