using System.Linq;

namespace TCGCollector.Models
{
    public class IUserRepository
    {
        IQueryable<User> Users { get; }
    }
}
