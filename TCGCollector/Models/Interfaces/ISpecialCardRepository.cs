using System.Linq;

namespace TCGCollector.Models
{
    public class ISpecialCardRepository
    {
        IQueryable<SpecialCard> SpecialCards { get; }
    }
}
