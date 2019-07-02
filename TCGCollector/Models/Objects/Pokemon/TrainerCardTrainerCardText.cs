using System;
namespace TCGCollector.Models
{
    public class TrainerCardTrainerCardText
    {
        public int CardID { get; set; }
        public TrainerCard TrainerCard { get; set; }
        public int CardTextID { get; set; }
        public TrainerCardText CardText { get; set; }
    }
}
