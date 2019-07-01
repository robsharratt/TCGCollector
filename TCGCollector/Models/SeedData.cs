using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TCGCollector.Helpers;

namespace TCGCollector.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
            .GetRequiredService<ApplicationDbContext>();
            //TODO: Deletes the DB (this is not needed for final code)
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            //Create Default User
            if (!context.Users.Any())
            {
                context.Users.Add(
                new User
                {
                    UserLogin = "admin",
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                }
                );
                context.SaveChanges();
            }

            //Create Card Cats
            if (!context.CardCats.Any())
            {
                var strings = new List<string>()
                {
                    "Pokemon", "Trainer", "Energy"
                };

                foreach (string value in strings)
                {
                    ObjectBuilderHelper.GetCardCatByName(context, value);
                    //context.CardCats.Add(
                    //    new CardCat
                    //    {
                    //        CardCatName = value,
                    //        LastUpdateDate = DateTime.Now
                    //    }
                    //);
                }
                context.SaveChanges();
            }

            if (!context.CardTypes.Any())
            {
                var strings = new List<string>() {
                        "Basic", "Stage 1", "Stage 2", "Item", "Supporter",
                        "Stadium", "Pokémon Tool", "Technical Machine", "EX", "GX",
                        "TAG TEAM", "LEGEND", "BREAK", "MEGA", "Special",
                        "Level Up", "Rocket's Secret Machine", "Restored", "Test"
                };

                foreach (string value in strings)
                {
                    ObjectBuilderHelper.GetCardTypeByName(context, value);
                    //context.CardTypes.Add(
                    //    new CardType
                    //    {
                    //        CardTypeName = value,
                    //        LastUpdateDate = DateTime.Now
                    //    }
                    //);
                }
                context.SaveChanges();
            }

            if (!context.SetSeries.Any())
            {
                var strings = new List<string>()
                {
                    "Sun & Moon"
                };

                foreach (string value in strings)
                {
                    ObjectBuilderHelper.GetSetSeriesByName(context, value);
                    //context.SetSeries.Add(
                    //    new SetSeries
                    //    {
                    //        SetSeriesName = value,
                    //        LastUpdateDate = DateTime.Now
                    //    }
                    //);
                }
                context.SaveChanges();
            }

            if (!context.Sets.Any())
            {
                context.Sets.AddRange(
                new Set
                {
                    SetName = "Unbroken Bonds",
                    SetCode = "sm10",
                    SetPTCGOCode = "UNB",
                    SetSeries = ObjectBuilderHelper.GetSetSeriesByName(context, "Sun & Moon"),
                    //SetSeries = context.SetSeries.FirstOrDefault(m => m.SetSeriesName.Equals("Sun & Moon")),
                    SetTotalCards = 214,
                    SetStandard = true,
                    SetExpanded = true,
                    SetSymbolURL = "https://images.pokemontcg.io/sm10/symbol.png",
                    SetLogoURL = "https://images.pokemontcg.io/sm10/logo.png",
                    SetReleaseDate = Convert.ToDateTime("04/05/2019")
                },
                new Set
                {
                    SetName = "Team Up",
                    SetCode = "sm9",
                    SetPTCGOCode = "TEU",
                    SetSeries = ObjectBuilderHelper.GetSetSeriesByName(context, "Sun & Moon"),
                    //SetSeries = context.SetSeries.FirstOrDefault(m => m.SetSeriesName.Equals("Sun & Moon")),
                    SetTotalCards = 181,
                    SetStandard = true,
                    SetExpanded = true,
                    SetSymbolURL = "https://images.pokemontcg.io/sm9/symbol.png",
                    SetLogoURL = "https://images.pokemontcg.io/sm9/logo.png",
                    SetReleaseDate = Convert.ToDateTime("02/01/2019")
                },
                new Set
                {
                    SetName = "Lost Thunder",
                    SetCode = "sm8",
                    SetPTCGOCode = "LOT",
                    SetSeries = ObjectBuilderHelper.GetSetSeriesByName(context, "Sun & Moon"),
                    //SetSeries = context.SetSeries.FirstOrDefault(m => m.SetSeriesName.Equals("Sun & Moon")),
                    SetTotalCards = 214,
                    SetStandard = true,
                    SetExpanded = true,
                    SetSymbolURL = "https://images.pokemontcg.io/sm8/symbol.png",
                    SetLogoURL = "https://images.pokemontcg.io/sm8/logo.png",
                    SetReleaseDate = Convert.ToDateTime("11/02/2018")
                },
                new Set
                {
                    SetName = "Guardians Rising",
                    SetCode = "sm2",
                    SetPTCGOCode = "GRI",
                    SetSeries = ObjectBuilderHelper.GetSetSeriesByName(context, "Sun & Moon"),
                    //SetSeries = context.SetSeries.FirstOrDefault(m => m.SetSeriesName.Equals("Sun & Moon")),
                    SetTotalCards = 145,
                    SetStandard = true,
                    SetExpanded = true,
                    SetSymbolURL = "https://images.pokemontcg.io/sm2/symbol.png",
                    SetLogoURL = "https://images.pokemontcg.io/sm2/logo.png",
                    SetReleaseDate = Convert.ToDateTime("05/05/2017")
                }
                ) ;
                context.SaveChanges();
            }

            if (!context.Cards.Any())
            {
                context.Cards.Add(
                    new Card
                    {
                        CardName = "Grass Energy",
                        CardImageURL = "https://images.pokemontcg.io/sm2/167.png",
                        CardImageHiURL = "https://images.pokemontcg.io/sm2/167_hires.png",

                        //CardCat = context.CardCats.FirstOrDefault(m => m.CardCatName.Equals("Energy")),
                        //CardCat = context.CardCats.SingleOrDefault(m => m.CardCatName.Equals("Energy"))
                        //    ?? new CardCat() { CardCatName = "Energy" },
                        //CardType = context.CardTypes.FirstOrDefault(m => m.CardTypeName.Equals("Basic")),
                        //Set = context.Sets.FirstOrDefault(m => m.SetName.Equals("Guardians Rising")),
                        CardCat = ObjectBuilderHelper.GetCardCatByName(context, "Energy"),
                        CardType = ObjectBuilderHelper.GetCardTypeByName(context, "Basic"),
                        Set = ObjectBuilderHelper.GetSetByName(context, "Guardians Rising"),
                        CardNum = 167,
                        Artist = "",
                        CardRarity = "Rare Secret",
                        LastUpdateDate = DateTime.Now
                    }
                    ) ;
                context.SaveChanges();

                context.Cards.Add(
                    new Card
                    {
                        CardName = "Grass Energy2",
                        CardImageURL = "https://images.pokemontcg.io/sm2/167.png",
                        CardImageHiURL = "https://images.pokemontcg.io/sm2/167_hires.png",

                        CardCat = ObjectBuilderHelper.GetCardCatByName(context, "Energy1"),
                        CardType = ObjectBuilderHelper.GetCardTypeByName(context, "Basic"),
                        Set = ObjectBuilderHelper.GetSetByName(context, "Guardians Rising"),
                        CardNum = 167,
                        Artist = "",
                        CardRarity = "Rare Secret",
                        LastUpdateDate = DateTime.Now
                    }
                );
            }
            context.SaveChanges();
        }
    }
}

