using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class Set
    {
        public int SetID { get; set; }

        public string SetName { get; set; }
        public string SetCode { get; set; }
        public string SetPTCGOCode { get; set; }

        //Foreign Key for Set
        public Nullable<int> SetSeriesID { get; set; }
        public SetSeries SetSeries { get; set; }

        public int SetTotalCards { get; set; }
        public bool SetStandard { get; set; }
        public bool SetExpanded { get; set; }
        public string SetSymbolURL { get; set; }
        public string SetLogoURL { get; set; }
        public string SetSymbolLocalURL { get; set; }
        public string SetLogoLocalURL { get; set; }

        [DataType(DataType.Date)]
        public DateTime SetReleaseDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}
