using Diablo2Project.Entities.Enums;
using Diablo2Project.Entities.Weapons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Diablo2Project.Entities.Gears
{
    public abstract class CharacterGear
    {

        private readonly List<Item> gear;

        private int capacity;
        protected CharacterGear(int capacity, ItemDesignedForCharacter allowedItems)
        {
            this.Capacity = capacity;
            this.gear = new List<Item>();
            this.AllowedItems = allowedItems;
        }

        public ItemDesignedForCharacter AllowedItems { get; set; }

        public int Capacity 
        { 
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public int GearLoad { get => this.gear.Sum(g => g.GearSpace); }

        public IReadOnlyCollection<Item> Gear { get => this.gear.AsReadOnly(); }

        public void AddItemToGear(Item item)
        {
            if (this.GearLoad + item.GearSpace > capacity)
            {
                throw new InvalidOperationException("This character cannot carry anymore!");
            }

            this.gear.Add(item);
        }

        private void EnsureItemExists(string name)
        {
            if (!this.gear.Any())
            {
                throw new InvalidOperationException("This character has not picked any items yet.");
            }

            var itemExists = this.gear.Any(i => i.GetType().Name == name);

            if (!itemExists)
            {
                throw new ArgumentException($"There is no {name} in this gear!");
            }
        }

        public Item ChooseItemFromGear(string name)
        {
            EnsureItemExists(name);

            var chosenItem = this.gear.First(i => i.GetType().Name == name);

            return chosenItem;
        }

    }
}
