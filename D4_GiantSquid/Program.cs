using System;

namespace D4_GiantSquid
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new DataParser();
            parser.Parse("./data.txt");
            var game = new BingoGame(parser.Boards, parser.Numbers);
            game.Start();
            Console.WriteLine(game.LeaderBoard.First.Score);
            Console.WriteLine(game.LeaderBoard.Last.Score);
        }
    }
}