using Diablo2Project.Entities.ChosenCharacter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diablo2Project.Entities.Abilities
{
    public class Ferocity : BarbarianAbility
    {
            private const int AttackPoints = 100;

            public Ferocity() : base(barbAbility: "Ferocity", manaCost:20)
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
