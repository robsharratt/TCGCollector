using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TCGCollector.Models
{
    public class MagicCard
    {
        public int MagicCardID { get; set; }
        public string MagicCardName { get; set; }
        //public string CardImageURL { get; set; }
        //public string CardImageHiURL { get; set; }
        //public string CardImageLocalURL { get; set; }
        //public string CardImageHiLocalURL { get; set; }

        //Foreign Key for Block
        public Nullable<int> MagicSetID { get; set; }
        public MagicSet MagicSet { get; set; }

        //BorderColour
        //Colour

        public bool MagicCardHasFoil { get; set; }
        public bool MagicCardHasNonFoil { get; set; }
        public bool MagicCardHasAltArt { get; set; }
        public bool MagicCardIsArena { get; set; }
        public bool MagicCardIsFullArt { get; set; }
        public bool MagicCardIsMTGO { get; set; }
        public bool MagicCardIsOnlineOnly { get; set; }
        public bool MagicCardIsOversized { get; set; }
        public bool MagicCardIsPaper { get; set; }
        public bool MagicCardIsPromo { get; set; }
        public bool MagicCardIsReprint { get; set; }
        public bool MagicCardIsReserved { get; set; }
        public bool MagicCardIsStarter { get; set; }
        public bool MagicCardIsStorySpotlight { get; set; }
        public bool MagicCardIsTextless { get; set; }
        public bool MagicCardIsTimeshifted { get; set; }

        //Layout
        //Legalities
        //Life
        //Loyalty
        //ManaCost
        //MTGArenaID
        //MTGO

        //Foreign Key for Card Category - Pokemon, Trainer, Energy
        //public Nullable<int> CardCatID { get; set; }
        //public CardCat CardCat { get; set; }

        //Foreign Key for Card Type - Basic, Stage 1, Stage 2, etc
        //public Nullable<int> CardTypeID { get; set; }
        //public CardType CardType { get; set; }



        public string MagicCardNum { get; set; }
        public string MagicCardArtist { get; set; }
        public string MagicCardText { get; set; }

        //Foreign Key for Card Rarity
        //public Nullable<int> CardRarityID { get; set; }
        //public CardRarity CardRarity { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }
    }
}
