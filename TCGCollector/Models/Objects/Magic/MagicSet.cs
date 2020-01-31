using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class MagicSet
    {
        public int MagicSetID { get; set; }

        public string MagicSetName { get; set; }
        public string MagicSetCode { get; set; }
        public string MagicSetCodeAlt { get; set; }
        public bool MagicSetUSAOnly { get; set; }
        public bool MagicSetFoilOnly { get; set; }
        public bool MagicSetOnlineOnly { get; set; }
        public string MagicSetKeyruneCode { get; set; }
        public string MTGOCode { get; set; }
        public string MagicParentSetCode { get; set; }

        public int MagicSetSetSize { get; set; }
        public int MagicSetTotalSize { get; set; }

        [DataType(DataType.Date)]
        public DateTime MagicSetReleaseDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

        //Foreign Key for Set
        public Nullable<int> MagicBlockID { get; set; }
        public MagicBlock MagicBlock { get; set; }

        //Foreign Key for Set
        public Nullable<int> MagicSetTypeID { get; set; }
        public MagicSetType MagicSetType { get; set; }

        //public string SetSymbolURL { get; set; }
        //public string SetLogoURL { get; set; }
        //public string SetSymbolLocalURL { get; set; }
        //public string SetLogoLocalURL { get; set; }

        public ICollection<MagicCard> MagicCards { get; set; }
    }
}
