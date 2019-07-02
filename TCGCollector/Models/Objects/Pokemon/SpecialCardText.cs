using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class SpecialCardText
    {
        public int SpecialCardTextID { get; set; }
        [StringLength(1024)]
        public string CardTextLine { get; set; }
        public ICollection<SpecialCardSpecialCardText> SpecialCardSpecialCardTexts { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

    }
}
