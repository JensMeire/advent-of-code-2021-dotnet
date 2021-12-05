using System;
using System.Collections.Generic;
using System.Linq;

namespace D4_GiantSquid
{
    public class BingoBoard 
    {
        private readonly List<BingoRow> _rows;
        private readonly int _columnsCount;
        private readonly int _rowsCount;
        private BingoRow _fullRow;

        public BingoBoard(List<BingoRow> rows)
        {
            _rows = rows;
            _rowsCount = rows.Count;
            _columnsCount = rows.First().Numbers.Count;
            if(_rows.Any(x => x.Numbers.Count != _columnsCount))
                throw new Exception("Not all rows have the same amount of numbers");
        }

        public BingoRow Mark(int value)
        {
            foreach (var row in _rows)
            {
                var isMarked = row.Mark(value);
                if (!isMarked || !row.Marked) 
                    continue;
                _fullRow = row;
                break;
            }

            if (_fullRow != null) return _fullRow;
            
            for (var i = 0; i < _columnsCount; i++)
            {
                var col = GetColumn(i);
                if (!col.Marked) continue;
                _fullRow = col;
                break;
            }

            return _fullRow;

        }

        public int UnmarkedSum => _rows.Sum(x => x.Numbers.Where(n => !n.Marked).Sum(n => n.Value));

        private BingoRow GetColumn(int index) => new BingoRow(_rows.Select(x => x.Numbers[index]).ToList());

        public bool HasWinningRow => _fullRow != null;
    }
}