using RouletteQuant;

int maxSimulatedRolls = 500;
int rollCount = 3;
int initialCapital = 2500;
int betSize = 100;

RoulettePlayer player = new();
List<RouletteResult> rouletteResults =
[
	RouletteDealer.SpinWheel(),
	RouletteDealer.SpinWheel(),
	RouletteDealer.SpinWheel()
];

while (rollCount <= maxSimulatedRolls)
{
	RolledResults patterns = player.GetPotentialBetPatterns(rouletteResults);
    Bet bet = player.DetermineNextBet(patterns);
	int numBets = RouletteDealer.CountBets(bet);
	RouletteResult currentRoll = RouletteDealer.SpinWheel();
	FindWinner(rollCount, bet, numBets, currentRoll);
    Console.WriteLine($"---Bankroll is up: {((player.CurrentCapital - player.InitialCapital)/(double)player.InitialCapital)*100}%----");
    rollCount++;
	rouletteResults.Add(currentRoll);
}

// The math is off somewhere..
void FindWinner(int rollCount, Bet bet, int numBets, RouletteResult currentRoll)
{
	if (numBets == 0)
	{
		Console.WriteLine($"Did not place bet for spin number: {rollCount}");
	}
	else if (numBets == 1)
	{
		if (RouletteDealer.IsWinnerSingleBet(currentRoll, bet))
		{
			// If we lost the previous bet, but now won, we exit the martingale mode and calculate the winnings accordingly.
			if (player.Stats.LostPreviousBet)
			{
				player.CurrentCapital += player.BetSize * (int)Math.Pow(2, player.Stats.LossInARowCounter);
			}
			// We hit on the first time, just add the bet winnings to the capital.
			else
			{
				player.CurrentCapital += player.BetSize;
			}

			player.Stats.LostPreviousBet = false;
			player.MartingaleMode = false;
			Console.WriteLine($"Won a single bet on roll: {rollCount}, Losses in a row: {player.Stats.LossInARowCounter}");
			player.Stats.LossInARowCounter = 0;
		}
		else
		{
			player.Stats.LostPreviousBet = true;
			player.Stats.LossInARowCounter += 1;
			
			// Since we lost, we are entering or still remain in MaringaleMode of betting.
			player.MartingaleMode = true;

			// The first loss is just the bet size.
			if (FirstLoss(player))
			{
				player.CurrentCapital -= player.BetSize;
			}
			// We are on the subsequent losses, then its expontential loss
			else
			{
		  		player.CurrentCapital -= player.BetSize * (int)Math.Pow(2, player.Stats.LossInARowCounter);
			}
			Console.WriteLine($"Lost a single bet on roll: {rollCount}");
		}
	}
	else if (numBets == 2)
	{
		var whatKindOfWinner = RouletteDealer.DetermineSplitBetWinner(currentRoll, bet);
		switch (whatKindOfWinner)
		{
			case SplitBetResults.Full:
				player.CurrentCapital += player.BetSize;
				Console.WriteLine($"Won a full double bet on roll: {rollCount}");
				break;
			case SplitBetResults.Partial:
				Console.WriteLine($"Won a partial double bet on roll: {rollCount}");
				break;
			case SplitBetResults.None:
				player.CurrentCapital -= player.BetSize;
				Console.WriteLine($"Lost a double bet on roll: {rollCount}");
				break;
		}
	}
	else if (numBets == 3)
	{
		var whatKindOfWinner = RouletteDealer.DetermineTripleBetWinner(currentRoll, bet);
		switch (whatKindOfWinner)
		{
			case TripleBetResults.Three:
				player.CurrentCapital += player.BetSize;
				Console.WriteLine($"Won a three bets on roll: {rollCount}");
				break;
			case TripleBetResults.Two:
				player.CurrentCapital += player.BetSize * (2/3);
				Console.WriteLine($"Won a two bets on roll: {rollCount}");
				break;
			case TripleBetResults.One:
				//This case could be better. incorporate 35/35/30
				//				player.CurrentCapital -= player.BetSize * (1/3); 
				Console.WriteLine($"Won a bet on roll: {rollCount}");
				break;
			case TripleBetResults.None:
				player.CurrentCapital -= player.BetSize;
				Console.WriteLine($"Lost a triple bet on roll: {rollCount}");
				break;
		}
	}
}

static bool FirstLoss(RoulettePlayer player)
{
	return player.Stats.LossInARowCounter == 1;
}