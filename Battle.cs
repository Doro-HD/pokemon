namespace Pokemon.Combat {
	 
	 public class Battle {
		private Pokemon player;
		private Pokemon opponent;

		public Battle(Pokemon player, Pokemon opponent) {
			this.player = player;
			this.opponent = opponent;
		}

		public void Run() {
			while (true)
			{
				var playerSpeed = this.player.Speed;
				var opponentSpeed = this.opponent.Speed;

				var firstPlayer = playerSpeed >= opponentSpeed ? this.player : this.opponent;
				var secondPlayer = opponentSpeed < playerSpeed ? this.opponent : this.player;
				
				var isSecondPlayerDefeated = this.AttackSequence(firstPlayer, secondPlayer);
				if (isSecondPlayerDefeated)
				{
					Console.WriteLine("Congratulation " + firstPlayer.Name);
					break;
				}

				var isFirstPlayerDefeated = this.AttackSequence(secondPlayer, firstPlayer);
				if (isFirstPlayerDefeated)
				{
					Console.WriteLine("Congratulation " + secondPlayer.Name);
					break;
				}
			}
		}

		public bool AttackSequence(Pokemon attacker, Pokemon defender)
		{
			var isDefenderDefeated = false;

			var attackerDamage = attacker.Attack();
			if (attackerDamage.CalculateHit(attacker))
			{
				isDefenderDefeated = defender.RecieveDamage(attackerDamage);
			}

			return isDefenderDefeated;
		}

		public void HasWinner(Pokemon potentialWinner, Pokemon potentialLoser, bool potentialLoserDeafeated)
		{
			var io = new IO.CombatIO();
			if (potentialLoserDeafeated)
			{
				if (potentialWinner == this.player)
				{
					io.PlayerWon();
				}
				else
				{
					io.PlayerLoss();
				}
			}
		}
	 }
}