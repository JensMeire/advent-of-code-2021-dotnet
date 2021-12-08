using System;
using System.Linq;
using NUnit.Framework;

namespace D8_SevenSegmentSearch.Tests
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
            var count = data.Sum(x => x.AmountOfUniqueSegmentedValues);

            Assert.AreEqual(26, count);
        }
        
        [Test]
        public void Test2()
        {
            var data = Parser.Parse("./testdata.txt");
            var count = data.Sum(x => x.GetOutputValue());

            Assert.AreEqual(61229, count);
        }
    }
}