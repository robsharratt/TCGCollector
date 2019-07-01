using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class SetSeries
    {
        public int SetSeriesID { get; set; }
        public string SetSeriesName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

        public ICollection<Set> Sets { get; set; }
    }
}
