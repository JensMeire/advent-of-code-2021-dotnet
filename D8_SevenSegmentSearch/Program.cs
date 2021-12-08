using System;
using System.Linq;

namespace D8_SevenSegmentSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Parser.Parse("./data.txt");
            var count = data.Sum(x => x.AmountOfUniqueSegmentedValues);
            Console.WriteLine(count);
            var count2 = data.Sum(x => x.GetOutputValue());
            Console.WriteLine(count2);
        }
    }
}