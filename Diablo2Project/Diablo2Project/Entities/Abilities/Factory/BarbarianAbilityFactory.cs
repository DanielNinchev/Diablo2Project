using System;
using System.Collections.Generic;
using System.Text;

namespace Diablo2Project.Entities.Abilities.Factory
{
    public class BarbarianAbilityFactory
    {
        public BarbarianAbility CreateAbility(string name)
        {
            BarbarianAbility ability;

            switch (name)
            {
                    case "Battlecry":
                        ability = new Battlecry();
                        break;
                    case "Ferocity":
                        ability = new Ferocity();
                        break;
                    default:
                        throw new ArgumentException($"Invalid ability \"{name}\"");
            }

            return ability;
        }
    }
}
