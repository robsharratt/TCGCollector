using System.Collections.Generic;
using System.Linq;

namespace TCGCollector.Models
{
    public class EFPokemonTypeRepository : IPokemonTypeRepository
    {
        private ApplicationDbContext context;

        public EFPokemonTypeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<PokemonType> PokemonType => context.PokemonTypes;
    }
}
