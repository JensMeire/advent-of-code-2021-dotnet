using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;

namespace D15_Chiton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var data = Parser.Parse("./data.txt");
            var cave = new Cave(data);
            Console.WriteLine(cave.Travel());
            
            var data2 = Parser.ParseAndDuplicate("./data.txt");
            var cave2 = new Cave(data2);
            Console.WriteLine(cave2.Travel());
        }
    }

    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }
        public long Distance { get; set; }
        public bool Visited { get; set; }
    }

    public class Cave
    {
        private readonly Node[,] _nodes;
        private int _width;
        private int _height;


        public Cave(Node[,] nodes)
        {
            _nodes = nodes;
            _height = nodes.GetLength(0);
            _width = nodes.GetLength(1);
        }

        private IEnumerable<Node> GetNeighbours(int y, int x)
        {
            if (y > 0) yield return _nodes[y - 1, x];
            if (x > 0) yield return _nodes[y, x - 1];
            if (y < _height - 1) yield return _nodes[y + 1, x];
            if (x < _width - 1) yield return _nodes[y, x + 1];
        }

        public long Travel()
        {
            var queue = new PriorityQueue<Node, long>();
            var start = _nodes[0, 0];

            queue.Enqueue(start, 0);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                var neighbours = GetNeighbours(current.Y, current.X).Where(x => !x.Visited);
                foreach (var neighbour in neighbours)
                {
                    var distance = current.Distance + neighbour.Value;
                    if (neighbour.Visited && distance >= neighbour.Distance) continue;

                    neighbour.Distance = distance;
                    neighbour.Visited = true;
                    queue.Enqueue(neighbour, distance);
                }
            }

            return _nodes[_height - 1, _width - 1].Distance;
        }
    }

    public static class Parser
    {
        public static Node[,] Parse(string path)
        {
            var data = File.ReadLines(path).ToList();
            var result = new Node[data.Count, data.First().Length];
            for (var y = 0; y < data.Count; y++)
            {
                var row = data[y];
                for (var x = 0; x < row.Length; x++)
                {
                    var value = int.Parse(row[x].ToString());
                    result[y, x] = new Node
                    {
                        Value = value,
                        X = x,
                        Y = y
                    };
                }
            }


            return result;
        }

        public static Node[,] ParseAndDuplicate(string path)
        {
            var grid = Parse(path);
            var height = grid.GetLength(0);
            var width = grid.GetLength(1);
            var result = new Node[height * 5, width * 5];
            for (var yMod = 0; yMod < 5; yMod++)
            {
                for (var xMod = 0; xMod < 5; xMod++)
                {
                    for (var y = 0; y < height; y++)
                    {
                        for (var x = 0; x < width; x++)
                        {
                            var node = grid[y, x];
                            var newValue = node.Value + xMod + yMod;
                            var newY = (yMod * height) + y;
                            var newX = (xMod * width) + x;
                            var newNode = new Node()
                            {
                                Value = newValue > 9 ? newValue - 9 : newValue,
                                X = newX,
                                Y = newY,
                            };
                            result[newY, newX] = newNode;
                        }
                    }
                }
            }


            return result;
        }
    }
}