using System;
namespace TCGCollector.Models
{
    public class PokemonCardAttack
    {
        public int CardID { get; set; }
        public PokemonCard PokemonCard { get; set; }
        public int AttackID { get; set; }
        public Attack Attack { get; set; }
    }
}
