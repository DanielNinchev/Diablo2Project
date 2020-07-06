using Diablo2Project.Entities.Abilities.BarbarianAbilities;
using Diablo2Project.Entities.ChosenCharacter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diablo2Project.Entities.Contracts
{
    public interface ISorceress
    {
        void UseSorceressAbility(Character character, SorceressAbility sorcAbility);
    }
}
