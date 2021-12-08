using System;
using System.Collections.Generic;
using System.Linq;

namespace D8_SevenSegmentSearch
{
    public class Display
    {
        private readonly List<string> _patterns;
        private readonly List<string> _output;
        public string One { get; set; }
        public string Two { get; set; }
        public string Three { get; set; }
        public string Four { get; set; }
        public string Five { get; set; }
        public string Six { get; set; }
        public string Seven { get; set; }
        public string Eight { get; set; }
        public string Nine { get; set; }

        public Display(List<string> patterns, List<string> output)
        {
            _patterns = patterns;
            _output = output;
            DetermineNumbers(patterns);
        }

        public void DetermineNumbers(List<string> patterns)
        {
            One = patterns.First(x => x.Length == 2);
            patterns.Remove(One);
            Seven = patterns.First(x => x.Length == 3);
            patterns.Remove(Seven);
            Six = patterns.First(x => x.Length == 6 && !Seven.ToCharArray().All(x.Contains));
            patterns.Remove(Six);
            Four = patterns.First(x => x.Length == 4);
            patterns.Remove(Four);
            Eight = patterns.First(x => x.Length == 7);
            patterns.Remove(Eight);
            var lowerRight = One.ToCharArray().First(x => Six.ToCharArray().Contains(x));
            var upperRight = One.ToCharArray().First(x => x != lowerRight);
            var upper = Seven.ToCharArray().First(x => !One.ToCharArray().Contains(x));
            Two = patterns.First(x => x.ToCharArray().All(y => y != lowerRight));
            patterns.Remove(Two);
            var tempFour = Four + upper;
            Nine = patterns.First(x => x.Length == 6 && tempFour.ToCharArray().All(x.Contains));
            patterns.Remove(Nine);
            var shouldBeFive = Nine.ToCharArray().Where(x => x != upperRight);
            Five = patterns.First(x => shouldBeFive.All(x.Contains));
            patterns.Remove(Five);
            var zero = patterns.First(x => x.Length == 6);
            patterns.Remove(zero);
            Three = patterns.First();
        }

        public int AmountOne => _output.Count(x => x.Length == 2);
        public int AmountFour => _output.Count(x => x.Length == 4);
        public int AmountHasSeven => _output.Count(x => x.Length == 3);
        public int AmountHasEight => _output.Count(x => x.Length == 7);

        public int AmountOfUniqueSegmentedValues => AmountOne + AmountFour + AmountHasSeven + AmountHasEight;

        public int GetOutputValue()
        {
            var value = 0;
            var incrementor = 1000;
            foreach (var s in _output)
            {
                value += (GetValue(s) * incrementor);
                incrementor = incrementor / 10;
            }

            return value;
        }

        private static bool AreTheSame(string value1, string value2) => 
            value1.ToCharArray().Intersect(value2.ToCharArray()).Count() == value1.Length;
        

        public int GetValue(string value)
        {
            if (value.Length == 2) return 1;
            if (value.Length == 4) return 4;
            if (value.Length == 3) return 7;
            if (value.Length == 7) return 8;
            if (value.Length == 5 && AreTheSame(value, Two)) return 2;
            if (value.Length == 5 && AreTheSame(value, Five)) return 5;
            if (value.Length == 5 && AreTheSame(value, Three)) return 3;
            if (value.Length == 6 && AreTheSame(value, Nine)) return 9;
            if (value.Length == 6 && AreTheSame(value, Six)) return 6;
            return 0;
        }
    }
}