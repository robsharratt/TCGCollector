﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace TCGCollector.Models
{
    public class PokemonCard : Card
    {
        public int HP { get; set; }
        //Retreat Cost structure

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int ConvertedRetreatCost { get; set; }
        //PokemonTypes structure
        //Attacks structure
        //Weaknesses structure
        public int NationalPokedexNumber { get; set; }
        //Only appears on Stage 1 or Stage 2
        public string EvolvesFrom { get; set; }
        //Only appears on Basic or Stage 1
        //EvolvesTo structure

        public ICollection<PokemonCardPokemonType> PokemonCardPokemonTypes { get; set; }
    }
}
