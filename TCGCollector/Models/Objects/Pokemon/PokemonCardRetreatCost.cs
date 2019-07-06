using System;
namespace TCGCollector.Models
{
    public class PokemonCardRetreatCost
    {
        public int PokemonCardRetreatCostID { get; set; }

        public int CardID { get; set; }
        public PokemonCard PokemonCard { get; set; }
        public int EnergyTypeID { get; set; }
        public EnergyType EnergyType { get; set; }
    }
}
