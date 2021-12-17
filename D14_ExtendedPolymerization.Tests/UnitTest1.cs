using System;
using NUnit.Framework;

namespace D14_ExtendedPolymerization.Tests
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
            var poly = new Polymer(data.template, data.instructions);
            poly.Step(10);
            Assert.AreEqual(1588, poly.GetDifferenceBetweenMostAndLeastOccuringChar());
        }
        
        [Test]
        public void Test2()
        {
            var data = Parser.Parse("./testdata.txt");
            var poly = new Polymer(data.template, data.instructions);
            poly.Step(40);
            
            Assert.AreEqual(2188189693529, poly.GetDifferenceBetweenMostAndLeastOccuringChar());
        }
    }
}