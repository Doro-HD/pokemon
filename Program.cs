namespace Pokemon
{
	public class Program {
		public static void Main(String[] args) {
			var torchick = new Pokemon(Type.Fire, "Torchick", 50, 11, 13, 9, 9, 11, 12);
			torchick.AddMove(new Combat.Moves.Ember());

			var bulbasour = new Pokemon(Type.Grass, "Bulbasour", 58, 9, 14, 11, 13, 11, 9);
			bulbasour.AddMove(new Combat.Moves.BulletSeed());

			var battle = new Combat.Battle(torchick, bulbasour);
			battle.Run();
		}
	}
}
