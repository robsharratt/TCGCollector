using System;
namespace TCGCollector.Models
{
    public class SpecialCardCardText
    {
        public int CardID { get; set; }
        public SpecialCard SpecialCard { get; set; }
        public int CardTextID { get; set; }
        public CardText CardText { get; set; }
    }
}
