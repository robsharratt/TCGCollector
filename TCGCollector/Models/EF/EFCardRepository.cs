using System.Collections.Generic;
using System.Linq;

namespace TCGCollector.Models
{
    public class EFCardRepository : ICardRepository
    {
        private ApplicationDbContext context;

        public EFCardRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Card> Card => context.Cards;
    }
}
