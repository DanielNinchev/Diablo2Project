using Diablo2Project.Entities.ChosenCharacter;
using Diablo2Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diablo2Project.Entities.Weapons
{
    public class Flail : Item
    {
        private const int AttackPoints = 50;

        public Flail() : base(1, ItemDesignedForCharacter.BarbarianItem)
        {

        }

        
        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Damage += AttackPoints;
        }
    }
}
