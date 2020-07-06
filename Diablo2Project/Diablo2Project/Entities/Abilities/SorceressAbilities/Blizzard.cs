using Diablo2Project.Entities.Abilities.BarbarianAbilities;
using Diablo2Project.Entities.ChosenCharacter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diablo2Project.Entities.Abilities.SorceressAbilities
{
    public class Blizzard : SorceressAbility
    {
        private const int AttackPoints = 150;

        public Blizzard() : base(sorcAbility: "Blizzard", manaCost: 80)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Damage += AttackPoints;
            character.Mana -= ManaCost;
        }
    }
}
