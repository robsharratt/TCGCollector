using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class MagicBlock
    {
        public int MagicBlockID { get; set; }
        public string MagicBlockName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

        public ICollection<MagicSet> MagicSets { get; set; }
    }
}
