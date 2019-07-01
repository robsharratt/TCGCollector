using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TCGCollector.Models;

namespace TCGCollector.Helpers
{
    public static class ObjectBuilderHelper
    {
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
            ctx.AddOrUpdate(CardTypeObj);
            ctx.SaveChanges();

            return CardTypeObj;
        }

        //Set Object Helper with no create and return null
        public static Set GetSetByName(ApplicationDbContext ctx, string SetName)
        {
            Set SetObj;
            //Check if object already exists and create it if it does not
            SetObj = ctx.Sets.SingleOrDefault(m => m.SetName.Equals(SetName));
            
            return SetObj;
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
            ctx.AddOrUpdate(SetSeriesObj);
            ctx.SaveChanges();

            return SetSeriesObj;
        }
    }
}
