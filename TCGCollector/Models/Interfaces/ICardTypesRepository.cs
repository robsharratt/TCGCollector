using System.Linq;

namespace TCGCollector.Models
{
    public class ICardTypeRepository
    {
        IQueryable<CardType> CardTypes { get; }
    }
}
