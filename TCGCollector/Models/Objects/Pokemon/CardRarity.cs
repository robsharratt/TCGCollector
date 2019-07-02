using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class CardRarity
    {
        public int CardRarityID { get; set; }
        public string CardRarityName { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}
