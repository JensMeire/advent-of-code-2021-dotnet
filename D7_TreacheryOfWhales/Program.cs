using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D7_TreacheryOfWhales
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = File.ReadLines("./data.txt").First().Split(',').Select(int.Parse).ToList();
            numbers = numbers.OrderBy(i => i).ToList();
            var med = FindMedian(numbers);
            var fuel = numbers.Sum(x => Math.Abs(x - med));
            Console.WriteLine(fuel);


            var max = numbers.Max();
            var lowest = -1;
            for (var i = 0; i < max; i++)
            {
                var newFuel = numbers.Sum(x => Factorial(Math.Abs(x - i)));
                if (newFuel < lowest || lowest == -1) lowest = newFuel;
            }
            Console.WriteLine(lowest);

        }
        public static double FindMedian(List<int> a)
        {
            var n = a.Count;
            if (n % 2 != 0)
                return a[n / 2];
 
            return (a[(n - 1) / 2] + a[n / 2]) / 2.0;
        }

        public static int Factorial(double a)
        {
            var fact = 0;
            for (var x = 0; x < a; x++)
            {
                fact += (x + 1);
            }

            return fact;
        }
    }
}