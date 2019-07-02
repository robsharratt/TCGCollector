﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TCGCollector.Models;

namespace TCGCollector.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TCGCollector.Models.Card", b =>
                {
                    b.Property<int>("CardID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Artist");

                    b.Property<int?>("CardCatID");

                    b.Property<string>("CardImageHiURL");

                    b.Property<string>("CardImageURL");

                    b.Property<string>("CardName");

                    b.Property<int>("CardNum");

                    b.Property<int?>("CardRarityID");

                    b.Property<int?>("CardTypeID");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<int?>("SetID");

                    b.HasKey("CardID");

                    b.HasIndex("CardCatID");

                    b.HasIndex("CardRarityID");

                    b.HasIndex("CardTypeID");

                    b.HasIndex("SetID");

                    b.ToTable("Cards");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Card");
                });

            modelBuilder.Entity("TCGCollector.Models.CardCat", b =>
                {
                    b.Property<int>("CardCatID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CardCatName");

                    b.Property<DateTime>("LastUpdateDate");

                    b.HasKey("CardCatID");

                    b.ToTable("CardCats");
                });

            modelBuilder.Entity("TCGCollector.Models.CardCollection", b =>
                {
                    b.Property<int>("CardCollectionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CardCollectionName");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastUpdateDate");

                    b.HasKey("CardCollectionID");

                    b.ToTable("CardCollection");
                });

            modelBuilder.Entity("TCGCollector.Models.CardRarity", b =>
                {
                    b.Property<int>("CardRarityID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CardRarityName");

                    b.Property<DateTime>("LastUpdateDate");

                    b.HasKey("CardRarityID");

                    b.ToTable("CardRarities");
                });

            modelBuilder.Entity("TCGCollector.Models.CardText", b =>
                {
                    b.Property<int>("CardTextID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CardTextLine")
                        .HasMaxLength(1024);

                    b.Property<DateTime>("LastUpdateDate");

                    b.HasKey("CardTextID");

                    b.ToTable("CardTexts");
                });

            modelBuilder.Entity("TCGCollector.Models.CardType", b =>
                {
                    b.Property<int>("CardTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CardTypeName");

                    b.Property<DateTime>("LastUpdateDate");

                    b.HasKey("CardTypeID");

                    b.ToTable("CardTypes");
                });

            modelBuilder.Entity("TCGCollector.Models.PokemonType", b =>
                {
                    b.Property<int>("PokemonTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("PokemonTypeName");

                    b.HasKey("PokemonTypeID");

                    b.ToTable("PokemonTypes");
                });

            modelBuilder.Entity("TCGCollector.Models.Set", b =>
                {
                    b.Property<int>("SetID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("SetCode");

                    b.Property<bool>("SetExpanded");

                    b.Property<string>("SetLogoURL");

                    b.Property<string>("SetName");

                    b.Property<string>("SetPTCGOCode");

                    b.Property<DateTime>("SetReleaseDate");

                    b.Property<int?>("SetSeriesID");

                    b.Property<bool>("SetStandard");

                    b.Property<string>("SetSymbolURL");

                    b.Property<int>("SetTotalCards");

                    b.HasKey("SetID");

                    b.HasIndex("SetSeriesID");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("TCGCollector.Models.SetSeries", b =>
                {
                    b.Property<int>("SetSeriesID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("SetSeriesName");

                    b.HasKey("SetSeriesID");

                    b.ToTable("SetSeries");
                });

            modelBuilder.Entity("TCGCollector.Models.SpecialCardCardText", b =>
                {
                    b.Property<int>("CardID");

                    b.Property<int>("CardTextID");

                    b.HasKey("CardID", "CardTextID");

                    b.HasIndex("CardTextID");

                    b.ToTable("SpecialCardCardText");
                });

            modelBuilder.Entity("TCGCollector.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("Password");

                    b.Property<string>("UserLogin");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TCGCollector.Models.UserCardCollection", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<int>("CardCollectionID");

                    b.HasKey("UserID", "CardCollectionID");

                    b.HasIndex("CardCollectionID");

                    b.ToTable("UserCardCollection");
                });

            modelBuilder.Entity("TCGCollector.Models.SpecialCard", b =>
                {
                    b.HasBaseType("TCGCollector.Models.Card");

                    b.HasDiscriminator().HasValue("SpecialCard");
                });

            modelBuilder.Entity("TCGCollector.Models.TrainerCard", b =>
                {
                    b.HasBaseType("TCGCollector.Models.Card");

                    b.Property<string>("TrainerCardText")
                        .HasMaxLength(1024);

                    b.HasDiscriminator().HasValue("TrainerCard");
                });

            modelBuilder.Entity("TCGCollector.Models.Card", b =>
                {
                    b.HasOne("TCGCollector.Models.CardCat", "CardCat")
                        .WithMany("Cards")
                        .HasForeignKey("CardCatID");

                    b.HasOne("TCGCollector.Models.CardRarity", "CardRarity")
                        .WithMany("Cards")
                        .HasForeignKey("CardRarityID");

                    b.HasOne("TCGCollector.Models.CardType", "CardType")
                        .WithMany("Cards")
                        .HasForeignKey("CardTypeID");

                    b.HasOne("TCGCollector.Models.Set", "Set")
                        .WithMany("Cards")
                        .HasForeignKey("SetID");
                });

            modelBuilder.Entity("TCGCollector.Models.Set", b =>
                {
                    b.HasOne("TCGCollector.Models.SetSeries", "SetSeries")
                        .WithMany("Sets")
                        .HasForeignKey("SetSeriesID");
                });

            modelBuilder.Entity("TCGCollector.Models.SpecialCardCardText", b =>
                {
                    b.HasOne("TCGCollector.Models.SpecialCard", "SpecialCard")
                        .WithMany("SpecialCardCardTexts")
                        .HasForeignKey("CardID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TCGCollector.Models.CardText", "CardText")
                        .WithMany("SpecialCardCardTexts")
                        .HasForeignKey("CardTextID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TCGCollector.Models.UserCardCollection", b =>
                {
                    b.HasOne("TCGCollector.Models.CardCollection", "CardCollection")
                        .WithMany("UserCardCollections")
                        .HasForeignKey("CardCollectionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TCGCollector.Models.User", "User")
                        .WithMany("UserCardCollections")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
