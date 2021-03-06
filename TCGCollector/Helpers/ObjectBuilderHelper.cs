﻿
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TCGCollector.Models;

namespace TCGCollector.Helpers
{
    public static class ObjectBuilderHelper
    {
        //Build a CardCat Object from JSON
        public static void BuildCardCatsFromJSON(ApplicationDbContext ctx, string JSONPath)
        {
            JArray obj = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(File.ReadAllText(JSONPath));

            foreach (var result in obj)
            {
                GetCardCatByName(ctx, (string)result["cardcatname"]);
            }
        }

        //CardCat Object Helper with create if not exists
        public static CardCat GetCardCatByName(ApplicationDbContext ctx, string CardCatName)
        {
            CardCat CardCatObj;
            //Check if object already exists and create it if it does not
            CardCatObj = ctx.CardCats.SingleOrDefault(m => m.CardCatName.Equals(CardCatName))
                ?? new CardCat
                {
                    CardCatName = CardCatName,
                    LastUpdateDate = DateTime.Now
                };

            //Put Values here that Need to Update otherwise if the record exists then it'll not be updated
            ctx.AddOrUpdate(CardCatObj);
            ctx.SaveChanges();

            return CardCatObj;
        }

        //CardRarity Object Helper with create if not exists
        public static CardRarity GetCardRarityByName(ApplicationDbContext ctx, string CardRarityName)
        {
            CardRarity CardRarityObj;
            //Check if object already exists and create it if it does not
            CardRarityObj = ctx.CardRarities.SingleOrDefault(m => m.CardRarityName.Equals(CardRarityName))
                ?? new CardRarity
                {
                    CardRarityName = CardRarityName,
                    LastUpdateDate = DateTime.Now
                };

            //Put Values here that Need to Update otherwise if the record exists then it'll not be updated
            ctx.AddOrUpdate(CardRarityObj);
            ctx.SaveChanges();

            return CardRarityObj;
        }

        //Build a CardType Object from JSON
        public static void BuildCardTypesFromJSON(ApplicationDbContext ctx, string JSONPath)
        {
            JArray obj = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(File.ReadAllText(JSONPath));

            foreach (var result in obj)
            {
                GetCardTypeByName(ctx, (string)result["cardtypename"]);
            }
        }

        //CardType Object Helper with create if not exists
        public static CardType GetCardTypeByName(ApplicationDbContext ctx, string CardTypeName)
        {
            CardType CardTypeObj;
            //Check if object already exists and create it if it does not
            CardTypeObj = ctx.CardTypes.SingleOrDefault(m => m.CardTypeName.Equals(CardTypeName))
                ?? new CardType
                {
                    CardTypeName = CardTypeName,
                    LastUpdateDate = DateTime.Now
                };

            //Put Values here that Need to Update otherwise if the record exists then it'll not be updated
            ctx.AddOrUpdate(CardTypeObj);
            ctx.SaveChanges();

            return CardTypeObj;
        }

        //Set Object Helper with no create and return null
        public static Set GetSetByNameNoInsert(ApplicationDbContext ctx, string SetName)
        {
            Set SetObj;
            //Check if object already exists and create it if it does not
            SetObj = ctx.Sets.SingleOrDefault(m => m.SetName.Equals(SetName));

            return SetObj;
        }

