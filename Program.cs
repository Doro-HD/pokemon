namespace Pokemon
{
	public class Program {
		public static void Main(String[] args) {
			var torchick = new Pokemon(Type.FIRE, "Torchick", 50, 11, 13, 9, 11);
			torchick.AddMove(new Combat.Moves.Ember());

			var bulbasour = new Pokemon(Type.GRASS, "Bulbasour", 58, 9, 14, 13, 11);
			bulbasour.AddMove(new Combat.Moves.BulletSeed());

			var battle = new Combat.Battle(torchick, bulbasour);
			battle.Run();
		}	
	}
}
