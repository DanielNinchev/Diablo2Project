using Diablo2Project.Entities.Abilities.BarbarianAbilities;
using Diablo2Project.Entities.Abilities.SorceressAbilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diablo2Project.Entities.Abilities.Factory
{
    public class SorceressAbilityFactory
    {
        public SorceressAbility CreateAbility(string name)
        {
            SorceressAbility ability;

            switch (name)
            {
                case "Blizzard":
                    ability = new Blizzard();
                    break;
                case "Lightning":
                    ability = new Lightning();
                    break;
                default:
                    throw new ArgumentException($"Invalid ability \"{name}\"");
            }

            return ability;
        }
    }
}
