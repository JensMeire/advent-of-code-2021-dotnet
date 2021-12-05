using System.Linq;
using NUnit.Framework;

namespace D4_GiantSquid.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestParser()
        {
            var parser = new DataParser();
            parser.Parse("./testdata.txt");
            Assert.AreEqual(3, parser.Boards.Count);
            Assert.AreEqual("7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1", string.Join(",", parser.Numbers.Select(x => x.ToString()).ToArray()));
        }
        
        [Test]
        public void Test1()
        {
            var parser = new DataParser();
            parser.Parse("./testdata.txt");
            var game = new BingoGame(parser.Boards, parser.Numbers);
            game.Start();
            Assert.AreEqual(4512, game.LeaderBoard.First.Score);
        }

        [Test]
        public void Test2()
        {
            var parser = new DataParser();
            parser.Parse("./testdata.txt");
            var game = new BingoGame(parser.Boards, parser.Numbers);
            game.Start();
            Assert.AreEqual(1924, game.LeaderBoard.Last.Score); 
        }
    }
}