using System;
using System.Linq;
using NUnit.Framework;

namespace D12_PassagePathing.Tests
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
            var data = Parser.Parse("./testestdata.txt");
            var traverser = new Traverser(data);
            traverser.Traverse();
            traverser.Paths.ForEach(x => Console.WriteLine(string.Join(",", x)));
            
            Assert.AreEqual(10, traverser.Paths.Count);
        }
        
        [Test]
        public void Test2()
        {
            var data = Parser.Parse("./testdata.txt");
            var traverser = new Traverser(data);
            traverser.Traverse();
            traverser.Paths.ForEach(x => Console.WriteLine(string.Join(",", x)));
            
            Assert.AreEqual(19, traverser.Paths.Count);
        }
        
        [Test]
        public void Test3()
        {
            var data = Parser.Parse("./testdata2.txt");
            var traverser = new Traverser(data);
            traverser.Traverse();
            traverser.Paths.ForEach(x => Console.WriteLine(string.Join(",", x)));
            
            Assert.AreEqual(226, traverser.Paths.Count);
        }
        
        [Test]
        public void Test4()
        {
            var data = Parser.Parse("./testestdata.txt");
            var traverser = new Traverser(data);
            traverser.Traverse(2);
            traverser.Paths.ForEach(x => Console.WriteLine(string.Join(",", x)));
            
            Assert.AreEqual(36, traverser.Paths.Count);
        }
        
        [Test]
        public void Test5()
        {
            var data = Parser.Parse("./testdata.txt");
            var traverser = new Traverser(data);
            traverser.Traverse(2);
            traverser.Paths.ForEach(x => Console.WriteLine(string.Join(",", x)));
            
            Assert.AreEqual(103, traverser.Paths.Count);
        }
        
        [Test]
        public void Test6()
        {
            var data = Parser.Parse("./testdata2.txt");
            var traverser = new Traverser(data);
            traverser.Traverse(2);
            traverser.Paths.ForEach(x => Console.WriteLine(string.Join(",", x)));
            
            Assert.AreEqual(3509, traverser.Paths.Count);
        }
    }
}