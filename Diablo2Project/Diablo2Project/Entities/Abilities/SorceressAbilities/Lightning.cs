using Diablo2Project.Entities.Abilities.BarbarianAbilities;
using Diablo2Project.Entities.ChosenCharacter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diablo2Project.Entities.Abilities.SorceressAbilities
{
    public class Lightning : SorceressAbility
    {
        private const int AttackPoints = 200;

        public Lightning() : base(sorcAbility: "Lightning", manaCost: 140)
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
