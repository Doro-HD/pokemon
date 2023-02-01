namespace Pokemon.Combat {
	 
	 public class Battle {
		private Pokemon player;
		private Pokemon opponent;

		public Battle(Pokemon player, Pokemon opponent) {
			this.player = player;
			this.opponent = opponent;
		}

		public void Run() {
			while (true) {
				var playerDamage = this.player.Attack();
				var isOpponentDefeated = this.opponent.RecieveDamage(playerDamage);

				if (isOpponentDefeated) {
					Console.WriteLine("Congratulations, you defeated your opponent!");
					break;
				}

				var opponentDamage = this.opponent.Attack();
				var isPlayerDefeated = this.player.RecieveDamage(opponentDamage);

				if (isPlayerDefeated) {
					Console.WriteLine("You lost");
					break;
				}
			}
		}
	 }
}