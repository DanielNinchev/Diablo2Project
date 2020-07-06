using Diablo2Project.Entities.Abilities;
using Diablo2Project.Entities.Abilities.BarbarianAbilities;
using Diablo2Project.Entities.Abilities.Factory;
using Diablo2Project.Entities.Abilities.SorceressAbilities;
using Diablo2Project.Entities.Characters;
using Diablo2Project.Entities.Characters.Factory;
using Diablo2Project.Entities.ChosenCharacter;
using Diablo2Project.Entities.Contracts;
using Diablo2Project.Entities.Enums;
using Diablo2Project.Entities.Items.Factory;
using Diablo2Project.Entities.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diablo2Project.Core
{
    public class Server
    {
        private readonly List<Character> party;
        private readonly List<BarbarianAbility> barbAbility;
        private readonly List<SorceressAbility> sorcAbility;
        private readonly List<PaladinAbility> palAbility;
        private readonly Stack<Item> barbGearList;
        private readonly Stack<Item> sorcGearList;
        private readonly Stack<Item> palGearList;
        private readonly ItemFactory itemFactory;
        private readonly CharacterFactory characterFactory;
        private readonly BarbarianAbilityFactory barbAbilityFactory;
        private readonly SorceressAbilityFactory sorcAbilityFactory;
        private readonly PaladinAbilityFactory palAbilityFactory;
        private int lastSurviverRounds;

        public Server()
        {
            party = new List<Character>();
            barbAbility = new List<BarbarianAbility>() { new Battlecry(), new Ferocity() };
            sorcAbility = new List<SorceressAbility>() { new Blizzard(), new Lightning() };
            palAbility = new List<PaladinAbility>() { new Charge(), new Zealotry() };
            barbGearList = new Stack<Item>();
            sorcGearList = new Stack<Item>();
            palGearList = new Stack<Item>();
            itemFactory = new ItemFactory();
            characterFactory = new CharacterFactory();
            barbAbilityFactory = new BarbarianAbilityFactory();
            palAbilityFactory = new PaladinAbilityFactory();
        }

        public string JoinServer(string[] args)
        {
            if (args.Length != 2)
            {
                throw new InvalidOperationException($"use the commands properly!");
            }

            var characterClass = args[0];
            var name = args[1];

            var character = characterFactory.CreateCharacter(characterClass, name);

            party.Add(character);

            return $"{character.Name} joined the server.";
        }

        public string CollectItemsByCharacters(string[] args)
        {
            if (args.Length != 2)
            {
                throw new InvalidOperationException($"use the commands properly!");
            }

            var characterName = args[0];
            var character = FindCharacter(characterName);

            var itemName = args[1];
            Item item;
            item = itemFactory.CreateItem(itemName);

            if (character.CharacterGear.AllowedItems==item.ItemDesignedForCharacter)
            {
                character.CollectItemInGear(item);
            }
            else
            {
                return $"{itemName} cannot be used by this character.";
            }

            return $"{itemName} has been added to the character's gear.";
            
        }
        private Character FindCharacter(string characterName)
        {
            var character = party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character with {characterName} has not been found!");
            }

            return character;
        }

        private BarbarianAbility FindBarbarianAbility(string abilityName)
        {
            var chosenAbility = barbAbility.FirstOrDefault(c => c.BarbAbility == abilityName);

            if (chosenAbility == null)
            {
                throw new ArgumentException($"{abilityName} does not exist.");
            }

            return chosenAbility;
        }
        private SorceressAbility FindSorceressAbility(string abilityName)
        {
            var chosenAbility = sorcAbility.FirstOrDefault(c => c.SorcAbility == abilityName);

            if (chosenAbility == null)
            {
                throw new ArgumentException($"{abilityName} does not exist.");
            }

            return chosenAbility;
        }

        private PaladinAbility FindPaladinAbility(string abilityName)
        {
            var chosenAbility = palAbility.FirstOrDefault(c => c.PalAbility == abilityName);

            if (chosenAbility == null)
            {
                throw new ArgumentException($"{abilityName} does not exist.");
            }

            return chosenAbility;
        }

        public string UseItemBy(string[] args)
        {
            if (args.Length != 2)
            {
                throw new InvalidOperationException($"please, use the commands properly!");
            }
            var characterName = args[0];
            var itemName = args[1];

            Character user = FindCharacter(characterName);

            var item = user.CharacterGear.ChooseItemFromGear(itemName);

            user.UseItemBy(item, user);

            return $"{user.Name} has chosen to use his {itemName}.";
        }

        public string GetStats()
        {
            var sortedCharacters = party
                .OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Life);
            var result = string.Join(Environment.NewLine, sortedCharacters);

            return result;
        }

        public string AbilityAttack(string[] args)
        {

            if (args.Length != 3)
            {
                throw new InvalidOperationException($"please, use the commands properly!");
            }

            var attackerName = args[0];
            var receiverName = args[1];
            var abilityName = args[2];

            var attacker = FindCharacter(attackerName);
            var receiver = FindCharacter(receiverName);

            if (attacker is IBarbarian)
            {
                var barbAbility = FindBarbarianAbility(abilityName);
                (attacker as IBarbarian).UseBarbarianAbility(attacker, barbAbility);
            }
            else if (attacker is ISorceress)
            {
                var sorcAbility = FindSorceressAbility(abilityName);
                (attacker as ISorceress).UseSorceressAbility(attacker, sorcAbility);
            }
            else if (attacker is IPaladin)
            {
                var palAbility = FindPaladinAbility(abilityName);
                (attacker as IPaladin).UsePaladinAbility(attacker, palAbility);
            }

            attacker.Attack(receiver);

            var result = $"{attacker.Name} has attacked {receiver.Name} with a special attack! {receiver.Name} has {receiver.Life}/{receiver.BaseLife} LP left!";

            if (!receiver.IsAlive)
            {
                result += Environment.NewLine + $"{receiverName} is dead!";
            }

            return result;
        }

        public string Attack(string[] args)
        {
            if (args.Length != 2)
            {
                throw new InvalidOperationException($"please, use the commands properly!");
            }

            var attackerName = args[0];
            var receiverName = args[1];

            var attacker = FindCharacter(attackerName);
            var receiver = FindCharacter(receiverName);

            attacker.Attack(receiver);

            var result = $"{attacker.Name} has attacked {receiver.Name}! {receiver.Name} has {receiver.Life}/{receiver.BaseLife} LP left!";

            if (!receiver.IsAlive)
            {
                result += Environment.NewLine + $"{receiverName} is dead!";
            }

            return result;
        }

        public string EndTurn()
        {
            var aliveCharacters = party.Where(c => c.IsAlive).ToArray();

            var sb = new StringBuilder();

            foreach (var character in aliveCharacters)
            {
                var previousHealth = character.Life;

                character.Recover();

                var currentHealth = character.Life;
                sb.AppendLine($"{character.Name} rests ({previousHealth} => {currentHealth}).");
            }

            if (aliveCharacters.Length <= 1)
            {
                lastSurviverRounds++;
            }

            var result = sb.ToString().TrimEnd('\r', '\n');

            return result;
        }

        public bool IsGameOver()
        {
            var oneOrZeroSurvivorsLeft = party.Count(c => c.IsAlive) <= 1;

            var lastSurviverSurvivedTooLong = this.lastSurviverRounds > 1;

            return oneOrZeroSurvivorsLeft && lastSurviverSurvivedTooLong;
        }
    }
}
