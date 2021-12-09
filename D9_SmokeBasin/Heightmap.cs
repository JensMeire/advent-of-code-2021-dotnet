using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace D9_SmokeBasin
{
    public class Heightmap
    {
        private int[,] _map;
        private int _length;
        private int _width;


        public Heightmap(string dataPath)
        {
            Get2DArray(dataPath);
        }

        public void Get2DArray(string path)
        {
            var arr = File.ReadLines(path).ToList();
            var d2 = new int[arr.First().Length, arr.Count];
            _width = arr.First().Length;
            _length = arr.Count;
            for (var i = 0; i < arr.Count; i++)
            {
                var chars = arr[i].ToCharArray();
                for (var j = 0; j < chars.Length; j++)
                {
                    d2[j, i] = int.Parse(chars[j].ToString());
                }
            }

            _map = d2;
        }

        public List<(int x, int y)> GetLowPointsCoordinates()
        {
            var points = new List<(int, int)>();
            for (var i = 0; i < _length; i++)
            {
                for (var j = 0; j < _width; j++)
                {
                    var current = _map[j, i];
                    var left = j == 0 ? 10 : _map[j - 1, i];
                    var upper = i == 0 ? 10 : _map[j, i - 1];
                    var right = j == (_width - 1) ? 10 : _map[j + 1, i];
                    var lower = i == (_length - 1) ? 10 : _map[j, i + 1];
                    var isLowest = current < left && current < right && current < lower && current < upper;
                    if (isLowest)
                    {
                        points.Add((j, i));
                    }
                }
            }

            return points;
        }

        public List<int> GetBasinSizes()
        {
            var allCoords = new List<(int x, int y)>();
            return GetLowPointsCoordinates().Select(x =>
            {
                
                var coords = new List<(int x, int y)>();
                BasinSize(x.x, x.y, coords);
                var newCoords = coords.Where(c => !allCoords.Any(ac => ac.x == c.x && ac.y == c.y)).ToList();
                allCoords.AddRange(newCoords);
                return newCoords.Count;
            }).OrderByDescending(x => x).ToList();
        }

        private void BasinSize(int x, int y, List<(int x, int y)> coords)
        {
            var current = _map[x, y];
            if (current == 9) return;
           
            if (!coords.Any(c => c.x == x && c.y == y))
                coords.Add((x, y));

            var left = x == 0 ? 10 : _map[x - 1, y];
            var upper = y == 0 ? 10 : _map[x, y - 1];
            var right = x == (_width - 1) ? 10 : _map[x + 1, y];
            var lower = y == (_length - 1) ? 10 : _map[x, y + 1];

            if (left != 10 && left > current)
            {
                BasinSize(x - 1, y, coords);
            }

            if (upper != 10 && upper > current)
            {
                BasinSize(x, y - 1, coords);
            }

            if (right != 10 && right > current)
            {
                BasinSize(x + 1, y, coords);
            }

            if (lower != 10 && lower > current)
            {
                BasinSize(x, y + 1, coords);
            }
        }

        public List<int> GetLowPoints()
        {
            return GetLowPointsCoordinates().Select(x => _map[x.x, x.y]).ToList();
        }
    }
}