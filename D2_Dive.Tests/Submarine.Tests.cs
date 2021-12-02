using System.Collections.Generic;
using NUnit.Framework;

namespace D2_Dive.Test
{
    public class Tests
    {

        private List<string> _data;
        [SetUp]
        public void Setup()
        {
            _data = new List<string>
            {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2"
            };
        }

        [Test]
        public void Test1()
        {
            var parser = new CommandParser(_data);
            var commands = parser.GetCommands();
            var submarine = new Submarine();
            submarine.Move(commands);
            Assert.AreEqual(15, submarine.HorizontalPosition);
            Assert.AreEqual(10, submarine.VerticalPosition);
        }
        
        [Test]
        public void Test2()
        {
            var parser = new CommandParser(_data);
            var commands = parser.GetCommands();
            var submarine = new CoolSubmarine();
            submarine.Move(commands);
            Assert.AreEqual(15, submarine.HorizontalPosition);
            Assert.AreEqual(60, submarine.VerticalPosition);
        }
    }
}