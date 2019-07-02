using System.Collections.Generic;
using TCGCollector.Models;

namespace TCGCollector.Models.ViewModels
{
    public class CardCatsViewModel
    {
        public IEnumerable<CardCat> CardCats { get; set; }
        //public PagingInfo PagingInfo { get; set; }
        //public string CurrentCategory { get; set; }
    }
}
