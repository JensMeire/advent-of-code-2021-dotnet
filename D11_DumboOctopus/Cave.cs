using System;

namespace D11_DumboOctopus
{
    public class Cave
    {
        private readonly int[,] _grid;
        private int _height;
        private int _width;
        private int _flashes = 0;

        public int Flashes => _flashes;

        public Cave(int[,] grid)
        {
            _grid = grid;
            _height = grid.GetLength(0);
            _width = grid.GetLength(1);
        }

        public bool Step()
        {
            var current = _flashes;
            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < _width; x++)
                {
                    _grid[y, x] += 1;
                }
            }
            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < _width; x++)
                {
                    if( _grid[y, x] > 9) Flash(y,x);  
                }
            }

            return current + (_height * _width) == _flashes;
        }

        public void Increment(int y, int x)
        {
            var current = _grid[y, x];
            if (current != 0)
                _grid[y, x] = ++current;
            if( current > 9) Flash(y,x);  
        }
        
        public void Flash(int y, int x)
        {
            _grid[y, x] = 0;
            _flashes++;
            if (y != 0)
            {
                if (x != 0) Increment(y - 1, x - 1);
                if (x + 1 != _width) Increment(y - 1, x + 1);
                Increment(y - 1, x);
            }

            if (y + 1 != _height)
            {
                if (x != 0) Increment(y + 1, x - 1);
                if (x + 1 != _width) Increment(y + 1, x + 1);
                Increment(y + 1, x);
            }

            if (x != 0) Increment(y, x - 1);
            if (x + 1 != _width) Increment(y, x + 1);
        }
    }
}