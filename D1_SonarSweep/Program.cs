using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D1_SonarSweep
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var submarine = new Submarine(File.ReadLines("./data.txt").Select(int.Parse).ToList(), Color.Yellow);
            Console.WriteLine(submarine.GetIncreasedSonars());
            Console.WriteLine(submarine.GetIncreasedSonarsWindowed());
        }
    }

    public enum Color
    {
        Yellow
    }
    
    class Submarine
    {
        private readonly List<int> _sonars;
        private readonly Color _color;

        public Submarine(List<int> sonars, Color color)
        {
            _sonars = sonars;
            _color = color;
        }

        public int GetIncreasedSonars()
        {
            var total = 0;
            var prev = 0;
            foreach (var nVal in _sonars)
            {
                if (prev != 0 && nVal > prev) total++;
                prev = nVal;
            }

            return total;
        }

        public int GetIncreasedSonarsWindowed(int window = 3)
        {
            var total = 0;
            var prev = 0;
            for (var i = 0; i <= (_sonars.Count - window); i++)
            {
                var subset = _sonars.Skip(i).Take(window).ToList();
                var sum = subset.Sum();
                if (prev != 0 && sum > prev) total++;
                prev = sum;
            }

            return total;
        }
    }
}