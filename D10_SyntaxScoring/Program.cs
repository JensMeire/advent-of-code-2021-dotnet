using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D10_SyntaxScoring
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadLines("./data.txt").Select(x => new SyntaxLine(x)).ToList();
            var corrupted = data.Where(x => x.IsCorrupted).ToList();
            Console.WriteLine(corrupted.Sum(x =>
            {
                var chars = x.GetCorruptedChars;
                switch (chars.actual)
                {
                    case ')': return 3;
                    case ']': return 57;
                    case '}': return 1197;
                    case '>': return 25137;
                    default: throw new NotImplementedException();
                }
            }));
            
            var notCorrupted = data.Where(x => !x.IsCorrupted).OrderBy(x => x.CompletionScore).ToList();
            Console.WriteLine(notCorrupted[(notCorrupted.Count - 1) / 2].CompletionScore);
        }
    }

    public class SyntaxLine
    {
        private readonly string _line;
        private int _corruptedCharPosition = -1;
        private int _lonelyStartingCharPosition = -1;
        private List<char> _completingChars;

        public SyntaxLine(string line)
        {
            _line = line;
            Inspect();
        }

        public bool IsCorrupted => _corruptedCharPosition != -1;

        public (char expected, char actual) GetCorruptedChars => (
            GetClosing(_line.ToCharArray()[_lonelyStartingCharPosition]), _line.ToCharArray()[_corruptedCharPosition]);

        private void Inspect()
        {
            var startingChars = new List<char>();
            var chars = _line.ToCharArray();
            var latestStartIndex = -1;
            for (var i = 0; i < chars.Length; i++)
            {
                var c = chars[i];
                if (IsOpen(c))
                {
                    startingChars.Add(c);
                    latestStartIndex = i;
                    continue;
                }

                var opposite = GetClosing(startingChars.Last());
                if (opposite != c)
                {
                    _corruptedCharPosition = i;
                    _lonelyStartingCharPosition = latestStartIndex;
                    return;
                }

                startingChars.RemoveAt(startingChars.Count - 1);
            }

            startingChars.Reverse();
            _completingChars = startingChars.Select(GetClosing).ToList();
        }

        public long CompletionScore => _completingChars.Aggregate((long) 0, (total, next) => (total * 5) + CharCompletionScore(next));

        private static int CharCompletionScore(char c)
        {
            switch (c)
            {
                case ')': return 1;
                case ']': return 2;
                case '}': return 3;
                case '>': return 4;
                default: throw new NotImplementedException();
            }
        }

        private static bool IsOpen(char c) => c == '(' || c == '[' || c == '{' || c == '<';

        private static char GetClosing(char c)
        {
            switch (c)
            {
                case '(': return ')';
                case '[': return ']';
                case '{': return '}';
                case '<': return '>';
                default: throw new NotImplementedException();
            }
        }
    }
}