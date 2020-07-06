using Diablo2Project.Entities.Abilities;
using Diablo2Project.Entities.Characters;
using Diablo2Project.Entities.Contracts;
using Diablo2Project.Entities.Enums;
using Diablo2Project.Entities.Gears;
using Diablo2Project.Entities.Weapons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Diablo2Project.Entities.ChosenCharacter
{
    public abstract class Character
    {
		private string name;
		private double baseLife;
		private double life;
		private double baseMana;
		private double mana;
		private double lifeRegenerationMultiplier;
		private double manaRegenerationMultiplier;
		private double gear;
		private double damage;
		private int level;

		protected Character(string name, double life, double mana, double lifeRegenerationMultiplier, double manaRegenerationMultiplier, CharacterGear gear, double damage)
		{
			this.Name = name;
			this.BaseLife = life;
			this.Life = life;
			this.BaseMana = mana;
			this.Mana = mana;
			this.LifeRegenerationMultiplier = lifeRegenerationMultiplier;
			this.ManaRegenerationMultiplier = manaRegenerationMultiplier;
			this.CharacterGear = gear;
			this.Damage = damage;
		}

		public double Damage
		{
			get { return damage; }
			set { damage = value; }
		}

		public double ManaRegenerationMultiplier
		{
			get { return manaRegenerationMultiplier; }
			set { manaRegenerationMultiplier = value; }
		}

		public CharacterGear CharacterGear { get; }

		public double LifeRegenerationMultiplier
		{
			get { return lifeRegenerationMultiplier; }
			set { lifeRegenerationMultiplier = value; }
		}

		public double Mana
		{
			get { return mana; }
			set { mana = value; }
		}

		public double BaseMana
		{
			get { return baseMana; }
			set { baseMana = value; }
		}

		public double Life
		{
			get { return life; }
			set { life = value; }
		}

		public double BaseLife
		{
			get { return baseLife; }
			set { baseLife = value; }
		}

		public int Level
		{
			get { return level; }
			set { level = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!IsAlive)
			{
				throw new InvalidOperationException("The character must be alive to perform this action.");
			}
		}


		public void UseItemBy(Item item, Character character)
		{
			item.AffectCharacter(character);
		}

		public void CollectItemInGear(Item item)
		{
			this.CharacterGear.AddItemToGear(item);
		}

		public void Attack(Character character)
		{
			EnsureAlive();

			if (character == this)
			{
				throw new InvalidOperationException("The characters cannot hurt themselves!");
			}

			character.TakeDamage(this.Damage);
		}

		public void TakeDamage (double takenDamage)
		{
			EnsureAlive();

			this.Life = Math.Max(0, life - takenDamage);

			if (life == 0)
			{
				IsAlive = false;
			}
		}

		public void Recover()
		{
			EnsureAlive();

			this.Life = Math.Min(Life + BaseLife * LifeRegenerationMultiplier, BaseLife);
			this.Mana = Math.Min(Mana + BaseMana * ManaRegenerationMultiplier, BaseMana);
		}

		public override string ToString()
		{
			const string format = "{0} - Life: {2}/{3}, Mana: {4}/{5}, Damage: {6}, Status: {7}";

			var result = string.Format(format,
				Name,
				Level,
				Life,
				BaseLife,
				Mana,
				BaseMana,
				Damage,
				IsAlive ? "Alive" : "Dead");

			return result;
		}
	}
}
