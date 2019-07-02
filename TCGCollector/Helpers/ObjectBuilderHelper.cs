
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
using TCGCollector.Models;

namespace TCGCollector.Helpers
{
    public static class ObjectBuilderHelper
    {
        //Build a CardCat Object from JSON
        public static void BuildCardCatsFromJSON(ApplicationDbContext ctx, string JSONPath)
        {
            JArray obj = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(File.ReadAllText(JSONPath));

            foreach (var result in obj)
            {
                GetCardCatByName(ctx, (string)result["cardcatname"]);
            }
        }

        //CardCat Object Helper with create if not exists
        public static CardCat GetCardCatByName(ApplicationDbContext ctx, string CardCatName)
        {
            CardCat CardCatObj;
            //Check if object already exists and create it if it does not
            CardCatObj = ctx.CardCats.SingleOrDefault(m => m.CardCatName.Equals(CardCatName))
                ?? new CardCat() {
                    CardCatName = CardCatName,
                    LastUpdateDate = DateTime.Now
                };

            //Put Values here that Need to Update otherwise if the record exists then it'll not be updated
            ctx.AddOrUpdate(CardCatObj);
            ctx.SaveChanges();

            return CardCatObj;
        }

        //CardRarity Object Helper with create if not exists
        public static CardRarity GetCardRarityByName(ApplicationDbContext ctx, string CardRarityName)
        {
            CardRarity CardRarityObj;
            //Check if object already exists and create it if it does not
            CardRarityObj = ctx.CardRarities.SingleOrDefault(m => m.CardRarityName.Equals(CardRarityName))
                ?? new CardRarity()
                {
                    CardRarityName = CardRarityName,
                    LastUpdateDate = DateTime.Now
                };

            //Put Values here that Need to Update otherwise if the record exists then it'll not be updated
            ctx.AddOrUpdate(CardRarityObj);
            ctx.SaveChanges();

            return CardRarityObj;
        }

        //Build a CardType Object from JSON
        public static void BuildCardTypesFromJSON(ApplicationDbContext ctx, string JSONPath)
        {
            JArray obj = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(File.ReadAllText(JSONPath));

            foreach (var result in obj)
            {
                GetCardCatByName(ctx, (string)result["cardtypename"]);
            }
        }

        //CardType Object Helper with create if not exists
        public static CardType GetCardTypeByName(ApplicationDbContext ctx, string CardTypeName)
        {
            CardType CardTypeObj;
            //Check if object already exists and create it if it does not
            CardTypeObj = ctx.CardTypes.SingleOrDefault(m => m.CardTypeName.Equals(CardTypeName))
                ?? new CardType() {
                    CardTypeName = CardTypeName,
                    LastUpdateDate = DateTime.Now
                };

            //Put Values here that Need to Update otherwise if the record exists then it'll not be updated
            ctx.AddOrUpdate(CardTypeObj);
            ctx.SaveChanges();

            return CardTypeObj;
        }

        //Set Object Helper with no create and return null
        public static Set GetSetByNameNoInsert(ApplicationDbContext ctx, string SetName)
        {
            Set SetObj;
            //Check if object already exists and create it if it does not
            SetObj = ctx.Sets.SingleOrDefault(m => m.SetName.Equals(SetName));
            
            return SetObj;
        }

