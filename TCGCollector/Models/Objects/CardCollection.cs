using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TCGCollector.Models
{
    public class CardCollection
    {
        public int CardCollectionID { get; set; }
        public string CardCollectionName { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }
        public ICollection<UserCardCollection> UserCardCollections { get; set; }
    }
}
