using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class Weakness
    {
        public int WeaknessID { get; set; }
        public int EnergyTypeID { get; set; }
        public EnergyType EnergyType { get; set; }
        public string WeaknessValue { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

        public ICollection<PokemonCardWeakness> PokemonCardWeaknesses { get; set; }
    }
}
