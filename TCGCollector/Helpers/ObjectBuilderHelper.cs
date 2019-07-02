
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
        //Build a Set Object from JSON
        public static void BuildCardCatsFromJSON(ApplicationDbContext ctx, string JSONPath)
        {
            JArray obj = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(File.ReadAllText(@"JSON Data/CardCats.json"));

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

        //Build a Set Object from JSON
        public static void BuildSetsFromJSON(ApplicationDbContext ctx, string JSONPath)
        {
            JArray obj = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(File.ReadAllText(@"JSON Data/Sets.json"));

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
