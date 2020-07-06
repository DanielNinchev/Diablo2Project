using Diablo2Project.Entities.ChosenCharacter;
using Diablo2Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diablo2Project.Entities.Weapons
{
    public class ShortSword : Item
    {
        private const int AttackPoints = 65;

        public ShortSword() : base(1, ItemDesignedForCharacter.PaladinItem)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Damage += AttackPoints;
        }
    }
}
