using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class EnergyType
    {
        public int EnergyTypeID { get; set; }
        public string EnergyTypeName { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

        public ICollection<PokemonCardPokemonType> PokemonCardPokemonTypes { get; set; }
        public ICollection<PokemonCardRetreatCost> PokemonCardRetreatCosts { get; set; }
    }
}
