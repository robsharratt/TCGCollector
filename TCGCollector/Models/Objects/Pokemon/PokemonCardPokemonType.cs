using System;
namespace TCGCollector.Models
{
    public class PokemonCardPokemonType
    {
        public int CardID { get; set; }
        public PokemonCard PokemonCard { get; set; }
        public int PokemonTypeID { get; set; }
        public PokemonType PokemonType { get; set; }
    }
}
