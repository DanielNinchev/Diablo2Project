using Diablo2Project.Entities.ChosenCharacter;
using Diablo2Project.Entities.Weapons;
using Diablo2Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diablo2Project.Entities.Items
{
    public class Occulus : Item
    {
        private const int AttackPoints = 5;
        private const int ManaPoints = 120;

        public Occulus() : base(1, ItemDesignedForCharacter.SorceressItem)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Damage += AttackPoints;
            character.Mana += ManaPoints;
        }
    }
}
