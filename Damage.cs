namespace Pokemon.Combat {
	public enum DamageStat {
		NORMAL,
		SPECIAL
	}

	public class Damage {
		
		private Type type;
		private int damageValue;
		private DamageStat damageStat;

		public Damage(Type type, int damageValue, DamageStat damageStat) {
			this.type = type;
			this.damageValue = damageValue;
			this.damageStat = damageStat;
		}

		public void ModifyDamage(int modifier) {
			this.damageValue += modifier;
		}

		public int GetDamageValue() {
			return this.damageValue;
		}

		public DamageStat GetDamageStat() {
			return this.damageStat;
		}
	}
}