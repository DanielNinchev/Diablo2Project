using Diablo2Project.Entities.ChosenCharacter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diablo2Project.Entities.Characters.Factory
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string type, string name)
        {
            Character character;

            switch (type)
            {
                case "Barbarian":
                    character = new Barbarian(name);
                    break;
                case "Paladin":
                    character = new Paladin(name);
                    break;
                case "Sorceress":
                    character = new Sorceress(name);
                    break;
                default:
                    throw new ArgumentException($"Invalid character type \"{type}\"!");
            }

            return character;
        }
    }
}
