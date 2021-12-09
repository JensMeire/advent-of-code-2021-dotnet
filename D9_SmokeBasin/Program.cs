using System;
using System.Linq;

namespace D9_SmokeBasin
{
    class Program
    {
        static void Main(string[] args)
        {
            var heightmap = new Heightmap("./data.txt");
            Console.WriteLine(heightmap.GetLowPoints().Sum(x => x + 1));
            
            var basins = heightmap.GetBasinSizes().ToList();
            Console.WriteLine(basins[0] * basins[1] * basins[2]);
        }
    }
}