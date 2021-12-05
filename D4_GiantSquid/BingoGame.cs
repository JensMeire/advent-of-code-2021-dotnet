using System;
using System.Collections.Generic;
using System.Linq;

namespace D4_GiantSquid
{
    public class BingoGame
    {
        private readonly List<BingoBoard> _boards;
        private readonly List<int> _numbers;
        private List<(int, BingoBoard )> _winners;
        private int _currentIndex;

        public LeaderBoard LeaderBoard { get; private set; }

        public BingoGame(List<BingoBoard> boards, List<int> numbers)
        {
            _boards = boards;
            _numbers = numbers;
            LeaderBoard = new LeaderBoard();
        }

        public void Start()
        {
            while (!GameOver)
            {
                var currentNumber = _numbers[_currentIndex];
                Console.WriteLine("currentNumber: " + currentNumber);
                foreach (var board in _boards.Where(x => !x.HasWinningRow))
                {
                    var row = board.Mark(currentNumber);
                    if (row == null ) continue;
                    LeaderBoard.AddWinner(new Winner(board, currentNumber));
                }
                if(!GameOver) _currentIndex++;
            }
        }

        public bool GameOver => _currentIndex == _numbers.Count - 1;

        public List<(int, BingoBoard)> Winners => _winners;
    }
}