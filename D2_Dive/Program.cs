using System;
using System.IO;
using System.Linq;
using System.Net;

namespace D2_Dive
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new CommandParser(File.ReadLines("./data.txt").ToList());
            var commands = parser.GetCommands();
            var submarine = new Submarine();
            submarine.Move(commands);
            Console.WriteLine(submarine.HorizontalPosition * submarine.VerticalPosition);
            
            var coolSubmarine = new CoolSubmarine();
            coolSubmarine.Move(commands);
            Console.WriteLine(coolSubmarine.HorizontalPosition * coolSubmarine.VerticalPosition);
        }
    }
}