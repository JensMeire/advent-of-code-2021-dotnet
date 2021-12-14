using System;
using System.Linq;

namespace D12_PassagePathing
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Parser.Parse("./data.txt");
            var traverser = new Traverser(data);
            traverser.Traverse();
            traverser.Paths.ForEach(x => Console.WriteLine(string.Join(",", x)));
            var amount = traverser.Paths.Count(x => x.Any(y => !y.IsBig));
            Console.WriteLine(amount);
            
            var traverser2 = new Traverser(data);
            traverser2.Traverse(2);
            traverser2.Paths.ForEach(x => Console.WriteLine(string.Join(",", x)));
            var amount2 = traverser2.Paths.Count(x => x.Any(y => !y.IsBig));
            Console.WriteLine(amount2);
        }
    }
}