using System;
namespace TCGCollector.Models
{
    public class PokemonCardResistance
    {
        public int CardID { get; set; }
        public PokemonCard PokemonCard { get; set; }
        public int ResistanceID { get; set; }
        public Resistance Resistance { get; set; }
    }
}
