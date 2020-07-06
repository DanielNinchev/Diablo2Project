using Diablo2Project.Entities.ChosenCharacter;
using Diablo2Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Diablo2Project.Entities.Weapons
{
    public abstract class Item
    {
        protected Item(int gearSpace, ItemDesignedForCharacter type)
        {
            GearSpace = gearSpace;
            ItemDesignedForCharacter = type;
        }

        public int GearSpace { get; }
        public ItemDesignedForCharacter ItemDesignedForCharacter { get; }

        public virtual void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action.");
            }
        }
    }
}
