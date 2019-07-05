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
            //modelBuilder.Entity<PokemonCard>()
            //    .Property(b => b.ConvertedRetreatCost)
            //    .HasDefaultValue(0);

            //UserCardCollection Mamy to Many Relationship
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

            //SpecialCardSpecialCardText Mamy to Many Relationship
            modelBuilder.Entity<SpecialCardSpecialCardText>()
                .HasKey(scsct => new { scsct.CardID, scsct.CardTextID });
            modelBuilder.Entity<SpecialCardSpecialCardText>()
                .HasOne(scsct => scsct.SpecialCard)
                .WithMany(sc => sc.SpecialCardSpecialCardTexts)
                .HasForeignKey(scsct => scsct.CardID);
            modelBuilder.Entity<SpecialCardSpecialCardText>()
                .HasOne(scsct => scsct.CardText)
                .WithMany(sct => sct.SpecialCardSpecialCardTexts)
                .HasForeignKey(scsct => scsct.CardTextID);

            //TrainerCardTrainerCardText Mamy to Many Relationship
            modelBuilder.Entity<TrainerCardTrainerCardText>()
                .HasKey(tctct => new { tctct.CardID, tctct.CardTextID });
            modelBuilder.Entity<TrainerCardTrainerCardText>()
                .HasOne(tctct => tctct.TrainerCard)
                .WithMany(tc => tc.TrainerCardTrainerCardTexts)
                .HasForeignKey(tctct => tctct.CardID);
            modelBuilder.Entity<TrainerCardTrainerCardText>()
                .HasOne(tctct => tctct.CardText)
                .WithMany(tct => tct.TrainerCardTrainerCardTexts)
                .HasForeignKey(tctct => tctct.CardTextID);

            //PokemonCardPokemonType Mamy to Many Relationship
            modelBuilder.Entity<PokemonCardPokemonType>()
                .HasKey(pcpt => new { pcpt.CardID, pcpt.PokemonTypeID });
            modelBuilder.Entity<PokemonCardPokemonType>()
                .HasOne(pcpt => pcpt.PokemonCard)
                .WithMany(pc => pc.PokemonCardPokemonTypes)
                .HasForeignKey(pcpt => pcpt.CardID);
            modelBuilder.Entity<PokemonCardPokemonType>()
                .HasOne(pcpt => pcpt.PokemonType)
                .WithMany(pt => pt.PokemonCardPokemonTypes)
                .HasForeignKey(pcpt => pcpt.PokemonTypeID);

            //PokemonCardEvolvesTo Mamy to Many Relationship
            modelBuilder.Entity<PokemonCardEvolvesTo>()
                .HasKey(pcet => new { pcet.CardID, pcet.EvolvesToID });
            modelBuilder.Entity<PokemonCardEvolvesTo>()
                .HasOne(pcet => pcet.PokemonCard)
                .WithMany(pc => pc.PokemonCardEvolvesTos)
                .HasForeignKey(pcet => pcet.CardID);
            modelBuilder.Entity<PokemonCardEvolvesTo>()
                .HasOne(pcet => pcet.EvolvesTo)
                .WithMany(et => et.PokemonCardEvolvesTos)
                .HasForeignKey(pcet => pcet.EvolvesToID);
        }

        //Card Data
        public DbSet<CardCat> CardCats { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<CardRarity> CardRarities { get; set; }
        public DbSet<SetSeries> SetSeries { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }
        public DbSet<EvolvesTo> EvolvesTos { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<PokemonCard> PokemonCards { get; set; }
        public DbSet<SpecialCard> SpecialCards { get; set; }
        public DbSet<TrainerCard> TrainerCards { get; set; }
        public DbSet<SpecialCardText> SpecialCardTexts { get; set; }
        public DbSet<TrainerCardText> TrainerCardTexts { get; set; }
        public DbSet<SpecialCardSpecialCardText> SpecialCardSpecialCardTexts { get; set; }
        public DbSet<TrainerCardTrainerCardText> TrainerCardTrainerCardTexts { get; set; }
        public DbSet<PokemonCardPokemonType> PokemonCardPokemonTypes { get; set; }
        public DbSet<PokemonCardEvolvesTo> PokemonCardEvolvesTos { get; set; }

        //Card Collections
        public DbSet<CardCollection> CardCollections { get; set; }

        //Adminsitration
        public DbSet<User> Users { get; set; }
    }
}