        //Build a CardCat Object from JSON
        public static void BuildCardsFromJSON(ApplicationDbContext ctx, string JSONPath)
        {
            JArray obj = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(File.ReadAllText(JSONPath));

            foreach (var result in obj)
            {
                Card CardObj;
                SpecialCard SpecialCardObj;
                TrainerCard TrainerCardObj;

                switch ((string)result["supertype"]) {
                    case "Energy":
                        switch ((string)result["subtype"])
                        {
                            case "Basic":
                                //Basic Energy
                                CardObj = ctx.Cards.SingleOrDefault(m => m.CardName.Equals((string)result["name"]) && m.CardNum == (int)result["number"])
                                    ?? new Card()
                                    {
                                        CardName = (string)result["name"],
                                        CardImageURL = (string)result["imageUrl"],
                                        CardImageHiURL = (string)result["imageUrlHiRes"],
                                        CardCat = ObjectBuilderHelper.GetCardCatByName(ctx, (string)result["supertype"]),
                                        CardType = ObjectBuilderHelper.GetCardTypeByName(ctx, (string)result["subtype"]),
                                        Set = ObjectBuilderHelper.GetSetByNameNoInsert(ctx, (string)result["set"]),
                                        CardNum = (int)result["number"],
                                        Artist = (string)result["artist"],
                                        CardRarity = ObjectBuilderHelper.GetCardRarityByName(ctx, (string)result["rarity"]),
                                        
                                        LastUpdateDate = DateTime.Now
                                    };
                                ctx.AddOrUpdate(CardObj);
                                break;
                            case "Special":
                                //Special Eneryg
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Pokemon":
                        break;
                    case "Trainer":
                        break;
                    default:
                        break;
                }
                //If Card - CardCat = Energy, CardType = Basic
                //If SpecialCard - CardCat = Energy. CardType = Special
                //If PokemonCard
                //If TrainerCar
                //GetCardByName(ctx, (string)result["pokemontypename"]);
                
                ctx.SaveChanges();
            }
        }

        //CardCat Object Helper with create if not exists
        //public static Card GetCardByName(ApplicationDbContext ctx, string CardName, int CardNum)
        //{
        //    Card CardObj;
            ////Check if object already exists and create it if it does not
            //CardObj = ctx.Cards.SingleOrDefault(m => m.CardName.Equals(CardName) && m.CardNum == CardNum)
            //    ?? new Card()
            //    {
            //        CardName = PokemonTypeName,
            //        LastUpdateDate = DateTime.Now
            //    };

            ////Put Values here that Need to Update otherwise if the record exists then it'll not be updated
            //ctx.AddOrUpdate(CardObj);
            //ctx.SaveChanges();

        //    return CardObj;
        //}

        //Build a CardCat Object from JSON
        public static void BuildPokemonTypesFromJSON(ApplicationDbContext ctx, string JSONPath)
        {
            JArray obj = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(File.ReadAllText(JSONPath));

            foreach (var result in obj)
            {
                GetPokemonTypeByName(ctx, (string)result["pokemontypename"]);
            }
        }

        //CardCat Object Helper with create if not exists
        public static PokemonType GetPokemonTypeByName(ApplicationDbContext ctx, string PokemonTypeName)
        {
            PokemonType PokemonTypeObj;
            //Check if object already exists and create it if it does not
            PokemonTypeObj = ctx.PokemonTypes.SingleOrDefault(m => m.PokemonTypeName.Equals(PokemonTypeName))
                ?? new PokemonType()
                {
                    PokemonTypeName = PokemonTypeName,
                    LastUpdateDate = DateTime.Now
                };

            //Put Values here that Need to Update otherwise if the record exists then it'll not be updated
            ctx.AddOrUpdate(PokemonTypeObj);
            ctx.SaveChanges();

            return PokemonTypeObj;
        }

        //Build a Set Object from JSON
        public static void BuildSetsFromJSON(ApplicationDbContext ctx, string JSONPath)
        {
            JArray obj = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(File.ReadAllText(JSONPath));

            foreach (var result in obj)
            {
                Set SetObj = ctx.Sets.SingleOrDefault(m => m.SetName.Equals((string)result["name"]) && m.SetCode.Equals((string)result["code"]))
                    ?? new Set() {
                        SetName = (string)result["name"],
                        SetCode = (string)result["code"],
                        SetPTCGOCode = (string)result["ptcgoCode"],
                        SetSeries = ObjectBuilderHelper.GetSetSeriesByName(ctx, (string)result["series"]),
                        //SetSeries = context.SetSeries.FirstOrDefault(m => m.SetSeriesName.Equals("Sun & Moon")),
                        SetTotalCards = (int)result["totalCards"],
                        SetStandard = (bool)result["standardLegal"],
                        SetExpanded = (bool)result["expandedLegal"],
                        SetSymbolURL = (string)result["symbolUrl"],
                        SetLogoURL = (string)result["logoUrl"],
                        SetReleaseDate = DateTime.ParseExact((string)result["releaseDate"], "MM/dd/yyyy", CultureInfo.InvariantCulture),
                        LastUpdateDate = DateTime.Now
                    };
                //Put Values here that Need to Update otherwise if the record exists then it'll not be updated
                //SetObj.SetTotalCards = (int)result["totalCards"];

                ctx.AddOrUpdate(SetObj);
                ctx.SaveChanges();
            }
        }

        //SetSeries Object Helper with create if not exists
        public static SetSeries GetSetSeriesByName(ApplicationDbContext ctx, string SetSeriesName)
        {
            SetSeries SetSeriesObj;
            //Check if object already exists and create it if it does not
            SetSeriesObj = ctx.SetSeries.SingleOrDefault(m => m.SetSeriesName.Equals(SetSeriesName))
                ?? new SetSeries() {
                    SetSeriesName = SetSeriesName,
                    LastUpdateDate = DateTime.Now
                };

            //Put Values here that Need to Update otherwise if the record exists then it'll not be updated
            ctx.AddOrUpdate(SetSeriesObj);
            ctx.SaveChanges();

            return SetSeriesObj;
        }
    }
}
