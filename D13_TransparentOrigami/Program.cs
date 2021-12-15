using System;

namespace D13_TransparentOrigami
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Parser.Parse("./data.txt");
            var paper = new Paper(data);
            paper.Fold(1);
            Console.WriteLine(paper.GetPoints);
            
            var paper2 = new Paper(data);
            paper2.Fold();
            for (var y = 0; y < paper2.Grid.GetLength(0); y++)
            {
                var line = "";
                for (var x = 0; x < paper2.Grid.GetLength(1); x++)
                {
                    line += (paper2.Grid[y, x] ? "#" : ".");
                }
                Console.WriteLine(line);
            }
        }
    }
}