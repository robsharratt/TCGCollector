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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCardCollection>()
                .HasKey(ucc => new { ucc.UserID, ucc.CardCollectionID });
            modelBuilder.Entity<UserCardCollection>()
                .HasOne(ucc => ucc.User)
                .WithMany(u => u.UserCardCollections)
                .HasForeignKey(ucc => ucc.UserID);
            modelBuilder.Entity<UserCardCollection>()
                .HasOne(ucc => ucc.CardCollection)
                .WithMany(cc => cc.UserCardCollections)
                .HasForeignKey(ucc => ucc.CardCollectionID);

            modelBuilder.Entity<SpecialCardCardText>()
                .HasKey(scct => new { scct.CardID, scct.CardTextID });
            modelBuilder.Entity<SpecialCardCardText>()
                .HasOne(scct => scct.SpecialCard)
                .WithMany(sc => sc.SpecialCardCardTexts)
                .HasForeignKey(scct => scct.CardID);
            modelBuilder.Entity<SpecialCardCardText>()
                .HasOne(scct => scct.CardText)
                .WithMany(ct => ct.SpecialCardCardTexts)
                .HasForeignKey(scct => scct.CardTextID);
        }

        public DbSet<CardCat> CardCats { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<CardRarity> CardRarities { get; set; }
        public DbSet<SetSeries> SetSeries { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<SpecialCard> SpecialCards { get; set; }
        public DbSet<TrainerCard> TrainerCards { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
