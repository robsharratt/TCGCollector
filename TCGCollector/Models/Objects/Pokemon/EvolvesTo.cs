using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class EvolvesTo
    {
        [Key]
        public int EvolvesToID { get; set; }

        public string EvolvesToName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

        public ICollection<PokemonCardEvolvesTo> PokemonCardEvolvesTos { get; set; }
    }
}
