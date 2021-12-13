using System;
using System.IO;

namespace D11_DumboOctopus
{
    class Program
    {
        static void Main(string[] args)
        {

            var grid = new int[10, 10];
            var y = 0;
            foreach (var line in File.ReadLines("./data.txt"))
            {
                var arr = line.ToCharArray();
                for (var i = 0; i < arr.Length; i++)
                {
                    grid[y, i] = int.Parse(arr[i].ToString());
                }
                y++;
            }
            
            var cave = new Cave(grid);
            for (var i = 0; i < 100; i++)
            {
                cave.Step();
            }
            
            Console.WriteLine(cave.Flashes);
            
            y = 0;
            foreach (var line in File.ReadLines("./data.txt"))
            {
                var arr = line.ToCharArray();
                for (var i = 0; i < arr.Length; i++)
                {
                    grid[y, i] = int.Parse(arr[i].ToString());
                }
                y++;
            }
            
            var cave2 = new Cave(grid);
            var allBlinked = false;
            var step = 0;
            while (!allBlinked)
            {
                allBlinked = cave2.Step();
                step++;
            }
            
            Console.WriteLine(step);
        }
    }
}