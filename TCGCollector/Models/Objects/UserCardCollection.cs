using System;
namespace TCGCollector.Models
{
    public class UserCardCollection
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int CardCollectionID { get; set; }
        public CardCollection CardCollection { get; set; }
    }
}
