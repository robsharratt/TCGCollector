using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class Resistance
    {
        public int ResistanceID { get; set; }
        public int EnergyTypeID { get; set; }
        public EnergyType EnergyType { get; set; }
        public string ResistanceValue { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

        public ICollection<PokemonCardResistance> PokemonCardResistances { get; set; }
    }
}
