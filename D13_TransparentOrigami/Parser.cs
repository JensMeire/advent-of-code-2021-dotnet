using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;

namespace D13_TransparentOrigami
{
    public static class Parser
    {
        public static Data Parse(string path)
        {
            var lines = File.ReadLines(path).ToList();
            var data = new Data();
            foreach (var line in lines.Where(line => !string.IsNullOrWhiteSpace(line)))
            {
                if (line.StartsWith("fold along"))
                {
                    var fa = line.Replace("fold along ", "");
                    var faParts = fa.Split('=');
                    data.Folds.Add((int.Parse(faParts[1]), faParts[0] == "x"));
                    continue;
                }

                var parts = line.Split(',');
                data.Points.Add((int.Parse(parts[0]), int.Parse(parts[1])));
            }

            return data;
        }
    }


    public class Data
    {
        public List<(int x, int y)> Points { get; private set; }
        public List<(int value, bool isX)> Folds { get; private set; }

        public Data()
        {
            Points = new List<(int x, int y)>();
            Folds = new List<(int value, bool isX)>();
        }
    }
}