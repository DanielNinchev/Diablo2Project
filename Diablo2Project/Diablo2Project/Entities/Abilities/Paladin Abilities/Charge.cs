using Diablo2Project.Entities.ChosenCharacter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diablo2Project.Entities.Abilities
{
    public class Charge : PaladinAbility
    {
        private const int AttackPoints = 60;

        public Charge() : base(palAbility: "Charge", manaCost: 30)
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
