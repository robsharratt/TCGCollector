using System.Linq;

namespace TCGCollector.Models
{
    public class ITrainerCardRepository
    {
        IQueryable<TrainerCard> TrainerCards { get; }
    }
}
