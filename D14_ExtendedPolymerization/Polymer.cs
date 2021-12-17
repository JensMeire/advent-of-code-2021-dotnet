using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace D14_ExtendedPolymerization
{
    public class Polymer
    {
        private readonly string _template;
        private readonly Dictionary<string, string> _instructions;
        private Dictionary<string, long> _letterCount;

        public Polymer(string template, List<Instruction> instructions)
        {
            _letterCount = new Dictionary<string, long>();
            _template = template;
            _instructions = instructions.ToDictionary(x => x.Pair, x => x.Result);
        }

        public void Step(int steps)
        {
            _letterCount = _template.GroupBy(x => x).Select(x => (x.Key, x.LongCount()))
                .ToDictionary(x => x.Key.ToString(), x => x.Item2);
            
            var instructionCount = new Dictionary<string, long>();
            for (var i = 0; i < _template.Length - 1; i++)
            {
                var pair = new string(new[] {_template[i], _template[i + 1]});
                var exists = instructionCount.TryGetValue(pair, out var count);
                if (exists) instructionCount[pair] = count + 1;
                else instructionCount.Add(pair, 1);
            }
            
            for (var i = 0; i < steps; i++)
            {
                
                var tempInstructionCount = new Dictionary<string, long>();
                foreach (var keyValuePair in instructionCount)
                {
                    var pair = keyValuePair.Key;
                    var count = keyValuePair.Value;
                    var letter = _instructions[pair];
                    var part1 = pair[0].ToString() + letter;
                    var part2 = letter + pair[1].ToString();
                    
                    
                    var exists1= tempInstructionCount.TryGetValue(part1, out var count1);
                    if (exists1) tempInstructionCount[part1] = count1 + count;
                    else tempInstructionCount.Add(part1, count);
                    
                    var exists2 = tempInstructionCount.TryGetValue(part2, out var count2);
                    if (exists2) tempInstructionCount[part2] = count2 + count;
                    else tempInstructionCount.Add(part2, count);
                    
                    var exists3 = _letterCount.TryGetValue(letter, out var count3);
                    if (exists3) _letterCount[letter] = count3 + count;
                    else _letterCount.Add(letter, count);
                }

                instructionCount = tempInstructionCount;
                Console.WriteLine("Step: " + i);
            }
        }

        public long GetDifferenceBetweenMostAndLeastOccuringChar()
        {

            var max = _letterCount.Max(x => x.Value);
            var min = _letterCount.Min(x => x.Value);
            return max - min;
        }
    }
}