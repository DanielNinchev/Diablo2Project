using Diablo2Project.Entities.Weapons;
using Diablo2Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Diablo2Project.Entities.ChosenCharacter;

namespace Diablo2Project.Entities.Items
{
    public class BoneShield : Item
    {
        private const int ManaPoints = 20;

        public BoneShield() : base(1, ItemDesignedForCharacter.SorceressItem)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Mana += ManaPoints;
        }
    }
}
