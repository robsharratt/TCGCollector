using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class Attack
    {
        public int AttackID { get; set; }
        //public int EnergyTypeID { get; set; }
        //public EnergyType EnergyType { get; set; }
        public string AttackName { get; set; }
        //AttackCoat
        public int AttackConvertedEnergyCost { get; set; }
        public string AttackDamage { get; set; }
        [StringLength(1024)]
        public string AttackText { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

        public ICollection<PokemonCardAttack> PokemonCardAttacks { get; set; }
        public ICollection<AttackEnergy> AttackEnergies { get; set; }
    }
}
