using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class PokemonType
    {
        public int PokemonTypeID { get; set; }
        public string PokemonTypeName { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }
    }
}
