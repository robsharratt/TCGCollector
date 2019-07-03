using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                ObjectBuilderHelper.BuildCardCatsFromJSON(context, @"JSON Data/CardCats.json");

                context.SaveChanges();
            }

            //Create Card Types
            if (!context.CardTypes.Any())
            {
                ObjectBuilderHelper.BuildCardTypesFromJSON(context, @"JSON Data/CardTypes.json");

                context.SaveChanges();
            }

            //Create Card Types
            if (!context.PokemonTypes.Any())
            {
                ObjectBuilderHelper.BuildPokemonTypesFromJSON(context, @"JSON Data/PokemonTypes.json");

                context.SaveChanges();
            }

            //No Longer Required as included in Set create
            //if (!context.SetSeries.Any())
            //{
            //    var strings = new List<string>()
            //    {
            //        "Sun & Moon"
            //    };

            //    foreach (string value in strings)
            //    {
            //        ObjectBuilderHelper.GetSetSeriesByName(context, value);
            //        //context.SetSeries.Add(
            //        //    new SetSeries
            //        //    {
            //        //        SetSeriesName = value,
            //        //        LastUpdateDate = DateTime.Now
            //        //    }
            //        //);
            //    }
            //    context.SaveChanges();
            //}

            //Create Sets (SetSeries is loaded based on Set being loaded that uses that SetSeries)
            if (!context.Sets.Any())
            {
                ObjectBuilderHelper.BuildSetsFromJSON(context, @"JSON Data/Sets.json");

                //context.SaveChanges();
            }

            //Create Cards
            if (!context.Cards.Any())
            {
                ObjectBuilderHelper.BuildCardsFromJSON(context, @"JSON Data/Cards.json");
                //context.Cards.Add(
                //    new Card
                //    {
                //        CardName = "Grass Energy",
                //        CardImageURL = "https://images.pokemontcg.io/sm2/167.png",
                //        CardImageHiURL = "https://images.pokemontcg.io/sm2/167_hires.png",

                //        //CardCat = context.CardCats.FirstOrDefault(m => m.CardCatName.Equals("Energy")),
                //        //CardCat = context.CardCats.SingleOrDefault(m => m.CardCatName.Equals("Energy"))
                //        //    ?? new CardCat() { CardCatName = "Energy" },
                //        //CardType = context.CardTypes.FirstOrDefault(m => m.CardTypeName.Equals("Basic")),
                //        //Set = context.Sets.FirstOrDefault(m => m.SetName.Equals("Guardians Rising")),
                //        CardCat = ObjectBuilderHelper.GetCardCatByName(context, "Energy"),
                //        CardType = ObjectBuilderHelper.GetCardTypeByName(context, "Basic"),
                //        Set = ObjectBuilderHelper.GetSetByNameNoInsert(context, "Guardians Rising"),
                //        CardNum = 167,
                //        Artist = "",
                //        CardRarity = "Rare Secret",
                //        LastUpdateDate = DateTime.Now
                //    }
                //    );
                //context.SaveChanges();

                //context.Cards.Add(
                //    new Card
                //    {
                //        CardName = "Grass Energy2",
                //        CardImageURL = "https://images.pokemontcg.io/sm2/167.png",
                //        CardImageHiURL = "https://images.pokemontcg.io/sm2/167_hires.png",

                //        CardCat = ObjectBuilderHelper.GetCardCatByName(context, "Energy1"),
                //        CardType = ObjectBuilderHelper.GetCardTypeByName(context, "Basic"),
                //        Set = ObjectBuilderHelper.GetSetByNameNoInsert(context, "Guardians Rising"),
                //        CardNum = 167,
                //        Artist = "",
                //        CardRarity = "Rare Secret",
                //        LastUpdateDate = DateTime.Now
                //    }
                //);
                //context.SaveChanges();

                //context.SpecialCards.Add(
                //    new SpecialCard
                //    {
                //        CardName = "Grass Energy3",
                //        CardImageURL = "https://images.pokemontcg.io/sm2/167.png",
                //        CardImageHiURL = "https://images.pokemontcg.io/sm2/167_hires.png",

                //        CardCat = ObjectBuilderHelper.GetCardCatByName(context, "Energy1"),
                //        CardType = ObjectBuilderHelper.GetCardTypeByName(context, "Basic"),
                //        Set = ObjectBuilderHelper.GetSetByNameNoInsert(context, "Guardians Rising"),
                //        CardNum = 167,
                //        Artist = "",
                //        CardRarity = "Rare Secret",
                //        SpecialCardText = "Special Card Test Text",
                //        LastUpdateDate = DateTime.Now
                //    }
                //);
                //context.SaveChanges();
            }
            context.SaveChanges();

            //SpecialCard SpecialCardObj = context.SpecialCards.SingleOrDefault(m => m.CardName.Equals("Grass Energy3"));
            //Console.WriteLine("THIS IS TEST OUTPUT " + SpecialCardObj.SpecialCardText);
        }
    }
}

