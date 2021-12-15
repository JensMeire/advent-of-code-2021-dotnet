using System;
using System.Linq;

namespace D13_TransparentOrigami
{
    public class Paper
    {
        private readonly Data _data;
        private int _height;
        private int _width;

        public bool[,] Grid { get; private set; }

        public Paper(Data data)
        {
            _data = data;
            _width = data.Points.Select(x => x.x).Max() + 1;
            _height = data.Points.Select(x => x.y).Max() + 1;
            Grid = new bool[_height, _width];
            InitPoints();
        }

        private void InitPoints()
        {
            _data.Points.ForEach(p => { Grid[p.y, p.x] = true; });
        }

        public void Fold(int steps = 0)
        {
            var folds = steps == 0 ? _data.Folds : _data.Folds.Take(steps).ToList();
            folds.ForEach(x =>
            {
                if (x.isX) FoldLeft(x.value);
                else FoldUp(x.value);
            });
        }

        private void FoldUp(int value)
        {
            var grid = new bool[value, _width];
            for (var y = 0; y < value; y++)
            {
                for (var x = 0; x < _width; x++)
                {
                    var mirrored = (2 * value) - y;
                    grid[y, x] = Grid[y, x] || Grid[mirrored, x];
                }
            }

            Grid = grid;
            _height = grid.GetLength(0);
        }

        private void FoldLeft(int value)
        {
            var grid = new bool[_height, value];
            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < value; x++)
                {
                    var mirrored = (2 * value) - x;
                    grid[y, x] = Grid[y, x] || Grid[y, mirrored];
                }
            }

            Grid = grid;
            _width = grid.GetLength(1);
        }

        public int GetPoints => Grid.Cast<bool>().Count(x => x);
    }
}