using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class CardCat
    {
        [Key]
        public int CardCatID { get; set; }

        public string CardCatName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}
