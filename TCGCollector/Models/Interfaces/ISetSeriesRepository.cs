using System.Linq;

namespace TCGCollector.Models
{
    public class ISetSeriesRepository
    {
        IQueryable<SetSeries> SetSeries { get; }
    }
}
