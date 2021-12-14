using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D12_PassagePathing
{
    public static class Parser
    {
        public static Dictionary<string, Cave> Parse(string path)
        {
            var map = new Dictionary<string, Cave>();
            var lines = File.ReadLines(path).ToList();
            foreach (var line in lines)
            {
                var parts = line.Split('-');
                var part1 = parts[0];
                map.TryGetValue(part1, out var cave1);
                if (cave1 == null)
                {
                     cave1 = new Cave(part1);
                     map[part1] = cave1;
                }
                
                var part2= parts[1];
                map.TryGetValue(part2, out var cave2);
                if (cave2 == null)
                {
                    cave2 = new Cave(part2);
                    map[part2] = cave2;
                } 
                
                cave1.AddConnection(cave2);
                cave2.AddConnection(cave1);
            }

            return map;
        }
    }
}