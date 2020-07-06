using System;
using System.Collections.Generic;
using System.Text;

namespace Diablo2Project.Entities.Abilities.Factory
{
    public class PaladinAbilityFactory
    {
        public PaladinAbility CreateAbility(string name)
        {
            PaladinAbility ability;

            switch (name)
            {
                case "Zealotry":
                    ability = new Zealotry();
                    break;
                case "Charge":
                    ability = new Charge();
                    break;
                default:
                    throw new ArgumentException($"Invalid ability \"{name}\"");
            }

            return ability;
        }
    }
}
