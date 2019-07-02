using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TCGCollector.Models
{
    public class TrainerCard : Card
    {
        public ICollection<TrainerCardTrainerCardText> TrainerCardTrainerCardTexts { get; set; }
    }
}
