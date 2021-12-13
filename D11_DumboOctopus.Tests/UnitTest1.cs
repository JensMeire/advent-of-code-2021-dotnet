using System.IO;
using NUnit.Framework;

namespace D11_DumboOctopus.Tests
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
            var grid = new int[10, 10];
            var y = 0;
            foreach (var line in File.ReadLines("./testdata.txt"))
            {
                var arr = line.ToCharArray();
                for (var i = 0; i < arr.Length; i++)
                {
                    grid[y, i] = int.Parse(arr[i].ToString());
                }
                y++;
            }
            
            var cave = new Cave(grid);
            for (var i = 0; i < 10; i++)
            {
                cave.Step();
            }
            
            Assert.AreEqual(204, cave.Flashes);
        }
        
        [Test]
        public void Test2()
        {
            var grid = new int[10, 10];
            var y = 0;
            foreach (var line in File.ReadLines("./testdata.txt"))
            {
                var arr = line.ToCharArray();
                for (var i = 0; i < arr.Length; i++)
                {
                    grid[y, i] = int.Parse(arr[i].ToString());
                }
                y++;
            }
            
            var cave = new Cave(grid);
            var allBlinked = false;
            var step = 0;
            while (!allBlinked)
            {
                allBlinked = cave.Step();
                step++;
            }
            
            Assert.AreEqual(195, step);
        }
    }
}