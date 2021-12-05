using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D5_HydrothermalVenture
{
    class Program
    {
        //No OOP Sunday woohoo
        static void Main(string[] args)
        {
            
            var (lines, maxX, maxY)= GetData("./data.txt");
            var horizontalAndVerticalLines = lines.Where(line => line.p0.x == line.p1.x || line.p0.y == line.p1.y).ToList();
            var grid1 = CreateGrid(horizontalAndVerticalLines, maxX, maxY);
            var cast = grid1.Cast<int>().ToList();
            Console.WriteLine(cast.Count(x => x > 1));

            var lines2 = lines.Where(line =>
            {
                if (line.p0.x == line.p1.x || line.p0.y == line.p1.y) return true;
                if (Math.Abs(line.p0.x - line.p1.x) == Math.Abs(line.p0.y - line.p1.y)) return true;
                return false;
            }).ToList();
            
            var grid2 = CreateGrid(lines2, maxX, maxY);
            var cast2 = grid2.Cast<int>().ToList();
            Console.WriteLine(cast2.Count(x => x > 1));
            Console.WriteLine("Hello World!");
        }

        public static int[,] CreateGrid(List<((int x, int y) p0, (int x, int y) p1)> lines, int maxX, int maxY)
        {
            var grid = new int[maxX + 1, maxY + 1];
            foreach (var line in lines)
            {
                var startPoint = line.p0;
                var endPoint = line.p1;
                var currentX = startPoint.x;
                var currentY = startPoint.y;
                while (currentX != endPoint.x || currentY != endPoint.y)
                {
                    grid[currentX, currentY] += 1;

                    if (currentX != endPoint.x)
                    {
                        if (startPoint.x < endPoint.x) currentX += 1;
                        if (startPoint.x > endPoint.x) currentX -= 1;
                    }
                    if (currentY != endPoint.y)
                    {
                        if (startPoint.y < endPoint.y) currentY += 1;
                        if (startPoint.y > endPoint.y) currentY -= 1;
                    }
                }
                grid[currentX, currentY] += 1;
            }

            return grid;
        }

        public static (List<((int x, int y) p0, (int x, int y) p1)>,int maxX, int maxY) GetData(string path)
        {
            var lines = File.ReadLines(path);
            var maxX = 0;
            var maxY = 0;
            var newLines = lines.Select(x =>
            {
                var split = x.Split(new string[] {" -> "}, StringSplitOptions.None);
                var split1 = split[0].Split(',');
                var split2 = split[1].Split(',');
                var x0 = int.Parse(split1[0]);
                if (x0 > maxX) maxX = x0;
                var y0 = int.Parse(split1[1]);
                if (y0 > maxY) maxY = y0;
                var x1 = int.Parse(split2[0]);
                if (x1 > maxX) maxX = x1;
                var y1 = int.Parse(split2[1]);
                if (y1 > maxY) maxY = y1;
                return ((x0, y0), (x1, y1));
            }).ToList();

            return (newLines, maxX, maxY);
        }
    }
}