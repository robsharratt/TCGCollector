using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class MagicSetType
    {
        public int MagicSetTypeID { get; set; }
        public string MagicSetTypeName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

        public ICollection<MagicSet> MagicSets { get; set; }
    }
}
