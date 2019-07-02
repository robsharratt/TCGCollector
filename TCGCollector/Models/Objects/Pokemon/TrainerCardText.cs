using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCGCollector.Models
{
    public class TrainerCardText
    {
        public int TrainerCardTextID { get; set; }
        [StringLength(1024)]
        public string CardTextLine { get; set; }
        public ICollection<TrainerCardTrainerCardText> TrainerCardTrainerCardTexts { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

    }
}
