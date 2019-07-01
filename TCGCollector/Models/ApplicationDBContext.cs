using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace TCGCollector.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set;}
        public DbSet<CardCat> CardCats { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<SetSeries> SetSeries { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<SpecialCard> SpecialCards { get; set; }
        public DbSet<TrainerCard> TrainerCards { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
