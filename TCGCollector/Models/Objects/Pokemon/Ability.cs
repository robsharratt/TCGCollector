using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class Ability
    {
        public int AbilityID { get; set; }
        public string AbilityName { get; set; }
        [StringLength(1024)]
        public string AbilityText { get; set; }
        public string AbilityType { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

        public ICollection<PokemonCardAbility> PokemonCardAbilities { get; set; }
    }
}
