using System;
namespace TCGCollector.Models
{
    public class PokemonCardAbility
    {
        public int CardID { get; set; }
        public PokemonCard PokemonCard { get; set; }
        public int AbilityID { get; set; }
        public Ability Ability { get; set; }
    }
}
