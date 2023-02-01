namespace Pokemon {

	public class Pokemon {
		private Type type;
		private String name;
		private int health;
		private int attack;
		private int specialAttack;
		private int defence;
		private int specialDefence;
		private Combat.Move[] moves;

		public Pokemon(Type type, String name, int health, int attack, int specialAttack, int defence, int specialDefence) {
			this.type = type;
			this.name = name;
			this.health = health;

			this.attack = attack;
			this.specialAttack = specialAttack;

			this.defence = defence;
			this.specialDefence = specialDefence;
			
			this.moves = new Combat.Move[4];
		}

		public void AddMove(Combat.Move move) {
			this.moves[0] = move;
		}

		public Combat.Damage Attack() {
			var damage = this.moves[0].Activate();

			switch (damage.GetDamageStat()) {
				case Combat.DamageStat.NORMAL:
					damage.ModifyDamage(this.attack);
					break;
				case Combat.DamageStat.SPECIAL:
					damage.ModifyDamage(this.specialAttack);
					break;
			}

			return damage;
		}

		public bool RecieveDamage(Combat.Damage damage) {
			switch (damage.GetDamageStat()) {
				case Combat.DamageStat.NORMAL:
					damage.ModifyDamage(-this.defence);
					break;
				case Combat.DamageStat.SPECIAL:
					damage.ModifyDamage(-this.specialDefence);
					break;
			}

			this.SetHeatlh(damage.GetDamageValue());

			return this.health <= 0;
		}

		private void SetHeatlh(int health) {
			this.health = this.health - health;
			if (this.health <= 0) {
				this.health = 0;
			}
		}

		public override string ToString()
		{
			return "Health: " + this.health;
		}
	}
}