        //Build a CardCat Object from JSON
        public static void BuildCardsFromJSON(ApplicationDbContext ctx, IWebHostEnvironment env, string JSONPath)
        {
            JArray obj = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(File.ReadAllText(JSONPath));

            foreach (var result in obj)
            {
                Card CardObj;
                Set SetObj;
                SpecialCard SpecialCardObj;
                TrainerCard TrainerCardObj;
                PokemonCard PokemonCardObj;

                string WebPath = env.WebRootPath;

                WebClient webClient = new WebClient();

                Uri uriCardImageURL = new Uri((string)result["imageUrl"]);
                Uri uriCardImageHiURL = new Uri((string)result["imageUrlHiRes"]);

                //Set base image directories
                string CardImageDirectory = WebPath + "/Images/Cards/LowRes/" + uriCardImageURL.Segments.ElementAt(uriCardImageURL.Segments.Length - 2).TrimEnd('/');
                string CardImageHiDirectory = WebPath + "/Images/Cards/HighRes/" + uriCardImageHiURL.Segments.ElementAt(uriCardImageHiURL.Segments.Length - 2).TrimEnd('/');

                //Check if directory exists and create if it doesn't
                if (!Directory.Exists(CardImageDirectory))
                {
                    Directory.CreateDirectory(CardImageDirectory);
                }
                if (!Directory.Exists(CardImageHiDirectory))
                {
                    Directory.CreateDirectory(CardImageHiDirectory);
                }

                //Create the local image file paths
                string CardImageLocalFile = uriCardImageURL.Segments.ElementAt(uriCardImageURL.Segments.Length - 2).TrimEnd('/') + uriCardImageURL.Segments.Last();
                string CardImageHiLocalFile = uriCardImageHiURL.Segments.ElementAt(uriCardImageHiURL.Segments.Length - 2).TrimEnd('/') + uriCardImageHiURL.Segments.Last();

                string CardImageLocalPath = CardImageDirectory + "/" + CardImageLocalFile;
                string CardImageHiLocalPath = CardImageHiDirectory + "/" + CardImageHiLocalFile;

                try
                {
                    //Only download images if there isn't already a file with this name
                    if (!File.Exists(CardImageLocalPath))
                    {
                        webClient.DownloadFile(uriCardImageURL, CardImageLocalPath);
                    }
                }
                catch (System.Net.WebException we)
                {
                    Console.WriteLine("ERROR: " + we.Message + ": " + uriCardImageURL);
                    //throw we;

                }
                catch (Exception e)
                {
                    //ILogger logger = Get;
                    //logger.LogWarning("ERROR: " + e.Message + ": " + uriCardImageURL);
                    Console.WriteLine("ERROR: " + e.Message + ": " + uriCardImageURL);
                    throw e;
                }

                try
                {
                    //Only download images if there isn't already a file with this name
                    if (!File.Exists(CardImageHiLocalPath))
                    {
                        webClient.DownloadFile(uriCardImageHiURL, CardImageHiLocalPath);
                    }
                }
                catch (System.Net.WebException we)
                {
                    Console.WriteLine("ERROR: " + we.Message + ": " + uriCardImageHiURL);
                    //throw we;
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: " + e.Message + ": " + uriCardImageHiURL);
                    throw e;

                }

                //Store the local image URL path for web access
                string CardImageLocalURL = "/Images/Cards/LowRes/" + uriCardImageURL.Segments.ElementAt(uriCardImageURL.Segments.Length - 2) + CardImageLocalFile;
                string CardImageHiLocalURL = "/Images/Cards/HighRes/" + uriCardImageHiURL.Segments.ElementAt(uriCardImageHiURL.Segments.Length - 2) + CardImageHiLocalFile;


                //Get a Generic Set Object
                SetObj = ObjectBuilderHelper.GetSetByNameNoInsert(ctx, (string)result["set"]);

                switch ((string)result["supertype"])
                {
                    case "Energy":
                        switch ((string)result["subtype"])
                        {
                            case "Basic":
                                //Basic Energy
                                CardObj = ctx.Cards.SingleOrDefault(m => m.CardName.Equals((string)result["name"]) && m.CardNum.Equals((string)result["number"]))
                                    ?? new Card
                                    {
                                        CardName = (string)result["name"],
                                        CardImageURL = (string)result["imageUrl"],
                                        CardImageHiURL = (string)result["imageUrlHiRes"],
                                        CardImageLocalURL = CardImageLocalURL,
                                        CardImageHiLocalURL = CardImageHiLocalURL,
                                        CardCat = ObjectBuilderHelper.GetCardCatByName(ctx, (string)result["supertype"]),
                                        CardType = ObjectBuilderHelper.GetCardTypeByName(ctx, (string)result["subtype"]),
                                        Set = ObjectBuilderHelper.GetSetByNameNoInsert(ctx, (string)result["set"]),
                                        CardNum = (string)result["number"],
                                        Artist = (string)result["artist"],
                                        CardRarity = ObjectBuilderHelper.GetCardRarityByName(ctx, (string)result["rarity"]),
                                        LastUpdateDate = DateTime.Now
                                    };

                                Console.WriteLine("INFO: Card: " + CardObj.CardNum + " " + CardObj.CardName);

                                ctx.AddOrUpdate(CardObj);
                                break;
                            case "Special":
                                //Special Energy
                                SpecialCardObj = ctx.SpecialCards.SingleOrDefault(m => m.CardName.Equals((string)result["name"]) && m.CardNum.Equals((string)result["number"]))
                                    ?? new SpecialCard
                                    {
                                        CardName = (string)result["name"],
                                        CardImageURL = (string)result["imageUrl"],
                                        CardImageHiURL = (string)result["imageUrlHiRes"],
                                        CardImageLocalURL = CardImageLocalURL,
                                        CardImageHiLocalURL = CardImageHiLocalURL,
                                        CardCat = ObjectBuilderHelper.GetCardCatByName(ctx, (string)result["supertype"]),
                                        CardType = ObjectBuilderHelper.GetCardTypeByName(ctx, (string)result["subtype"]),
                                        Set = ObjectBuilderHelper.GetSetByNameNoInsert(ctx, (string)result["set"]),
                                        CardNum = (string)result["number"],
                                        Artist = (string)result["artist"],
                                        CardRarity = ObjectBuilderHelper.GetCardRarityByName(ctx, (string)result["rarity"]),
                                        LastUpdateDate = DateTime.Now
                                    };

                                Console.WriteLine("INFO: Special Card: " + SpecialCardObj.CardNum + " " + SpecialCardObj.CardName);

                                //SpecialCardText
                                if (result["text"] != null && result["text"].HasValues)
                                {
                                    List<SpecialCardSpecialCardText> specialCardCardTexts = new List<SpecialCardSpecialCardText>();
                                    foreach (var textitem in result["text"])
                                    {
                                        SpecialCardText SpecialCardTextObj = ctx.SpecialCardTexts.SingleOrDefault(m => m.CardTextLine.Equals((string)textitem))
                                            ?? new SpecialCardText
                                            {
                                                CardTextLine = textitem.ToString(),
                                                LastUpdateDate = DateTime.Now
                                            };

                                        if (SpecialCardTextObj != null)
                                        {
                                            SpecialCardSpecialCardText specialCardSpecialCardText = new SpecialCardSpecialCardText();
                                            //if (SpecialCardObj.SpecialCardSpecialCardTexts != null)
                                            //{
                                            //    specialCardSpecialCardText = SpecialCardTextObj.SpecialCardSpecialCardTexts.SingleOrDefault(m => m.CardID.Equals(SpecialCardObj.CardID) && m.CardTextID.Equals(SpecialCardTextObj.SpecialCardTextID));

                                            //    if (specialCardSpecialCardText == null)
                                            //    {

                                            //Check list for existing object
                                            if (!specialCardCardTexts.Exists(a => a.CardID.Equals(SpecialCardObj) && a.CardText.Equals(SpecialCardTextObj)))
                                            {
                                                if (SpecialCardObj.SpecialCardSpecialCardTexts != null)
                                                {
                                                    specialCardSpecialCardText = SpecialCardTextObj.SpecialCardSpecialCardTexts.SingleOrDefault(m => m.CardID.Equals(SpecialCardObj) && m.CardTextID.Equals(SpecialCardTextObj));
                                                }

                                                if (specialCardSpecialCardText == null)
                                                {
                                                    specialCardCardTexts.Add(
                                                        new SpecialCardSpecialCardText
                                                        {
                                                            SpecialCard = SpecialCardObj,
                                                            CardText = SpecialCardTextObj
                                                        }
                                                    );
                                                }
                                            }
                                        }
                                    }

                                    SpecialCardObj.SpecialCardSpecialCardTexts = specialCardCardTexts;
                                }
                                ctx.AddOrUpdate(SpecialCardObj);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Pokémon":
                        //int ConvRetreatCost = 0;
                        //if (result["convertedRetreatCost"] is null)
                        //{
                        //    ConvRetreatCost = 0;
                        //} else
                        //{
                        //    ConvRetreatCost = (int)result["convertedRetreatCost"];
                        //}
                        int NationalPokedexNumValue = -1;
                        int HPValue = -1;

                        if (result["nationalPokedexNumber"] != null)
                        {
                            NationalPokedexNumValue = (int)result["nationalPokedexNumber"];
                        }

                        if (result["hp"] != null)
                        {
                            HPValue = (int)result["hp"];
                        }

                        //Set SetObj = ctx.Sets.SingleOrDefault(m => m.SetCode.Equals((string)result["SetCode"]));

                        PokemonCardObj = ctx.PokemonCards.SingleOrDefault(m => m.CardName.Equals((string)result["name"]) && m.CardNum.Equals((string)result["number"]) && m.SetID == SetObj.SetID)
                            ?? new PokemonCard
                            {
                                CardName = (string)result["name"],
                                CardImageURL = (string)result["imageUrl"],
                                CardImageHiURL = (string)result["imageUrlHiRes"],
                                CardImageLocalURL = CardImageLocalURL,
                                CardImageHiLocalURL = CardImageHiLocalURL,
                                CardCat = ObjectBuilderHelper.GetCardCatByName(ctx, (string)result["supertype"]),
                                CardType = ObjectBuilderHelper.GetCardTypeByName(ctx, (string)result["subtype"]),
                                Set = SetObj,
                                CardNum = (string)result["number"],
                                Artist = (string)result["artist"],
                                CardRarity = ObjectBuilderHelper.GetCardRarityByName(ctx, (string)result["rarity"]),
                                HP = HPValue,
                                //ConvertedRetreatCost = ConvRetreatCost,
                                //ConvertedRetreatCost = GetValueOrDefault<int>(result["convertedRetreatCost"]),
                                NationalPokedexNumber = NationalPokedexNumValue,
                                EvolvesFrom = (string)result["evolvesFrom"],
                                LastUpdateDate = DateTime.Now
                            };

                        Console.WriteLine("INFO: Pokemon Card: " + PokemonCardObj.CardNum + " " + PokemonCardObj.CardName);

                        //PokemonTypes
                        if (result["types"] != null && result["types"].HasValues)
                        {
                            List<PokemonCardPokemonType> pokemonCardPokemonTypes = new List<PokemonCardPokemonType>();
                            foreach (var textitem in result["types"])
                            {
                                PokemonType PokemonTypeObj = GetPokemonTypeByName(ctx, (string)textitem);

                                pokemonCardPokemonTypes.Add(
                                    new PokemonCardPokemonType
                                    {
                                        PokemonCard = PokemonCardObj,
                                        PokemonType = PokemonTypeObj
                                    }
                                );
                            }

                            PokemonCardObj.PokemonCardPokemonTypes = pokemonCardPokemonTypes;
                        }

                        ctx.AddOrUpdate(PokemonCardObj);
                        ctx.SaveChanges();

                        //EvolvesTo
                        if (result["evolvesTo"] != null && result["evolvesTo"].HasValues)
                        {
                            List<PokemonCardEvolvesTo> pokemonCardEvolvesTos = new List<PokemonCardEvolvesTo>();
                            foreach (var textitem in result["evolvesTo"])
                            {
                                EvolvesTo EvolvesToObj = GetEvolesToByName(ctx, (string)textitem);

                                //Check if the relationship exists and if not add it
                                if (EvolvesToObj != null)
                                {
                                    PokemonCardEvolvesTo pokemonCardEvolvesTo = new PokemonCardEvolvesTo();
                                    if (PokemonCardObj.PokemonCardEvolvesTos != null)
                                    {
                                        pokemonCardEvolvesTo = PokemonCardObj.PokemonCardEvolvesTos.SingleOrDefault(m => m.CardID.Equals(PokemonCardObj) && m.EvolvesTo.Equals(EvolvesToObj));

                                        if (pokemonCardEvolvesTo == null)
                                        {
                                            pokemonCardEvolvesTos.Add(
                                                new PokemonCardEvolvesTo
                                                {
                                                    PokemonCard = PokemonCardObj,
                                                    EvolvesTo = EvolvesToObj
                                                }
                                            );
                                        }
                                    }
                                    //else
                                    //{
                                    //    pokemonCardEvolvesTo.PokemonCard = PokemonCardObj;
                                    //    pokemonCardEvolvesTo.EvolvesTo = EvolvesToObj;
                                    //}
                                }
                            }

                            PokemonCardObj.PokemonCardEvolvesTos = pokemonCardEvolvesTos;
                        }

                        ctx.AddOrUpdate(PokemonCardObj);
                        ctx.SaveChanges();

                        //RetreatCosts
                        if (result["retreatCost"] != null && result["retreatCost"].HasValues)
                        {
                            List<PokemonCardRetreatCost> pokemonCardRetreatCosts = new List<PokemonCardRetreatCost>();
                            foreach (var textitem in result["retreatCost"])
                            {
                                EnergyType EnergyTypeObj = GetEnergyTypeByName(ctx, (string)textitem);

                                //Check if the relationship exists and if not add it
                                if (EnergyTypeObj != null)
                                {
                                    PokemonCardRetreatCost pokemonCardRetreatCost = new PokemonCardRetreatCost();
                                    if (PokemonCardObj.PokemonCardRetreatCosts != null)
                                    {
                                        pokemonCardRetreatCost = PokemonCardObj.PokemonCardRetreatCosts.SingleOrDefault(m => m.CardID.Equals(PokemonCardObj.CardID) && m.EnergyType.Equals(EnergyTypeObj));

                                        if (pokemonCardRetreatCost == null)
                                        {
                                            //pokemonCardRetreatCosts.Add(
                                            //    new PokemonCardRetreatCost
                                            //    {
                                            //        PokemonCard = PokemonCardObj,
                                            //        EnergyType = EnergyTypeObj
                                            //    }
                                            //);
                                            pokemonCardRetreatCost.PokemonCard = PokemonCardObj;
                                            pokemonCardRetreatCost.EnergyType = EnergyTypeObj;
                                        }
                                    }
                                    else
                                    {
                                        pokemonCardRetreatCosts.Add(
                                            new PokemonCardRetreatCost
                                            {
                                                PokemonCard = PokemonCardObj,
                                                EnergyType = EnergyTypeObj
                                            }
                                        );

                                        //pokemonCardRetreatCost.PokemonCard = PokemonCardObj;
                                        //pokemonCardRetreatCost.EnergyType = EnergyTypeObj;
                                    }
                                }
                            }

                            PokemonCardObj.PokemonCardRetreatCosts = pokemonCardRetreatCosts;
                        }

                        ctx.AddOrUpdate(PokemonCardObj);
                        ctx.SaveChanges();

                        //Weaknesses
                        if (result["weaknesses"] != null && result["weaknesses"].HasValues)
                        {
                            //JArray obj2 = JArray.Parse(result["weaknesses"]);
                            //Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>((string)result["weaknesses"]);
                            JArray obj2 = (JArray)result.SelectToken("weaknesses");

                            List<PokemonCardWeakness> pokemonCardWeaknesses = new List<PokemonCardWeakness>();

                            foreach (var result2 in obj2)
                            {
                                EnergyType EnergyTypeObj = GetEnergyTypeByName(ctx, (string)result2["type"]);

                                //Check list for existing object
                                if (!pokemonCardWeaknesses.Exists(a => a.Weakness.EnergyType.Equals(EnergyTypeObj)
                                    && a.Weakness.WeaknessValue.Equals((string)result2["value"])))
                                {
                                    Weakness WeaknessObj = ctx.Weaknesses.SingleOrDefault(m => m.EnergyType.Equals(EnergyTypeObj) && m.WeaknessValue.Equals((string)result2["value"]))
                                    ?? new Weakness
                                    {
                                        EnergyType = EnergyTypeObj,
                                        WeaknessValue = (string)result2["value"],
                                        LastUpdateDate = DateTime.Now
                                    };

                                    //Check if the relationship exists and if not add it
                                    if (WeaknessObj != null)
                                    {
                                        PokemonCardWeakness pokemonCardWeakness = new PokemonCardWeakness();
                                        if (PokemonCardObj.PokemonCardWeaknesses != null)
                                        {
                                            pokemonCardWeakness = PokemonCardObj.PokemonCardWeaknesses.SingleOrDefault(m => m.CardID.Equals(PokemonCardObj.CardID) && m.Weakness.Equals(WeaknessObj));

                                            if (pokemonCardWeakness == null)
                                            {
                                                pokemonCardWeaknesses.Add(
                                                new PokemonCardWeakness
                                                {
                                                    PokemonCard = PokemonCardObj,
                                                    Weakness = WeaknessObj
                                                }
                                                );
                                            }
                                        }
                                    }
                                }
                            }

                            PokemonCardObj.PokemonCardWeaknesses = pokemonCardWeaknesses;
                        }

                        ctx.AddOrUpdate(PokemonCardObj);
                        ctx.SaveChanges();

                        //Resistance
                        if (result["resistances"] != null && result["resistances"].HasValues)
                        {
                            //JArray obj2 = JArray.Parse(result["weaknesses"]);
                            //Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>((string)result["weaknesses"]);
                            JArray obj2 = (JArray)result.SelectToken("resistances");

                            List<PokemonCardResistance> pokemonCardResistances = new List<PokemonCardResistance>();

                            foreach (var result2 in obj2)
                            {
                                EnergyType EnergyTypeObj = GetEnergyTypeByName(ctx, (string)result2["type"]);

                                //Check if list already has the object in it
                                if (!pokemonCardResistances.Exists(a => a.Resistance.EnergyType.Equals(EnergyTypeObj)
                                        && a.Resistance.ResistanceValue.Equals((string)result2["value"])))
                                {

                                    Resistance ResistanceObj = ctx.Resistances.SingleOrDefault(m => m.EnergyType.Equals(EnergyTypeObj) && m.ResistanceValue.Equals((string)result2["value"]))
                                        ?? new Resistance
                                        {
                                            EnergyType = EnergyTypeObj,
                                            ResistanceValue = (string)result2["value"],
                                            LastUpdateDate = DateTime.Now
                                        };

                                    if (ResistanceObj != null)
                                    {
                                        PokemonCardResistance pokemonCardResistance = new PokemonCardResistance();
                                        if (PokemonCardObj.PokemonCardResistances != null)
                                        {
                                            pokemonCardResistance = PokemonCardObj.PokemonCardResistances.SingleOrDefault(m => m.CardID.Equals(PokemonCardObj.CardID) && m.Resistance.Equals(ResistanceObj));

                                            if (pokemonCardResistance == null)
                                            {
                                                pokemonCardResistances.Add(
                                                    new PokemonCardResistance
                                                    {
                                                        PokemonCard = PokemonCardObj,
                                                        Resistance = ResistanceObj
                                                    }
                                                    );
                                            }
                                        }
                                    }
                                    //ctx.AddOrUpdate(pokemonCardResistances);
                                    //ctx.SaveChanges();
                                }
                            }

                            PokemonCardObj.PokemonCardResistances = pokemonCardResistances;
                        }

                        ctx.AddOrUpdate(PokemonCardObj);
                        ctx.SaveChanges();

                        //Ability
                        if (result["ability"] != null && result["ability"].HasValues)
                        {
                            //JArray obj2 = JArray.Parse(result["weaknesses"]);
                            //Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>((string)result["weaknesses"]);
                            JObject AbilityJSON = (JObject)result.SelectToken("ability");

                            List<PokemonCardAbility> pokemonCardAbilities = new List<PokemonCardAbility>();

                            //foreach (var result2 in obj2)
                            //{
                            // EnergyType EnergyTypeObj = GetEnergyTypeByName(ctx, (string)result2["type"]);
                            Ability AbilityObj = ctx.Abilities.SingleOrDefault(m => m.AbilityName.Equals((string)AbilityJSON["name"]) && m.AbilityText.Equals((string)AbilityJSON["text"]))
                                ?? new Ability
                                {
                                    AbilityName = (string)AbilityJSON["name"],
                                    AbilityText = (string)AbilityJSON["text"],
                                    AbilityType = (string)AbilityJSON["type"],
                                    LastUpdateDate = DateTime.Now
                                };

                            //Check if the relationship exists and if not add it
                            if (AbilityObj != null)
                            {
                                PokemonCardAbility pokemonCardAbility = new PokemonCardAbility();
                                if (PokemonCardObj.PokemonCardAbilities != null)
                                {
                                    pokemonCardAbility = PokemonCardObj.PokemonCardAbilities.SingleOrDefault(m => m.CardID.Equals(PokemonCardObj.CardID) && m.Ability.Equals(AbilityObj));
                                }

                                if (pokemonCardAbility.Ability == null)
                                {
                                    pokemonCardAbilities.Add(
                                        new PokemonCardAbility
                                        {
                                            PokemonCard = PokemonCardObj,
                                            Ability = AbilityObj
                                        }
                                    );
                                }

                            }
                            //}

                            PokemonCardObj.PokemonCardAbilities = pokemonCardAbilities;
                        }

                        ctx.AddOrUpdate(PokemonCardObj);
                        ctx.SaveChanges();

                        //Attack
                        if (result["attacks"] != null && result["attacks"].HasValues)
                        {
                            JArray obj2 = (JArray)result.SelectToken("attacks");

                            List<PokemonCardAttack> pokemonCardAttacks = new List<PokemonCardAttack>();

                            foreach (var result2 in obj2)
                            {
                                //EnergyType EnergyTypeObj = GetEnergyTypeByName(ctx, (string)result2["type"]);
                                Attack AttackObj = ctx.Attacks.SingleOrDefault(m => m.AttackName.Equals((string)result2["name"]) && m.AttackText.Equals((string)result2["text"]))
                                    ?? new Attack
                                    {
                                        //EnergyType = EnergyTypeObj,
                                        AttackName = (string)result2["name"],
                                        AttackConvertedEnergyCost = (int)result2["convertedEnergyCost"],
                                        AttackDamage = (string)result2["damage"],
                                        AttackText = (string)result2["text"],
                                        LastUpdateDate = DateTime.Now
                                    };

                                //Energy for Attack
                                if (result2["cost"] != null && result2["cost"].HasValues)
                                {
                                    List<AttackEnergy> attackEnergies = new List<AttackEnergy>();
                                    foreach (var textitem in result2["cost"])
                                    {
                                        EnergyType EnergyTypeObj = GetEnergyTypeByName(ctx, (string)textitem);

                                        attackEnergies.Add(
                                            new AttackEnergy
                                            {
                                                Attack = AttackObj,
                                                EnergyType = EnergyTypeObj
                                            }
                                        );
                                    }

                                    AttackObj.AttackEnergies = attackEnergies;
                                }

                                //Check if the relationship exists and if not add it
                                if (AttackObj != null)
                                {
                                    PokemonCardAttack pokemonCardAttack = new PokemonCardAttack();
                                    if (PokemonCardObj.PokemonCardAttacks != null)
                                    {
                                        pokemonCardAttack = PokemonCardObj.PokemonCardAttacks.SingleOrDefault(m => m.CardID.Equals(PokemonCardObj.CardID) && m.Attack.Equals(AttackObj));
                                    }

                                    if (pokemonCardAttack.Attack == null)
                                    {
                                        pokemonCardAttacks.Add(
                                            new PokemonCardAttack
                                            {
                                                PokemonCard = PokemonCardObj,
                                                Attack = AttackObj
                                            }
                                            );
                                    }
                                }
                            }

                            PokemonCardObj.PokemonCardAttacks = pokemonCardAttacks;
                        }

                        ctx.AddOrUpdate(PokemonCardObj);
                        ctx.SaveChanges();

                        ctx.AddOrUpdate(PokemonCardObj);
                        break;
                    case "Trainer":
                        TrainerCardObj = ctx.TrainerCards.SingleOrDefault(m => m.CardName.Equals((string)result["name"]) && m.CardNum.Equals((string)result["number"]))
                            ?? new TrainerCard
                            {
                                CardName = (string)result["name"],
                                CardImageURL = (string)result["imageUrl"],
                                CardImageHiURL = (string)result["imageUrlHiRes"],
                                CardImageLocalURL = CardImageLocalURL,
                                CardImageHiLocalURL = CardImageHiLocalURL,
                                CardCat = ObjectBuilderHelper.GetCardCatByName(ctx, (string)result["supertype"]),
                                CardType = ObjectBuilderHelper.GetCardTypeByName(ctx, (string)result["subtype"]),
                                Set = ObjectBuilderHelper.GetSetByNameNoInsert(ctx, (string)result["set"]),
                                CardNum = (string)result["number"],
                                Artist = (string)result["artist"],
                                CardRarity = ObjectBuilderHelper.GetCardRarityByName(ctx, (string)result["rarity"]),
                                LastUpdateDate = DateTime.Now
                            };

                        Console.WriteLine("INFO: Trainer Card: " + TrainerCardObj.CardNum + " " + TrainerCardObj.CardName);

                        if (result["text"] != null && result["text"].HasValues)
                        {
                            List<TrainerCardTrainerCardText> trainerCardCardTexts = new List<TrainerCardTrainerCardText>();
                            foreach (var textitem in result["text"])
                            {
                                TrainerCardText TrainerCardTextObj = ctx.TrainerCardTexts.SingleOrDefault(m => m.CardTextLine.Equals((string)textitem))
                                    ?? new TrainerCardText
                                    {
                                        CardTextLine = textitem.ToString(),
                                        LastUpdateDate = DateTime.Now
                                    };

                                if (TrainerCardTextObj != null)
                                {
                                    TrainerCardTrainerCardText trainerCardTrainerCardText = new TrainerCardTrainerCardText();
                                    //if (TrainerCardObj.TrainerCardTrainerCardTexts == null)
                                    //{

                                    //Check list for existing object
                                    if (!trainerCardCardTexts.Exists(a => a.CardID.Equals(TrainerCardObj) && a.CardTextID.Equals(TrainerCardTextObj)))
                                    {
                                        if (TrainerCardObj.TrainerCardTrainerCardTexts != null)
                                        {
                                            trainerCardTrainerCardText = TrainerCardTextObj.TrainerCardTrainerCardTexts.SingleOrDefault(m => m.CardID.Equals(TrainerCardObj) && m.CardTextID.Equals(TrainerCardTextObj));
                                        }

                                        if (trainerCardTrainerCardText == null)
                                        {
                                            trainerCardCardTexts.Add(
                                                new TrainerCardTrainerCardText
                                                {
                                                    TrainerCard = TrainerCardObj,
                                                    CardText = TrainerCardTextObj
                                                }
                                            );
                                        }
                                    }
                                }
                            }

                            TrainerCardObj.TrainerCardTrainerCardTexts = trainerCardCardTexts;
                        }
                        ctx.AddOrUpdate(TrainerCardObj);
                        break;
                    default:
                        break;
                }
                //If Card - CardCat = Energy, CardType = Basic
                //If SpecialCard - CardCat = Energy. CardType = Special
                //If PokemonCard
                //If TrainerCar
                //GetCardByName(ctx, (string)result["pokemontypename"]);

                ctx.SaveChanges();
            }
        }

        //CardCat Object Helper with create if not exists
        //public static Card GetCardByName(ApplicationDbContext ctx, string CardName, int CardNum)
        //{
        //    Card CardObj;
        ////Check if object already exists and create it if it does not
        //CardObj = ctx.Cards.SingleOrDefault(m => m.CardName.Equals(CardName) && m.CardNum == CardNum)
        //    ?? new Card()
        //    {
        //        CardName = PokemonTypeName,
        //        LastUpdateDate = DateTime.Now
        //    };

        ////Put Values here that Need to Update otherwise if the record exists then it'll not be updated
        //ctx.AddOrUpdate(CardObj);
        //ctx.SaveChanges();

        //    return CardObj;
        //}

        //Build a PokemoneType Object from JSON
        public static void BuildPokemonTypesFromJSON(ApplicationDbContext ctx, string JSONPath)
        {
            JArray obj = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(File.ReadAllText(JSONPath));

            foreach (var result in obj)
            {
                GetPokemonTypeByName(ctx, (string)result["pokemontypename"]);
            }
        }

        //PokemonType Object Helper with create if not exists
        public static PokemonType GetPokemonTypeByName(ApplicationDbContext ctx, string PokemonTypeName)
        {
            PokemonType PokemonTypeObj;
            //Check if object already exists and create it if it does not
            PokemonTypeObj = ctx.PokemonTypes.SingleOrDefault(m => m.PokemonTypeName.Equals(PokemonTypeName))
                ?? new PokemonType
                {
                    PokemonTypeName = PokemonTypeName,
                    LastUpdateDate = DateTime.Now
                };

            //Put Values here that Need to Update otherwise if the record exists then it'll not be updated
            ctx.AddOrUpdate(PokemonTypeObj);
            ctx.SaveChanges();

            return PokemonTypeObj;
        }

        //Build a EnergyType Object from JSON
        public static void BuildEnergyTypesFromJSON(ApplicationDbContext ctx, string JSONPath)
        {
            JArray obj = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(File.ReadAllText(JSONPath));

            foreach (var result in obj)
            {
                GetEnergyTypeByName(ctx, (string)result["energytypename"]);
            }
        }

        //EnergyType Object Helper with create if not exists
        public static EnergyType GetEnergyTypeByName(ApplicationDbContext ctx, string EnergyTypeName)
        {
            EnergyType EnergyTypeObj;
            //Check if object already exists and create it if it does not
            EnergyTypeObj = ctx.EnergyTypes.SingleOrDefault(m => m.EnergyTypeName.Equals(EnergyTypeName))
                ?? new EnergyType
                {
                    EnergyTypeName = EnergyTypeName,
                    LastUpdateDate = DateTime.Now
                };

            //Put Values here that Need to Update otherwise if the record exists then it'll not be updated
            ctx.AddOrUpdate(EnergyTypeObj);
            ctx.SaveChanges();

            return EnergyTypeObj;
        }

        //Build a Set Object from JSON
        public static void BuildSetsFromJSON(ApplicationDbContext ctx, IWebHostEnvironment env, string JSONPath)
        {
            JArray obj = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(File.ReadAllText(JSONPath));

            foreach (var result in obj)
            {
                string WebPath = env.WebRootPath;

                WebClient webClient = new WebClient();

                Uri uriSetSymbolURL = new Uri((string)result["symbolUrl"]);
                Uri uriSetLogoURL = new Uri((string)result["logoUrl"]);
                string SymbolLocalPath = WebPath + "/Images/Sets/" + uriSetSymbolURL.Segments.ElementAt(uriSetSymbolURL.Segments.Length - 2).TrimEnd('/') + uriSetSymbolURL.Segments.Last();
                string LogoLocalPath = WebPath + "/Images/Sets/" + uriSetLogoURL.Segments.ElementAt(uriSetLogoURL.Segments.Length - 2).TrimEnd('/') + uriSetLogoURL.Segments.Last();

                //Only download images if there isn't already a file with this name
                if (!File.Exists(SymbolLocalPath))
                {
                    webClient.DownloadFile(uriSetSymbolURL, SymbolLocalPath);
                }

                //Only download images if there isn't already a file with this name
                if (!File.Exists(LogoLocalPath))
                {
                    webClient.DownloadFile(uriSetLogoURL, LogoLocalPath);
                }

                Set SetObj = ctx.Sets.SingleOrDefault(m => m.SetName.Equals((string)result["name"]) && m.SetCode.Equals((string)result["code"]))
                    ?? new Set
                    {
                        SetName = (string)result["name"],
                        SetCode = (string)result["code"],
                        SetPTCGOCode = (string)result["ptcgoCode"],
                        SetSeries = ObjectBuilderHelper.GetSetSeriesByName(ctx, (string)result["series"]),
                        //SetSeries = context.SetSeries.FirstOrDefault(m => m.SetSeriesName.Equals("Sun & Moon")),
                        SetTotalCards = (int)result["totalCards"],
                        SetStandard = (bool)result["standardLegal"],
                        SetExpanded = (bool)result["expandedLegal"],
                        SetSymbolURL = (string)result["symbolUrl"],
                        SetLogoURL = (string)result["logoUrl"],
                        SetSymbolLocalURL = SymbolLocalPath,
                        SetLogoLocalURL = LogoLocalPath,
                        SetReleaseDate = DateTime.ParseExact((string)result["releaseDate"], "MM/dd/yyyy", CultureInfo.InvariantCulture),
                        LastUpdateDate = DateTime.Now
                    };
                //Put Values here that Need to Update otherwise if the record exists then it'll not be updated
                //SetObj.SetTotalCards = (int)result["totalCards"];

                ctx.AddOrUpdate(SetObj);
                ctx.SaveChanges();
            }
        }

        //SetSeries Object Helper with create if not exists
        public static SetSeries GetSetSeriesByName(ApplicationDbContext ctx, string SetSeriesName)
        {
            SetSeries SetSeriesObj;
            //Check if object already exists and create it if it does not
            SetSeriesObj = ctx.SetSeries.SingleOrDefault(m => m.SetSeriesName.Equals(SetSeriesName))
                ?? new SetSeries
                {
                    SetSeriesName = SetSeriesName,
                    LastUpdateDate = DateTime.Now
                };

            //Put Values here that Need to Update otherwise if the record exists then it'll not be updated
            ctx.AddOrUpdate(SetSeriesObj);
            ctx.SaveChanges();

            return SetSeriesObj;
        }

        //SetSeries Object Helper with create if not exists
        public static EvolvesTo GetEvolesToByName(ApplicationDbContext ctx, string EvolvesToName)
        {
            EvolvesTo EvolvesToObj;
            //Check if object already exists and create it if it does not
            EvolvesToObj = ctx.EvolvesTos.SingleOrDefault(m => m.EvolvesToName.Equals(EvolvesToName))
                 ?? new EvolvesTo
                 {
                     EvolvesToName = EvolvesToName,
                     LastUpdateDate = DateTime.Now
                 };

            //Put Values here that Need to Update otherwise if the record exists then it'll not be updated
            ctx.AddOrUpdate(EvolvesToObj);
            ctx.SaveChanges();

            return EvolvesToObj;
        }

        //Return int or 0
        public static T GetValueOrDefault<T>(object value)
        {
            if (value is T)
                return (T)value;
            else
                return default(T);
        }
    }
}
