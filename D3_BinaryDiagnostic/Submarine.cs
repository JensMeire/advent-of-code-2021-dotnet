using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace D3_BinaryDiagnostic
{
    public class Submarine
    {
        private readonly IReportGenerator _reportGenerator;

        public Submarine(IReportGenerator reportGenerator)
        {
            _reportGenerator = reportGenerator;
        }

        public int GetPowerUsage()
        {
            var data = _reportGenerator.Generate();
            var length = data.First().Length;
            var parts = new char[length];
            for (var i = 0; i < length; i++)
                parts[i] = GetGammaBinaryPart(i, data);


            var gammaBinary = new string(parts);
            var gamma = BinaryHelper.ConvertBinaryToInt(gammaBinary);

            var epsilonBinary = BinaryHelper.InvertBinary(gammaBinary);
            var epsilon = BinaryHelper.ConvertBinaryToInt(epsilonBinary);

            return gamma * epsilon;
        }

        private static char GetGammaBinaryPart(int index, ICollection<string> data)
        {
            var amountOfOne = data.Count(x => x[index] == '1');
            return (data.Count - amountOfOne) > amountOfOne ? '0' : '1';
        }

        public int GetOxygenGeneratorRating()
        {
            var data = _reportGenerator.Generate();
            return FilterData(data, OxygenGeneratorRatingComparer);
        }
        
        public int GetCo2ScrubberRating()
        {
            var data = _reportGenerator.Generate();
            return FilterData(data, Co2ScrubberRatingComparer);
        }

        private static char OxygenGeneratorRatingComparer(int amountOfOne, int totalAmount) => (totalAmount == amountOfOne * 2
            ? '1'
            : ((totalAmount - amountOfOne) > amountOfOne ? '0' : '1'));
        
        private static char  Co2ScrubberRatingComparer (int amountOfOne, int totalAmount) => (totalAmount == amountOfOne * 2
            ? '0'
            : ((totalAmount - amountOfOne) < amountOfOne ? '0' : '1'));

        private static int FilterData(List<string> data, Func<int, int, char> getChar)
        {
            var length = data.First().Length;
            var index = 0;
            while (data.Count != 1)
            {
                if (index == length) throw new Exception("No number found");
                var amountOfOne = data.Count(x => x[index] == '1');
                data = data.Where(x => x[index] == getChar(amountOfOne, data.Count)).ToList();

                index++;
            }

            var first = data.First();
            return BinaryHelper.ConvertBinaryToInt(first);
        }
    }
}