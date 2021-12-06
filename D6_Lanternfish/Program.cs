using System;
using System.IO;
using System.Linq;

namespace D6_Lanternfish
{
    class Program
    {
        static void Main(string[] args)
        {
            var fishes = File.ReadLines("./data.txt").First().Split(',').Select(int.Parse)
                .ToList();
            var sea = new Sea();
            sea.AddLanternFished(fishes);
            
            
            for (var i = 0; i < 80; i++)
                sea.DayPassed();
            
            Console.WriteLine(sea.Amount());
            
            for (var i = 0; i < (256 - 80); i++)
                sea.DayPassed();
            
            Console.WriteLine(sea.Amount());
        }
    }
}