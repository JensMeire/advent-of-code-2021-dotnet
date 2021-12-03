using System;

namespace D3_BinaryDiagnostic
{
    class Program
    {
        static void Main(string[] args)
        {
            var reportGenerator = new ReportGenerator("./data.txt");
            var submarine = new Submarine(reportGenerator);
            var powerUsage = submarine.GetPowerUsage();
            Console.WriteLine(powerUsage);
            
            var oxygen = submarine.GetOxygenGeneratorRating();
            var co2 = submarine.GetCo2ScrubberRating();
            Console.WriteLine(oxygen * co2);
        }
    }
}