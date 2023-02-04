namespace Pokemon {

	public class Pokemon {
		private Type Type;
		public string Name {get;}
		private int _health;
		private int health
		{
			get => _health;
			set
			{
				this._health = value;
				if (this._health < 0)
				{
					this._health = 0;
				}
			}
		}
		private int attack;
		private int specialAttack;
		private int defence;
		private int specialDefence;
		public int Accuracy {get;}
		public int Speed {get;}
		private Combat.Move[] moves;

		public Pokemon(
			Type type,
			String name,
			int health,
			int attack,
			int specialAttack,
			int accuracy,
			int defence,
			int specialDefence,
			int speed
		)
		{
			this.Type = type;
			this.Name = name;
			this._health = health;

			this.attack = attack;
			this.specialAttack = specialAttack;
			this.Accuracy = accuracy;

			this.defence = defence;
			this.specialDefence = specialDefence;

			this.Speed = speed;
			
			this.moves = new Combat.Move[4];
		}

		public void AddMove(Combat.Move move) {
			this.moves[0] = move;
		}

		public Combat.Damage Attack()
		{
			var damage = this.moves[0].Activate();
			
			switch (damage.DamageStat) {
				case Combat.DamageStat.NORMAL:
					damage.DamageValue += this.attack;
					break;
				case Combat.DamageStat.SPECIAL:
					damage.DamageValue += this.specialAttack;
					break;
			}

			return damage;
		}

		public Combat.DamageResponse RecieveDamage(Combat.Damage damage) {
			var typeComparison = Combat.TypeComparator.CompareTypes(damage.Type, this.Type);

			switch (typeComparison)
			{
				case Combat.TypeComparison.Immune:
					damage.DamageValue = 0;
					break;
				case Combat.TypeComparison.Resistant:
					damage.DamageValue /= 2;
					break;
				case Combat.TypeComparison.Neutral:
					break;
				case Combat.TypeComparison.Weak:
					damage.DamageValue *= 2;
					break;
			}

			switch (damage.DamageStat)
			{
				case Combat.DamageStat.NORMAL:
					damage.DamageValue -= this.defence;
					break;
				case Combat.DamageStat.SPECIAL:
					damage.DamageValue -= this.specialDefence;
					break;
			}

			this.health -= damage.DamageValue;

			return this.health <= 0;
		}

		public override string ToString()
		{
			return "Health: " + this.health;
		}
	}
}