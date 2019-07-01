using System.Linq;

namespace TCGCollector.Models
{
    public class ISetRepository
    {
        IQueryable<Set> Sets { get; }
    }
}
