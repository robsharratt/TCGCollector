using System;
namespace TCGCollector.Models
{
    public class PokemonCardEvolvesTo
    {
        public int CardID { get; set; }
        public PokemonCard PokemonCard { get; set; }
        public int EvolvesToID { get; set; }
        public EvolvesTo EvolvesTo { get; set; }
    }
}
