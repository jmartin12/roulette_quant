﻿namespace RouletteQuant
{
	public class RoulettePlayer
	{
		public PlayerStats Stats;
		public int CurrentCapital = 6400;
		public int InitialCapital = 6400;
		public int BetSize = 100;
		public bool MartingaleMode = false;
		private Bet _previousBet;

        public RoulettePlayer()
        {
			_previousBet = new Bet();
			Stats = new PlayerStats();    
        }

        public RolledResults GetPotentialBetPatterns(List<RouletteResult> results)
		{
			List<RouletteResult> lastThree = results.Skip(Math.Max(0, results.Count - 3)).ToList();
			return AnalyzePatterns(lastThree);
		}

		public Bet DetermineNextBet(RolledResults patterns)
		{
			if (MartingaleMode)
			{
				return _previousBet;
			}
			else
			{
				Bet betToMake = new Bet
				{
					OnBlack = patterns.LastThreeBlack,
					OnRed = patterns.LastThreeRed,
					OnEven = patterns.LastThreeEven,
					OnOdd = patterns.LastThreeOdd,
					OnHigh = patterns.LastThreeHigh,
					OnLow = patterns.LastThreeLow,
				};

				// Keep track as the previous bet
				_previousBet = betToMake;

				return betToMake;
			} 
		}

		private RolledResults AnalyzePatterns(List<RouletteResult> lastThree)
		{
			RolledResults result = new();

			if (HouseWins(lastThree))
			{
				return result;
			}

			if (lastThree.All(x => x.IsEven))
			{
				result.LastThreeEven = true;
			}

			if (lastThree.All(x => x.IsOdd))
			{
				result.LastThreeOdd = true;
			}

			if (lastThree.All(x => x.Color == Color.Red))
			{
				result.LastThreeRed = true;
			}

			if (lastThree.All(x => x.Color == Color.Black))
			{
				result.LastThreeBlack = true;
			}

			if (lastThree.All(x => x.IsLow))
			{
				result.LastThreeLow = true;
			}

			if (lastThree.All(x => x.IsHigh))
			{
				result.LastThreeHigh = true;
			}

			return result;
		}

		private static bool HouseWins(List<RouletteResult> lastThree)
		{
			return lastThree.Any(x => x.Value == -1 || x.Value == 0);
		}
	}

	public class RolledResults()
	{
        public bool LastThreeOdd { get; set; }
		public bool LastThreeEven { get; set; }
		public bool LastThreeRed { get; set; }
		public bool LastThreeBlack { get; set; }
		public bool LastThreeHigh { get; set; }
		public bool LastThreeLow { get; set; }
	}
}
