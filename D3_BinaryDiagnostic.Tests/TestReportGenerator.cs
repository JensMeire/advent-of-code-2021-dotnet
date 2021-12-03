using System.Collections.Generic;

namespace D3_BinaryDiagnostic.Tests
{
    public class TestReportGenerator: IReportGenerator
    {
        public List<string> Generate()
        {
            return new List<string>
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };
        }
    }
}