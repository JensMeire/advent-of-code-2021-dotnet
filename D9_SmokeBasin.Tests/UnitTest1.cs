using System;
using System.Linq;
using NUnit.Framework;

namespace D9_SmokeBasin.Tests
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
            var heightmap = new Heightmap("./testdata.txt");
            Assert.AreEqual(15, heightmap.GetLowPoints().Sum(x => x + 1));
        }
        
        [Test]
        public void Test2()
        {
            var heightmap = new Heightmap("./testdata.txt");
            var basins = heightmap.GetBasinSizes().ToList();

            Assert.AreEqual(1134, basins[0] * basins[1] * basins[2]);
        }
    }
}