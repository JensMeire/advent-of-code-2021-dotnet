using System.Linq;
using NUnit.Framework;

namespace D13_TransparentOrigami.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var data = Parser.Parse("./testdata.txt");
            var paper = new Paper(data);
            paper.Fold(1);
            Assert.AreEqual(17, paper.GetPoints);
        }
    }
}