using System;
using System.Collections;
using System.Linq;

namespace D3_BinaryDiagnostic
{
    public static class BinaryHelper
    {
        public static int ConvertBinaryToInt(string binary) => Convert.ToInt32(binary,2);

        public static string InvertBinary(string binary)
        {
            var chars = binary.Select(x => x == '1' ? '0' : '1');
            return new string(chars.ToArray());
        }
        
    }
}