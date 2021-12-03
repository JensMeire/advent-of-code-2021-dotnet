using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D3_BinaryDiagnostic
{
    public class ReportGenerator : IReportGenerator
    {
        private readonly List<string> _data;

        public ReportGenerator(string reportLocation)
        {
            _data = File.ReadLines(reportLocation).ToList();
        }

        public List<string> Generate()
        {
            return _data;
        }
    }
}