using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TCGCollector.Models
{
    public class PokemonCard : Card
    {
        //public int CardID { get; set; }
        //public string CardName { get; set; }
        //public string CardImageURL { get; set; }

        ////Foreign Key for Card Type
        //public int CardCatID { get; set; }
        //public CardCat CardCat { get; set; }

        ////Foreign Key for Card Type
        //public int CardTypeID { get; set; }
        //public CardType CardType { get; set; }

        ////Foreign Key for Set
        //public int SetID { get; set; }
        //public Set Set { get; set; }

        //public string CardCode { get; set; }
        //public string SetName { get; set; }
        //public string SetSeries { get; set; }
        //public bool SetStandard { get; set; }
        //public bool SetExpanded { get; set; }
        //public string SetSymbolURL { get; set; }
        //public string SetLogoURL { get; set; }

        //[DataType(DataType.DateTime)]
        //public DateTime SetReleaseDate { get; set; }

        //[DataType(DataType.DateTime)]
        //public DateTime LastUpdateDate { get; set; }
        //[JsonProperty("id")]
        //public string Id { get; set; }

        //[JsonProperty("name")]
        //public string Name { get; set; }

        //[JsonProperty("imageUrl")]
        //public string ImageUrl { get; set; }

        //[JsonProperty("imageUrlHiRes")]
        //public string ImageUrlHiRes { get; set; }

        //[JsonProperty("subType")]
        //public string SubType { get; set; }

        //[JsonProperty("superType")]
        //public string SuperType { get; set; }

        //[JsonProperty("number")]
        //public string Number { get; set; }

        //[JsonProperty("artist")]
        //public string Artist { get; set; }

        //[JsonProperty("rarity")]
        //public string Rarity { get; set; }

        //[JsonProperty("series")]
        //public string Series { get; set; }

        //[JsonProperty("set")]
        //public string Set { get; set; }

        //[JsonProperty("setCode")]
        //public string SetCode { get; set; }
    }
}
