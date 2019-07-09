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

            //UserCardCollection Many to Many Relationship
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

            //SpecialCardSpecialCardText Many to Many Relationship
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

            //TrainerCardTrainerCardText Many to Many Relationship
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

            //PokemonCardPokemonType Many to Many Relationship
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

            //PokemonCardEvolvesTo Many to Many Relationship
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

            //PokemonCardWeakness Many to Many Relationship
            modelBuilder.Entity<PokemonCardWeakness>()
                .HasKey(pcw => new { pcw.CardID, pcw.WeaknessID });
            modelBuilder.Entity<PokemonCardWeakness>()
                .HasOne(pcw => pcw.PokemonCard)
                .WithMany(w => w.PokemonCardWeaknesses)
                .HasForeignKey(pcw => pcw.CardID);
            modelBuilder.Entity<PokemonCardWeakness>()
                .HasOne(pcw => pcw.Weakness)
                .WithMany(w => w.PokemonCardWeaknesses)
                .HasForeignKey(pcw => pcw.WeaknessID);

            //PokemonCardAttack Many to Many Relationship
            modelBuilder.Entity<PokemonCardAttack>()
                .HasKey(pca => new { pca.CardID, pca.AttackID });
            modelBuilder.Entity<PokemonCardAttack>()
                .HasOne(pca => pca.PokemonCard)
                .WithMany(a => a.PokemonCardAttacks)
                .HasForeignKey(pca => pca.CardID);
            modelBuilder.Entity<PokemonCardAttack>()
                .HasOne(pca => pca.Attack)
                .WithMany(a => a.PokemonCardAttacks)
                .HasForeignKey(pca => pca.AttackID);

            //PokemonCardPokemonType Many to Many Relationship
            //modelBuilder.Entity<PokemonCardRetreatCost>()
            //    .HasKey(pcrc => new { pcrc.CardID, pcrc.EnergyTypeID });
            //modelBuilder.Entity<PokemonCardRetreatCost>()
            //    .HasOne(pcrc => pcrc.PokemonCard)
            //    .WithMany(pc => pc.PokemonCardRetreatCosts)
            //    .HasForeignKey(pcrc => pcrc.CardID);
            //modelBuilder.Entity<PokemonCardRetreatCost>()
            //    .HasOne(pcrc => pcrc.EnergyType)
            //    .WithMany(rc => rc.PokemonCardRetreatCosts)
            //    .HasForeignKey(pcrc => pcrc.EnergyTypeID);
        }

        //Card Data
        public DbSet<CardCat> CardCats { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<CardRarity> CardRarities { get; set; }
        public DbSet<SetSeries> SetSeries { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }
        public DbSet<EnergyType> EnergyTypes { get; set; }
        public DbSet<EvolvesTo> EvolvesTos { get; set; }
        public DbSet<Weakness> Weaknesses { get; set; }
        public DbSet<Attack> Attacks { get; set; }
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
        public DbSet<PokemonCardRetreatCost> PokemonCardRetreatCosts { get; set; }
        public DbSet<PokemonCardWeakness> PokemonCardWeaknesses { get; set; }
        public DbSet<PokemonCardAttack> PokemonCardAttacks { get; set; }
        public DbSet<AttackEnergy> AttackEnergies { get; set; }

        //Card Collections
        public DbSet<CardCollection> CardCollections { get; set; }

        //Adminsitration
        public DbSet<User> Users { get; set; }
    }
}
