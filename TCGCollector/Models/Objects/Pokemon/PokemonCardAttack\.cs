using System;
namespace TCGCollector.Models
{
    public class PokemonCardWeakness
    {
        public int CardID { get; set; }
        public PokemonCard PokemonCard { get; set; }
        public int WeaknessID { get; set; }
        public Weakness Weakness { get; set; }
    }
}
