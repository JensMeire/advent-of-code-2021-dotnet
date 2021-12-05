namespace D4_GiantSquid
{
    public class Winner
    {
        public Winner(BingoBoard board, int winningNumber)
        {
            Board = board;
            WinningNumber = winningNumber;
        }
        public BingoBoard Board { get; set; }
        public int WinningNumber { get; set; }
        public int Score => Board.UnmarkedSum * WinningNumber;
    }
}