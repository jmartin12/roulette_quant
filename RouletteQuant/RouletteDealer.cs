namespace RouletteQuant
{
	public class RouletteDealer
	{
		public static readonly int _lowLowerBoundary = 1;
		public static readonly int _lowUpperBoundary = 18;
		public static readonly int _highLowerBoundary = 19;
		public static readonly int _highUpperBoundary = 36;

		public static RouletteResult SpinWheel()
		{
			int value = DetermineNumber();
			Color color = DetermineColor(value);
			return new RouletteResult() 
			{
				Color = color,
				IsBlack = color.Equals(Color.Black),
				IsRed = color.Equals(Color.Red),
				Value = value,
				IsEven = value % 2 == 0,
				IsOdd = value % 2 == 1,
				IsHigh = IsHigh(value),
				IsLow = IsLow(value)
			};
		}

		public static bool IsWinnerSingleBet(RouletteResult result, Bet bet)
		{
			if (bet.OnEven && result.IsEven) return true;
			if (bet.OnOdd && result.IsOdd) return true;
			if (bet.OnLow && result.IsLow) return true;
			if (bet.OnHigh && result.IsHigh) return true;
			if (bet.OnRed && result.IsRed) return true;
			if (bet.OnBlack && result.IsBlack) return true;
			return false;
		}

		public static SplitBetResults DetermineSplitBetWinner(RouletteResult rouletteResult, Bet bet)
		{
			if (bet.OnLow && bet.OnRed) 
			{
				if (rouletteResult.IsLow && rouletteResult.IsRed)
				{
					return SplitBetResults.Full;
				}
				
				if (rouletteResult.IsLow)
				{
					return SplitBetResults.Partial;
				}

				if (rouletteResult.IsRed)
				{
					return SplitBetResults.Partial;
				}

				return SplitBetResults.None;
			}
			else if (bet.OnLow && bet.OnBlack)
			{
				if (rouletteResult.IsLow && rouletteResult.IsBlack)
				{
					return SplitBetResults.Full;
				}

				if (rouletteResult.IsLow)
				{
					return SplitBetResults.Partial;
				}

				if (rouletteResult.IsBlack)
				{
					return SplitBetResults.Partial;
				}

				return SplitBetResults.None;
			}
			else if (bet.OnHigh && bet.OnRed)
			{
				if (rouletteResult.IsHigh && rouletteResult.IsRed)
				{
					return SplitBetResults.Full;
				}

				if (rouletteResult.IsHigh)
				{
					return SplitBetResults.Partial;
				}

				if (rouletteResult.IsRed)
				{
					return SplitBetResults.Partial;
				}

				return SplitBetResults.None;
			}
			else if (bet.OnHigh && bet.OnBlack)
			{
				if (rouletteResult.IsHigh && rouletteResult.IsBlack)
				{
					return SplitBetResults.Full;
				}

				if (rouletteResult.IsHigh)
				{
					return SplitBetResults.Partial;
				}

				if (rouletteResult.IsBlack)
				{
					return SplitBetResults.Partial;
				}

				return SplitBetResults.None;
			}
			else if (bet.OnLow && bet.OnEven)
			{
				if (rouletteResult.IsLow && rouletteResult.IsEven)
				{
					return SplitBetResults.Full;
				}

				if (rouletteResult.IsLow)
				{
					return SplitBetResults.Partial;
				}

				if (rouletteResult.IsEven)
				{
					return SplitBetResults.Partial;
				}

				return SplitBetResults.None;
			}
			else if (bet.OnLow && bet.OnOdd)
			{
				if (rouletteResult.IsLow && rouletteResult.IsOdd)
				{
					return SplitBetResults.Full;
				}

				if (rouletteResult.IsLow)
				{
					return SplitBetResults.Partial;
				}

				if (rouletteResult.IsOdd)
				{
					return SplitBetResults.Partial;
				}

				return SplitBetResults.None;
			}
			else if (bet.OnHigh && bet.OnEven)
			{
				if (rouletteResult.IsHigh && rouletteResult.IsEven)
				{
					return SplitBetResults.Full;
				}

				if (rouletteResult.IsHigh)
				{
					return SplitBetResults.Partial;
				}

				if (rouletteResult.IsEven)
				{
					return SplitBetResults.Partial;
				}

				return SplitBetResults.None;
			}
			else if (bet.OnHigh && bet.OnOdd)
			{
				if (rouletteResult.IsHigh && rouletteResult.IsOdd)
				{
					return SplitBetResults.Full;
				}

				if (rouletteResult.IsHigh)
				{
					return SplitBetResults.Partial;
				}

				if (rouletteResult.IsOdd)
				{
					return SplitBetResults.Partial;
				}

				return SplitBetResults.None;
			}
			else if (bet.OnBlack && bet.OnOdd)
			{
				if (rouletteResult.IsBlack && rouletteResult.IsOdd)
				{
					return SplitBetResults.Full;
				}

				if (rouletteResult.IsBlack)
				{
					return SplitBetResults.Partial;
				}

				if (rouletteResult.IsOdd)
				{
					return SplitBetResults.Partial;
				}

				return SplitBetResults.None;
			}
			else if (bet.OnBlack && bet.OnEven)
			{
				if (rouletteResult.IsBlack && rouletteResult.IsEven)
				{
					return SplitBetResults.Full;
				}

				if (rouletteResult.IsBlack)
				{
					return SplitBetResults.Partial;
				}

				if (rouletteResult.IsEven)
				{
					return SplitBetResults.Partial;
				}

				return SplitBetResults.None;
			}
			else if (bet.OnRed && bet.OnOdd)
			{
				if (rouletteResult.IsRed && rouletteResult.IsOdd)
				{
					return SplitBetResults.Full;
				}

				if (rouletteResult.IsRed)
				{
					return SplitBetResults.Partial;
				}

				if (rouletteResult.IsOdd)
				{
					return SplitBetResults.Partial;
				}

				return SplitBetResults.None;
			}
			else if (bet.OnRed && bet.OnEven)
			{
				if (rouletteResult.IsRed && rouletteResult.IsEven)
				{
					return SplitBetResults.Full;
				}

				if (rouletteResult.IsRed)
				{
					return SplitBetResults.Partial;
				}

				if (rouletteResult.IsEven)
				{
					return SplitBetResults.Partial;
				}

				return SplitBetResults.None;
			}
			else
			{
				Console.WriteLine("Shouldn't have gotten here in double bet.");
				return SplitBetResults.None;
			}
		}

		public static TripleBetResults DetermineTripleBetWinner(RouletteResult rouletteResult, Bet bet)
		{
			if (bet.OnLow && bet.OnRed && bet.OnOdd) 
			{
				if (rouletteResult.IsLow && rouletteResult.IsRed && rouletteResult.IsOdd)
				{
					return TripleBetResults.Three;
				}
				else if ((rouletteResult.IsLow && rouletteResult.IsRed) ||
					(rouletteResult.IsRed && rouletteResult.IsOdd) ||
					(rouletteResult.IsLow && rouletteResult.IsOdd))
				{
					return TripleBetResults.Two;
				}
				else if (rouletteResult.IsLow || rouletteResult.IsRed || rouletteResult.IsOdd) 
				{
					return TripleBetResults.One;
				}

				return TripleBetResults.None;
			}
			else if (bet.OnLow && bet.OnRed && bet.OnEven)
			{
				if (rouletteResult.IsLow && rouletteResult.IsRed && rouletteResult.IsEven)
				{
					return TripleBetResults.Three;
				}
				else if ((rouletteResult.IsLow && rouletteResult.IsRed) ||
					(rouletteResult.IsRed && rouletteResult.IsEven) ||
					(rouletteResult.IsLow && rouletteResult.IsEven))
				{
					return TripleBetResults.Two;
				}
				else if (rouletteResult.IsLow || rouletteResult.IsRed || rouletteResult.IsEven)
				{
					return TripleBetResults.One;
				}

				return TripleBetResults.None;
			}
			else if (bet.OnLow && bet.OnBlack && bet.OnOdd)
			{
				if (rouletteResult.IsLow && rouletteResult.IsBlack && rouletteResult.IsOdd)
				{
					return TripleBetResults.Three;
				}
				else if ((rouletteResult.IsLow && rouletteResult.IsBlack) ||
					(rouletteResult.IsBlack && rouletteResult.IsOdd) ||
					(rouletteResult.IsLow && rouletteResult.IsOdd))
				{
					return TripleBetResults.Two;
				}
				else if (rouletteResult.IsLow || rouletteResult.IsBlack || rouletteResult.IsOdd)
				{
					return TripleBetResults.One;
				}

				return TripleBetResults.None;
			}
			else if (bet.OnLow && bet.OnBlack && bet.OnEven)
			{
				if (rouletteResult.IsLow && rouletteResult.IsBlack && rouletteResult.IsEven)
				{
					return TripleBetResults.Three;
				}
				else if ((rouletteResult.IsLow && rouletteResult.IsBlack) ||
					(rouletteResult.IsBlack && rouletteResult.IsEven) ||
					(rouletteResult.IsLow && rouletteResult.IsEven))
				{
					return TripleBetResults.Two;
				}
				else if (rouletteResult.IsLow || rouletteResult.IsBlack || rouletteResult.IsEven)
				{
					return TripleBetResults.One;
				}

				return TripleBetResults.None;
			}
			else if (bet.OnHigh && bet.OnRed && bet.OnOdd)
			{
				if (rouletteResult.IsHigh && rouletteResult.IsRed && rouletteResult.IsOdd)
				{
					return TripleBetResults.Three;
				}
				else if ((rouletteResult.IsHigh && rouletteResult.IsRed) ||
					(rouletteResult.IsRed && rouletteResult.IsOdd) ||
					(rouletteResult.IsHigh && rouletteResult.IsOdd))
				{
					return TripleBetResults.Two;
				}
				else if (rouletteResult.IsHigh || rouletteResult.IsRed || rouletteResult.IsOdd)
				{
					return TripleBetResults.One;
				}

				return TripleBetResults.None;
			}
			else if (bet.OnHigh && bet.OnRed && bet.OnEven)
			{
				if (rouletteResult.IsHigh && rouletteResult.IsRed && rouletteResult.IsEven)
				{
					return TripleBetResults.Three;
				}
				else if ((rouletteResult.IsHigh && rouletteResult.IsRed) ||
					(rouletteResult.IsRed && rouletteResult.IsEven) ||
					(rouletteResult.IsHigh && rouletteResult.IsEven))
				{
					return TripleBetResults.Two;
				}
				else if (rouletteResult.IsHigh || rouletteResult.IsRed || rouletteResult.IsEven)
				{
					return TripleBetResults.One;
				}

				return TripleBetResults.None;
			}
			else if (bet.OnHigh && bet.OnBlack && bet.OnOdd)
			{
				if (rouletteResult.IsHigh && rouletteResult.IsBlack && rouletteResult.IsOdd)
				{
					return TripleBetResults.Three;
				}
				else if ((rouletteResult.IsHigh && rouletteResult.IsBlack) ||
					(rouletteResult.IsBlack && rouletteResult.IsOdd) ||
					(rouletteResult.IsHigh && rouletteResult.IsOdd))
				{
					return TripleBetResults.Two;
				}
				else if (rouletteResult.IsHigh || rouletteResult.IsBlack || rouletteResult.IsOdd)
				{
					return TripleBetResults.One;
				}

				return TripleBetResults.None;
			}
			else if (bet.OnHigh && bet.OnBlack && bet.OnEven)
			{
				if (rouletteResult.IsHigh && rouletteResult.IsBlack && rouletteResult.IsEven)
				{
					return TripleBetResults.Three;
				}
				else if ((rouletteResult.IsHigh && rouletteResult.IsBlack) ||
					(rouletteResult.IsBlack && rouletteResult.IsEven) ||
					(rouletteResult.IsHigh && rouletteResult.IsEven))
				{
					return TripleBetResults.Two;
				}
				else if (rouletteResult.IsHigh || rouletteResult.IsBlack || rouletteResult.IsEven)
				{
					return TripleBetResults.One;
				}

				return TripleBetResults.None;
			}
			else
			{
				Console.WriteLine("Shouldn't have gotten here in triple bet.");
				return TripleBetResults.None;
			}
		}

		private static Color DetermineColor(int num)
		{
			return num switch
			{
				0 or -1 => Color.Green,
				1 or 3 or 5 or 7 or 9 or 12 or 14 or 16 or 18 or 19 or 21 or 23 or 25 or 27 or 30 or 32 or 34 or 36 => Color.Red,
				2 or 4 or 6 or 8 or 10 or 11 or 13 or 15 or 17 or 20 or 22 or 24 or 26 or 28 or 29 or 31 or 33 or 35 => Color.Black,
				_ => Color.Unknown,
			};
		}

		private static int DetermineNumber()
		{
			// Numbers on the roulette wheel including 0 and 00
			int[] wheelNumbers = [0, 32, 15, 19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10, 5, 24, 16, 33, 1, 20, 14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26, -1];

			// Simulate the spin by randomly selecting a number from the wheel
			Random random = new();
			int spinResult = wheelNumbers[random.Next(wheelNumbers.Length)];

			return spinResult;
		}

		private static bool IsHigh(int num)
		{
			return num <= _highUpperBoundary && num >= _highLowerBoundary;
		}

		private static bool IsLow(int num)
		{
			return num <= _lowUpperBoundary && num >= _lowLowerBoundary;
		}

		public static int CountBets(Bet bet)
		{
			int count = 0;

			if (bet.OnBlack) count++;
			if (bet.OnRed) count++;
			if (bet.OnHigh) count++;
			if (bet.OnLow) count++;
			if (bet.OnEven) count++;
			if (bet.OnOdd) count++;

			return count;
		}     
	}
}
