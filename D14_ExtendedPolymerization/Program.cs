using System;

namespace D14_ExtendedPolymerization
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Parser.Parse("./data.txt");
            var poly = new Polymer(data.template, data.instructions);
            poly.Step(40);
            Console.WriteLine(poly.GetDifferenceBetweenMostAndLeastOccuringChar());
            Console.ReadLine();
        }
    }
}