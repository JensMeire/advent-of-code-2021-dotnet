using System.Collections.Generic;
using System.Linq;

namespace D4_GiantSquid
{
    public class BingoRow
    {
        private readonly List<BingoNumber> _numbers;

        public BingoRow(List<BingoNumber> numbers)
        {
            _numbers = numbers;
        }

        public bool Marked => _numbers.All(x => x.Marked);

        public bool Mark(int value)
        {
            var number = _numbers.FirstOrDefault(x => x.Value == value);
            if (number == null) return false;
            number.Mark();
            return true;
        }

        public List<BingoNumber> Numbers => _numbers;
    }
}