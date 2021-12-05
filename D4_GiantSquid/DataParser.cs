using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace D4_GiantSquid
{
    public class DataParser
    {
        private List<int> _numbers;
        private List<BingoBoard> _boards;


        public void Parse(string path)
        {
            var lines = File.ReadLines(path).ToList();
            _numbers = lines.First().Split(',').Select(int.Parse).ToList();
            var data = lines.Skip(1).ToList();
            _boards = new List<BingoBoard>();
            var tempLines = new List<BingoRow>();
            data.ForEach(l =>
            {
                if (string.IsNullOrEmpty(l))
                {
                    if (tempLines.Count != 0) _boards.Add(new BingoBoard(tempLines));
                    tempLines = new List<BingoRow>();
                    return;
                }


                tempLines.Add(new BingoRow(GetNumbers(l).ToList()));
            });
            _boards.Add(new BingoBoard(tempLines));
        }

        private IEnumerable<BingoNumber> GetNumbers(string line)
        {
            var index = 0;
            Console.WriteLine("line: " + line);
            while ((line.Length - 1) >= index)
            {
                var nr = new string(new char[] {line[index], line[++index]});
                Console.WriteLine(nr);
                yield return new BingoNumber(int.Parse(nr.TrimStart()));
                index += 2;
            }
        }

        public List<BingoBoard> Boards => _boards;

        public List<int> Numbers => _numbers;
    }
}