using System.Linq;

namespace TCGCollector.Models
{
    public class ICardRarityRepository
    {
        IQueryable<CardRarity> CardRarities { get; }
    }
}
