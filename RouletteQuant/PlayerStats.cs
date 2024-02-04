namespace RouletteQuant
{
	public class PlayerStats
	{
		public bool LostPreviousBet = false;
		public int LossInARowCounter = 0;
		public int SingleBetsWon { get; set; }
        public int SingleBetsLost { get; set; }
        public int DoubleBetsWon { get; set; }
        public int DoubleBetsLost { get; set; }
        public int TripleBetsWon { get; set; }
        public int TripleBetsLost { get; set; }
    }
}
