using System;
using System.Collections.Generic;
using System.Linq;

namespace D6_Lanternfish
{
    public class Sea
    {
        //Not what i like but lazy
        private Int64 _lanternfishes0;
        private Int64 _lanternfishes1;
        private Int64 _lanternfishes2;
        private Int64 _lanternfishes3;
        private Int64 _lanternfishes4;
        private Int64 _lanternfishes5;
        private Int64 _lanternfishes6;
        private Int64 _lanternfishes7;
        private Int64 _lanternfishes8;



        public void AddLanternFished(List<int> values)
        {
            values.ForEach(AddLanternFish);
        }
        
        public void AddLanternFish(int value)
        {
            switch (value)
            {
                case 0: _lanternfishes0++; break;
                case 1: _lanternfishes1++; break;
                case 2: _lanternfishes2++; break;
                case 3: _lanternfishes3++; break;
                case 4: _lanternfishes4++; break;
                case 5: _lanternfishes5++; break;
                case 6: _lanternfishes6++; break;
                case 7: _lanternfishes7++; break;
                case 8: _lanternfishes8++; break;
            }
        }


        public void DayPassed()
        {
            var temp0 = _lanternfishes0;
            _lanternfishes0 = _lanternfishes1;
            _lanternfishes1 = _lanternfishes2;
            _lanternfishes2 = _lanternfishes3;
            _lanternfishes3 = _lanternfishes4;
            _lanternfishes4 = _lanternfishes5;
            _lanternfishes5 = _lanternfishes6;
            _lanternfishes6 = _lanternfishes7 + temp0;
            _lanternfishes7 = _lanternfishes8;
            _lanternfishes8 = temp0;

        }

        public Int64 Amount()
        {
            Console.WriteLine(_lanternfishes0);
            Console.WriteLine(_lanternfishes1);
            Console.WriteLine(_lanternfishes2);
            Console.WriteLine(_lanternfishes3);
            Console.WriteLine(_lanternfishes4);
            Console.WriteLine(_lanternfishes5);
            Console.WriteLine(_lanternfishes6);
            Console.WriteLine(_lanternfishes7);
            Console.WriteLine(_lanternfishes8);
            return _lanternfishes0 + _lanternfishes1 +_lanternfishes2 +_lanternfishes3 +_lanternfishes4 +_lanternfishes5 +_lanternfishes6 +_lanternfishes7 +_lanternfishes8; 
        }
    }
}