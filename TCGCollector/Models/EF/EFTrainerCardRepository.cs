using System.Collections.Generic;
using System.Linq;

namespace TCGCollector.Models
{
    public class EFTrainerCardRepository : ITrainerCardRepository
    {
        private ApplicationDbContext context;

        public EFTrainerCardRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<TrainerCard> TrainerCard => context.TrainerCards;
    }
}
