using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TCGCollector.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    AbilityID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AbilityName = table.Column<string>(nullable: true),
                    AbilityText = table.Column<string>(maxLength: 1024, nullable: true),
                    AbilityType = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.AbilityID);
                });

            migrationBuilder.CreateTable(
                name: "Attacks",
                columns: table => new
                {
                    AttackID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttackName = table.Column<string>(nullable: true),
                    AttackConvertedEnergyCost = table.Column<int>(nullable: false),
                    AttackDamage = table.Column<string>(nullable: true),
                    AttackText = table.Column<string>(maxLength: 1024, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attacks", x => x.AttackID);
                });

            migrationBuilder.CreateTable(
                name: "CardCats",
                columns: table => new
                {
                    CardCatID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardCatName = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardCats", x => x.CardCatID);
                });

            migrationBuilder.CreateTable(
                name: "CardCollections",
                columns: table => new
                {
                    CardCollectionID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardCollectionName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardCollections", x => x.CardCollectionID);
                });

            migrationBuilder.CreateTable(
                name: "CardRarities",
                columns: table => new
                {
                    CardRarityID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardTypeName = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTypes", x => x.CardTypeID);
                });

            migrationBuilder.CreateTable(
                name: "EnergyTypes",
                columns: table => new
                {
                    EnergyTypeID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnergyTypeName = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyTypes", x => x.EnergyTypeID);
                });

            migrationBuilder.CreateTable(
                name: "EvolvesTos",
                columns: table => new
                {
                    EvolvesToID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EvolvesToName = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvolvesTos", x => x.EvolvesToID);
                });

            migrationBuilder.CreateTable(
                name: "MagicBlocks",
                columns: table => new
                {
                    MagicBlockID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MagicBlockName = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicBlocks", x => x.MagicBlockID);
                });

            migrationBuilder.CreateTable(
                name: "MagicSetTypes",
                columns: table => new
                {
                    MagicSetTypeID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MagicSetTypeName = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicSetTypes", x => x.MagicSetTypeID);
                });

            migrationBuilder.CreateTable(
                name: "PokemonTypes",
                columns: table => new
                {
                    PokemonTypeID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardTextLine = table.Column<string>(maxLength: 1024, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialCardTexts", x => x.SpecialCardTextID);
                });

            migrationBuilder.CreateTable(
                name: "TrainerCardTexts",
                columns: table => new
                {
                    TrainerCardTextID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardTextLine = table.Column<string>(maxLength: 1024, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerCardTexts", x => x.TrainerCardTextID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                name: "AttackEnergies",
                columns: table => new
                {
                    AttackEnergyID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttackID = table.Column<int>(nullable: false),
                    EnergyTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackEnergies", x => x.AttackEnergyID);
                    table.ForeignKey(
                        name: "FK_AttackEnergies_Attacks_AttackID",
                        column: x => x.AttackID,
                        principalTable: "Attacks",
                        principalColumn: "AttackID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttackEnergies_EnergyTypes_EnergyTypeID",
                        column: x => x.EnergyTypeID,
                        principalTable: "EnergyTypes",
                        principalColumn: "EnergyTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resistances",
                columns: table => new
                {
                    ResistanceID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnergyTypeID = table.Column<int>(nullable: false),
                    ResistanceValue = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resistances", x => x.ResistanceID);
                    table.ForeignKey(
                        name: "FK_Resistances_EnergyTypes_EnergyTypeID",
                        column: x => x.EnergyTypeID,
                        principalTable: "EnergyTypes",
                        principalColumn: "EnergyTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weaknesses",
                columns: table => new
                {
                    WeaknessID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnergyTypeID = table.Column<int>(nullable: false),
                    WeaknessValue = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weaknesses", x => x.WeaknessID);
                    table.ForeignKey(
                        name: "FK_Weaknesses_EnergyTypes_EnergyTypeID",
                        column: x => x.EnergyTypeID,
                        principalTable: "EnergyTypes",
                        principalColumn: "EnergyTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MagicSets",
                columns: table => new
                {
                    MagicSetID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MagicSetName = table.Column<string>(nullable: true),
                    MagicSetCode = table.Column<string>(nullable: true),
                    MagicSetCodeAlt = table.Column<string>(nullable: true),
                    MagicSetUSAOnly = table.Column<bool>(nullable: false),
                    MagicSetFoilOnly = table.Column<bool>(nullable: false),
                    MagicSetOnlineOnly = table.Column<bool>(nullable: false),
                    MagicSetKeyruneCode = table.Column<string>(nullable: true),
                    MTGOCode = table.Column<string>(nullable: true),
                    MagicParentSetCode = table.Column<string>(nullable: true),
                    MagicSetSetSize = table.Column<int>(nullable: false),
                    MagicSetTotalSize = table.Column<int>(nullable: false),
                    MagicSetReleaseDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    MagicBlockID = table.Column<int>(nullable: true),
                    MagicSetTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicSets", x => x.MagicSetID);
                    table.ForeignKey(
                        name: "FK_MagicSets_MagicBlocks_MagicBlockID",
                        column: x => x.MagicBlockID,
                        principalTable: "MagicBlocks",
                        principalColumn: "MagicBlockID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MagicSets_MagicSetTypes_MagicSetTypeID",
                        column: x => x.MagicSetTypeID,
                        principalTable: "MagicSetTypes",
                        principalColumn: "MagicSetTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    SetID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SetName = table.Column<string>(nullable: true),
                    SetCode = table.Column<string>(nullable: true),
                    SetPTCGOCode = table.Column<string>(nullable: true),
                    SetSeriesID = table.Column<int>(nullable: true),
                    SetTotalCards = table.Column<int>(nullable: false),
                    SetStandard = table.Column<bool>(nullable: false),
                    SetExpanded = table.Column<bool>(nullable: false),
                    SetSymbolURL = table.Column<string>(nullable: true),
                    SetLogoURL = table.Column<string>(nullable: true),
                    SetSymbolLocalURL = table.Column<string>(nullable: true),
                    SetLogoLocalURL = table.Column<string>(nullable: true),
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
                        name: "FK_UserCardCollection_CardCollections_CardCollectionID",
                        column: x => x.CardCollectionID,
                        principalTable: "CardCollections",
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
                name: "MagicCards",
                columns: table => new
                {
                    MagicCardID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MagicCardName = table.Column<string>(nullable: true),
                    MagicSetID = table.Column<int>(nullable: true),
                    MagicCardHasFoil = table.Column<bool>(nullable: false),
                    MagicCardHasNonFoil = table.Column<bool>(nullable: false),
                    MagicCardHasAltArt = table.Column<bool>(nullable: false),
                    MagicCardIsArena = table.Column<bool>(nullable: false),
                    MagicCardIsFullArt = table.Column<bool>(nullable: false),
                    MagicCardIsMTGO = table.Column<bool>(nullable: false),
                    MagicCardIsOnlineOnly = table.Column<bool>(nullable: false),
                    MagicCardIsOversized = table.Column<bool>(nullable: false),
                    MagicCardIsPaper = table.Column<bool>(nullable: false),
                    MagicCardIsPromo = table.Column<bool>(nullable: false),
                    MagicCardIsReprint = table.Column<bool>(nullable: false),
                    MagicCardIsReserved = table.Column<bool>(nullable: false),
                    MagicCardIsStarter = table.Column<bool>(nullable: false),
                    MagicCardIsStorySpotlight = table.Column<bool>(nullable: false),
                    MagicCardIsTextless = table.Column<bool>(nullable: false),
                    MagicCardIsTimeshifted = table.Column<bool>(nullable: false),
                    MagicCardNum = table.Column<string>(nullable: true),
                    MagicCardArtist = table.Column<string>(nullable: true),
                    MagicCardText = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicCards", x => x.MagicCardID);
                    table.ForeignKey(
                        name: "FK_MagicCards_MagicSets_MagicSetID",
                        column: x => x.MagicSetID,
                        principalTable: "MagicSets",
                        principalColumn: "MagicSetID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardName = table.Column<string>(nullable: true),
                    CardImageURL = table.Column<string>(nullable: true),
                    CardImageHiURL = table.Column<string>(nullable: true),
                    CardImageLocalURL = table.Column<string>(nullable: true),
                    CardImageHiLocalURL = table.Column<string>(nullable: true),
                    CardCatID = table.Column<int>(nullable: true),
                    CardTypeID = table.Column<int>(nullable: true),
                    SetID = table.Column<int>(nullable: true),
                    CardNum = table.Column<string>(nullable: true),
                    Artist = table.Column<string>(nullable: true),
                    CardRarityID = table.Column<int>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    HP = table.Column<int>(nullable: true),
                    ConvertedRetreatCost = table.Column<int>(nullable: true),
                    NationalPokedexNumber = table.Column<int>(nullable: true),
                    EvolvesFrom = table.Column<string>(nullable: true)
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
                name: "PokemonCardAbilities",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false),
                    AbilityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCardAbilities", x => new { x.CardID, x.AbilityID });
                    table.ForeignKey(
                        name: "FK_PokemonCardAbilities_Abilities_AbilityID",
                        column: x => x.AbilityID,
                        principalTable: "Abilities",
                        principalColumn: "AbilityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonCardAbilities_Cards_CardID",
                        column: x => x.CardID,
                        principalTable: "Cards",
                        principalColumn: "CardID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonCardAttacks",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false),
                    AttackID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCardAttacks", x => new { x.CardID, x.AttackID });
                    table.ForeignKey(
                        name: "FK_PokemonCardAttacks_Attacks_AttackID",
                        column: x => x.AttackID,
                        principalTable: "Attacks",
                        principalColumn: "AttackID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonCardAttacks_Cards_CardID",
                        column: x => x.CardID,
                        principalTable: "Cards",
                        principalColumn: "CardID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonCardEvolvesTos",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false),
                    EvolvesToID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCardEvolvesTos", x => new { x.CardID, x.EvolvesToID });
                    table.ForeignKey(
                        name: "FK_PokemonCardEvolvesTos_Cards_CardID",
                        column: x => x.CardID,
                        principalTable: "Cards",
                        principalColumn: "CardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonCardEvolvesTos_EvolvesTos_EvolvesToID",
                        column: x => x.EvolvesToID,
                        principalTable: "EvolvesTos",
                        principalColumn: "EvolvesToID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonCardPokemonTypes",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false),
                    PokemonTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCardPokemonTypes", x => new { x.CardID, x.PokemonTypeID });
                    table.ForeignKey(
                        name: "FK_PokemonCardPokemonTypes_Cards_CardID",
                        column: x => x.CardID,
                        principalTable: "Cards",
                        principalColumn: "CardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonCardPokemonTypes_PokemonTypes_PokemonTypeID",
                        column: x => x.PokemonTypeID,
                        principalTable: "PokemonTypes",
                        principalColumn: "PokemonTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonCardResistances",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false),
                    ResistanceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCardResistances", x => new { x.CardID, x.ResistanceID });
                    table.ForeignKey(
                        name: "FK_PokemonCardResistances_Cards_CardID",
                        column: x => x.CardID,
                        principalTable: "Cards",
                        principalColumn: "CardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonCardResistances_Resistances_ResistanceID",
                        column: x => x.ResistanceID,
                        principalTable: "Resistances",
                        principalColumn: "ResistanceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonCardRetreatCosts",
                columns: table => new
                {
                    PokemonCardRetreatCostID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardID = table.Column<int>(nullable: false),
                    PokemonCardCardID = table.Column<int>(nullable: true),
                    EnergyTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCardRetreatCosts", x => x.PokemonCardRetreatCostID);
                    table.ForeignKey(
                        name: "FK_PokemonCardRetreatCosts_EnergyTypes_EnergyTypeID",
                        column: x => x.EnergyTypeID,
                        principalTable: "EnergyTypes",
                        principalColumn: "EnergyTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonCardRetreatCosts_Cards_PokemonCardCardID",
                        column: x => x.PokemonCardCardID,
                        principalTable: "Cards",
                        principalColumn: "CardID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PokemonCardWeaknesses",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false),
                    WeaknessID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCardWeaknesses", x => new { x.CardID, x.WeaknessID });
                    table.ForeignKey(
                        name: "FK_PokemonCardWeaknesses_Cards_CardID",
                        column: x => x.CardID,
                        principalTable: "Cards",
                        principalColumn: "CardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonCardWeaknesses_Weaknesses_WeaknessID",
                        column: x => x.WeaknessID,
                        principalTable: "Weaknesses",
                        principalColumn: "WeaknessID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialCardSpecialCardTexts",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false),
                    CardTextID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialCardSpecialCardTexts", x => new { x.CardID, x.CardTextID });
                    table.ForeignKey(
                        name: "FK_SpecialCardSpecialCardTexts_Cards_CardID",
                        column: x => x.CardID,
                        principalTable: "Cards",
                        principalColumn: "CardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialCardSpecialCardTexts_SpecialCardTexts_CardTextID",
                        column: x => x.CardTextID,
                        principalTable: "SpecialCardTexts",
                        principalColumn: "SpecialCardTextID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainerCardTrainerCardTexts",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false),
                    CardTextID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerCardTrainerCardTexts", x => new { x.CardID, x.CardTextID });
                    table.ForeignKey(
                        name: "FK_TrainerCardTrainerCardTexts_Cards_CardID",
                        column: x => x.CardID,
                        principalTable: "Cards",
                        principalColumn: "CardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerCardTrainerCardTexts_TrainerCardTexts_CardTextID",
                        column: x => x.CardTextID,
                        principalTable: "TrainerCardTexts",
                        principalColumn: "TrainerCardTextID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttackEnergies_AttackID",
                table: "AttackEnergies",
                column: "AttackID");

            migrationBuilder.CreateIndex(
                name: "IX_AttackEnergies_EnergyTypeID",
                table: "AttackEnergies",
                column: "EnergyTypeID");

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
                name: "IX_MagicCards_MagicSetID",
                table: "MagicCards",
                column: "MagicSetID");

            migrationBuilder.CreateIndex(
                name: "IX_MagicSets_MagicBlockID",
                table: "MagicSets",
                column: "MagicBlockID");

            migrationBuilder.CreateIndex(
                name: "IX_MagicSets_MagicSetTypeID",
                table: "MagicSets",
                column: "MagicSetTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCardAbilities_AbilityID",
                table: "PokemonCardAbilities",
                column: "AbilityID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCardAttacks_AttackID",
                table: "PokemonCardAttacks",
                column: "AttackID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCardEvolvesTos_EvolvesToID",
                table: "PokemonCardEvolvesTos",
                column: "EvolvesToID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCardPokemonTypes_PokemonTypeID",
                table: "PokemonCardPokemonTypes",
                column: "PokemonTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCardResistances_ResistanceID",
                table: "PokemonCardResistances",
                column: "ResistanceID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCardRetreatCosts_EnergyTypeID",
                table: "PokemonCardRetreatCosts",
                column: "EnergyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCardRetreatCosts_PokemonCardCardID",
                table: "PokemonCardRetreatCosts",
                column: "PokemonCardCardID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCardWeaknesses_WeaknessID",
                table: "PokemonCardWeaknesses",
                column: "WeaknessID");

            migrationBuilder.CreateIndex(
                name: "IX_Resistances_EnergyTypeID",
                table: "Resistances",
                column: "EnergyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_SetSeriesID",
                table: "Sets",
                column: "SetSeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialCardSpecialCardTexts_CardTextID",
                table: "SpecialCardSpecialCardTexts",
                column: "CardTextID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerCardTrainerCardTexts_CardTextID",
                table: "TrainerCardTrainerCardTexts",
                column: "CardTextID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCardCollection_CardCollectionID",
                table: "UserCardCollection",
                column: "CardCollectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Weaknesses_EnergyTypeID",
                table: "Weaknesses",
                column: "EnergyTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttackEnergies");

            migrationBuilder.DropTable(
                name: "MagicCards");

            migrationBuilder.DropTable(
                name: "PokemonCardAbilities");

            migrationBuilder.DropTable(
                name: "PokemonCardAttacks");

            migrationBuilder.DropTable(
                name: "PokemonCardEvolvesTos");

            migrationBuilder.DropTable(
                name: "PokemonCardPokemonTypes");

            migrationBuilder.DropTable(
                name: "PokemonCardResistances");

            migrationBuilder.DropTable(
                name: "PokemonCardRetreatCosts");

            migrationBuilder.DropTable(
                name: "PokemonCardWeaknesses");

            migrationBuilder.DropTable(
                name: "SpecialCardSpecialCardTexts");

            migrationBuilder.DropTable(
                name: "TrainerCardTrainerCardTexts");

            migrationBuilder.DropTable(
                name: "UserCardCollection");

            migrationBuilder.DropTable(
                name: "MagicSets");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Attacks");

            migrationBuilder.DropTable(
                name: "EvolvesTos");

            migrationBuilder.DropTable(
                name: "PokemonTypes");

            migrationBuilder.DropTable(
                name: "Resistances");

            migrationBuilder.DropTable(
                name: "Weaknesses");

            migrationBuilder.DropTable(
                name: "SpecialCardTexts");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "TrainerCardTexts");

            migrationBuilder.DropTable(
                name: "CardCollections");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MagicBlocks");

            migrationBuilder.DropTable(
                name: "MagicSetTypes");

            migrationBuilder.DropTable(
                name: "EnergyTypes");

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
