namespace RouletteQuant
{
	public class RouletteResult
	{
        public int Value { get; set; }
		public Color Color { get; set; }
		public bool IsRed { get; set; }
		public bool IsBlack { get; set; }
		public bool IsEven { get; set; }
		public bool IsOdd { get; set; }
		public bool IsHigh { get; set; }
		public bool IsLow { get; set; }
    }

	public enum Color
	{
		Red,
		Green,
		Black,
		Unknown
	}
}
