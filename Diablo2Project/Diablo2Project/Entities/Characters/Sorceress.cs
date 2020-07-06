using Diablo2Project.Entities.Abilities.BarbarianAbilities;
using Diablo2Project.Entities.Abilities.SorceressAbilities;
using Diablo2Project.Entities.ChosenCharacter;
using Diablo2Project.Entities.Contracts;
using Diablo2Project.Entities.Gears;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diablo2Project.Entities.Characters.Factory
{
    public class Sorceress : Character, ISorceress
    {
        public Sorceress(string name) : base(name, life: 100, mana: 250, lifeRegenerationMultiplier: 0.1, manaRegenerationMultiplier: 0.65, gear: new SorceressGear(), damage: 2)
        {

        }

        public void UseSorceressAbility(Character character, SorceressAbility sorcAbility)
        {
            EnsureAlive();
            if (sorcAbility is Blizzard & character.Mana >= sorcAbility.ManaCost)
            {
                sorcAbility.AffectCharacter(character);
            }
            else if (sorcAbility is Lightning & character.Mana >= sorcAbility.ManaCost)
            {
                sorcAbility.AffectCharacter(character);
            }
            else
            {
                Console.WriteLine($"{character} either doesn't have any mana, or is trying to perform unknown abilities.");
            }
        }
    }
}
