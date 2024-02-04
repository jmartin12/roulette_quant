namespace RouletteQuant
{
	public class Bet
	{
		public bool OnBlack { get; set; }
		public bool OnRed { get; set; }
		public bool OnHigh { get; set; }
		public bool OnLow { get; set; }
		public bool OnEven { get; set; }
		public bool OnOdd { get; set; }
	}

	public enum SplitBetResults
	{
		Full,
		Partial,
		None
	}

	public enum TripleBetResults
	{
		Three,
		Two,
		One,
		None
	}
}