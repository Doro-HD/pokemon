namespace Pokemon.Combat 
{
	public enum DamageStat 
	{
		NORMAL,
		SPECIAL
	}

	public struct Damage 
	{
		
		public Type Type
		{get;}
		private int damageValue;
		public int DamageValue
		{
			get => damageValue;
			set
			{
				if (value < 0)
				{
					damageValue = 0;
				}
				else
				{
					damageValue = value;
				}
			}
		}
		public DamageStat DamageStat
		{get;}
		public int ChanceToHit;

		public Damage(Type type, int damageValue, DamageStat damageStat, int chanceToHit) {
			this.Type = type;
			this.damageValue = damageValue;
			this.DamageStat = damageStat;
			
			this.ChanceToHit = chanceToHit;
		}

		public bool CalculateHit(Pokemon attacker)
		{
			var random = new Random();
			var hitRoll = random.Next(0, 101);

			if (hitRoll < attacker.Accuracy)
			{
				hitRoll = attacker.Accuracy - hitRoll;
			}
			else
			{
				hitRoll = hitRoll - attacker.Accuracy;
			}

			return hitRoll <= this.ChanceToHit;
		}
	}
}