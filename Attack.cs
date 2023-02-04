namespace Pokemon.Combat {

	public interface Move {
		Damage Activate();
	}

	namespace Moves {
		public class Ember : Move {
		
			public Damage Activate() {
				return new Damage(Type.Fire, 8, DamageStat.SPECIAL, 65);
			}
		}

		public class BulletSeed : Move {

			public Damage Activate() {
				return new Damage(Type.Grass, 10, DamageStat.NORMAL, 80);
			}
		}
	}
}