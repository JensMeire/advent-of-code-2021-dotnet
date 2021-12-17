using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D14_ExtendedPolymerization
{
    public static class Parser
    {
        public static (string template, List<Instruction> instructions) Parse(string path)
        {
            var lines = File.ReadLines(path).ToList();
            var template = lines.First();
            var instructions = lines.Skip(2).Select(x =>
            {
                var parts = x.Split(new string[] {" -> "}, StringSplitOptions.None);
                return new Instruction
                {
                    Pair = parts[0],
                    Result = parts[1]
                };
            });
            return (template, instructions.ToList());
        }
    }
}