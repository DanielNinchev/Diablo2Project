using Diablo2Project.Entities.Abilities;
using Diablo2Project.Entities.ChosenCharacter;
using Diablo2Project.Entities.Contracts;
using Diablo2Project.Entities.Gears;
using Diablo2Project.Entities.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diablo2Project.Entities.Characters
{
    public class Paladin : Character, IPaladin
    {
        public Paladin(string name) : base(name, life: 220, mana: 100, lifeRegenerationMultiplier: 0.35, manaRegenerationMultiplier: 0.25, gear: new PaladinGear(), damage: 8)
        {

        }

        public void UsePaladinAbility(Character character, PaladinAbility palAbility)
        {
            EnsureAlive();

            if (palAbility is Zealotry & character.Mana >= palAbility.ManaCost)
            {
                palAbility.AffectCharacter(character);
            }
            else if (palAbility is Charge & character.Mana >= palAbility.ManaCost)
            {
                palAbility.AffectCharacter(character);
            }
            else
            {
                Console.WriteLine($"{character} either doesn't have any mana, or is trying to perform unknown abilities.");
            }
        }
    }
}
