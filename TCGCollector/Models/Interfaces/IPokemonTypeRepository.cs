using System.Linq;

namespace TCGCollector.Models
{
    public class IPokemonTypeRepository
    {
        IQueryable<PokemonType> PokemonTypes { get; }
    }
}
