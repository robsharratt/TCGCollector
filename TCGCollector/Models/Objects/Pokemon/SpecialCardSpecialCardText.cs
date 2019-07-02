using System;
namespace TCGCollector.Models
{
    public class SpecialCardSpecialCardText
    {
        public int CardID { get; set; }
        public SpecialCard SpecialCard { get; set; }
        public int CardTextID { get; set; }
        public SpecialCardText CardText { get; set; }
    }
}
