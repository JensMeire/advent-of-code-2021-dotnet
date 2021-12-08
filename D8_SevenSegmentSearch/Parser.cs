using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D8_SevenSegmentSearch
{
    public static class Parser
    {
        public static List<Display> Parse(string path)
        {
            return File.ReadLines(path).Select(x =>
            {
                var parts = x.Split('|');
                return new Display(parts[0].Trim().Split(' ').ToList(), parts[1].Trim().Split(' ').ToList());
            }).ToList();
        }
    }
}