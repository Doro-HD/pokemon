namespace Pokemon.Combat {

	public interface Move {
		Damage Activate();
	}

	namespace Moves {
		public class Ember : Move {
		
			public Damage Activate() {
				return new Damage(Type.FIRE, 8, DamageStat.SPECIAL);
			}
		}

		public class BulletSeed : Move {

			public Damage Activate() {
				return new Damage(Type.GRASS, 10, DamageStat.NORMAL);
			}
		}
	}
}