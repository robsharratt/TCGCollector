using System.Collections.Generic;
using System.Linq;

namespace TCGCollector.Models
{
    public class EFCardTypeRepository : ICardTypeRepository
    {
        private ApplicationDbContext context;

        public EFCardTypeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<CardType> CardTypes => context.CardTypes;
    }
}
