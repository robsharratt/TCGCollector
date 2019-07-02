using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class CardText
    {
        public int CardTextID { get; set; }
        [StringLength(1024)]
        public string CardTextLine { get; set; }
        public ICollection<SpecialCardCardText> SpecialCardCardTexts { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

    }
}
