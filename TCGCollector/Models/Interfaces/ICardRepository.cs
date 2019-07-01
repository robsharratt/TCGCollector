using System.Linq;

namespace TCGCollector.Models
{
    public class ICardRepository
    {
        IQueryable<Card> Cards { get; }
    }
}
