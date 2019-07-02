using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class SpecialCard : Card
    {
        public ICollection<SpecialCardSpecialCardText> SpecialCardSpecialCardTexts { get; set; }
    }
}
