using Diablo2Project.Entities.Gears;
using Diablo2Project.Entities.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Diablo2Project.Entities.Items.Factory
{
    public class ItemFactory
    {
        public Item CreateItem(string name)
        {
            {
                Item item;

                switch (name)
                {
                    case "BroadAxe":
                        item = new BroadAxe();
                        break;
                    case "Flail":
                        item = new Flail();
                        break;
                    case "Scepter":
                        item = new Scepter();
                        break;
                    case "ShortSword":
                        item = new ShortSword();
                        break;
                    case "Occulus":
                        item = new Occulus();
                        break;
                    case "BoneShield":
                        item = new BoneShield();
                        break;
                    default:
                        throw new ArgumentException($"invalid item \"{name}\"");
                }

                return item;
            }
        }
    }
}
