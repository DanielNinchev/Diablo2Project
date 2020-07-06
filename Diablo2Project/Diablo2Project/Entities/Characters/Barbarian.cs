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
    public class Barbarian : Character, IBarbarian
    {
        public Barbarian(string name) : base (name, life: 300, mana: 40, lifeRegenerationMultiplier: 0.4, manaRegenerationMultiplier: 0.15, gear: new BarbarianGear(),  damage: 10)
        {

        }

        public void UseBarbarianAbility(Character character, BarbarianAbility barbAbility)
        {
            EnsureAlive();
            if (barbAbility is Battlecry & character.Mana >= barbAbility.ManaCost)
            {
                barbAbility.AffectCharacter(character);
            }
            else if (barbAbility is Ferocity & character.Mana >= barbAbility.ManaCost)
            {
                barbAbility.AffectCharacter(character);
            }
            else
            {
                Console.WriteLine($"{character} either doesn't have any mana, or is trying to perform unknown abilities.");
            }
        }
    }
}
