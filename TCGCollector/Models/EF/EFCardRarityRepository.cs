using System.Collections.Generic;
using System.Linq;

namespace TCGCollector.Models
{
    public class EFCardRarityRepository : ICardRarityRepository
    {
        private ApplicationDbContext context;

        public EFCardRarityRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<CardRarity> CardRarities => context.CardRarities;
    }
}
