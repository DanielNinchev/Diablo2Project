using Diablo2Project.Entities.ChosenCharacter;
using Diablo2Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diablo2Project.Entities.Weapons
{
    public class BroadAxe : Item
    {
        private const int AttackPoints = 85;

        public BroadAxe() : base (2, ItemDesignedForCharacter.BarbarianItem)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Damage += AttackPoints;
        }
    }
}
