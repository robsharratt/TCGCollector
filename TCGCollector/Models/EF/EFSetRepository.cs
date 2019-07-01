using System.Collections.Generic;
using System.Linq;

namespace TCGCollector.Models
{
    public class EFSetSeriesRepository :ISetSeriesRepository
    {
        private ApplicationDbContext context;

        public EFSetSeriesRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<SetSeries> SetSeries => context.SetSeries;
    }
}
