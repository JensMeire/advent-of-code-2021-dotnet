using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace D6_Lanternfish.Tests
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
            var testInput = "3,4,3,1,2";
            var sea = new Sea();
            var fishes = testInput.Split(',').Select(int.Parse)
                .ToList();
            sea.AddLanternFished(fishes);
            
            Assert.AreEqual(5, sea.Amount());

            for (var i = 0; i < 18; i++)
                sea.DayPassed();
            
            Assert.AreEqual(26, sea.Amount());
            
            for (var i = 0; i < 62; i++)
                sea.DayPassed(); 
            
            Assert.AreEqual(5934, sea.Amount());
        }
    }
}