using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class CardType
    {
        [Key]
        public int CardTypeID { get; set; }

        public string CardTypeName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}
