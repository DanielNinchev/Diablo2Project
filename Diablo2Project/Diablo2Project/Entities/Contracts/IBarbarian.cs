using Diablo2Project.Entities.Abilities;
using Diablo2Project.Entities.ChosenCharacter;
using Diablo2Project.Entities.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diablo2Project.Entities.Contracts
{
    public interface IBarbarian
    {
        void UseBarbarianAbility(Character character, BarbarianAbility barbAbility);
    }
}
