using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private double health;
		private readonly double baseHealth;
		private readonly double baseArmor;
		private double armor;
		private readonly double abilityPoints;

		public string Name { get;}
        public double Health
		{
			get
			{
				return health;
			}
			set
			{
				
                if (value >= 0 && value <= baseHealth)
                {
					health = value;
                }
			}
		}

		public double Armor
		{
			get
			{
				return armor;
			}
			set
			{

				if (value >= 0)
				{
					armor = value;
				}
			}
		}

        public IBag Bag { get; set; }


        public bool IsAlive { get; set; } = true;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            if (string.IsNullOrEmpty(name?.Trim()))
            {
				throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
            }
			this.Name = name;
			this.baseHealth = health;
			this.Health = health;
			this.baseArmor = armor;
			this.Armor = armor;
			this.abilityPoints = abilityPoints;
			this.Bag = bag;
        }

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}