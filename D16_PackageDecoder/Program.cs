// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace D16_PackageDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var res = BinaryHelper.HexToBinaryString(
                "6053231004C12DC26D00526BEE728D2C013AC7795ACA756F93B524D8000AAC8FF80B3A7A4016F6802D35C7C94C8AC97AD81D30024C00D1003C80AD050029C00E20240580853401E98C00D50038400D401518C00C7003880376300290023000060D800D09B9D03E7F546930052C016000422234208CC000854778CF0EA7C9C802ACE005FE4EBE1B99EA4C8A2A804D26730E25AA8B23CBDE7C855808057C9C87718DFEED9A008880391520BC280004260C44C8E460086802600087C548430A4401B8C91AE3749CF9CEFF0A8C0041498F180532A9728813A012261367931FF43E9040191F002A539D7A9CEBFCF7B3DE36CA56BC506005EE6393A0ACAA990030B3E29348734BC200D980390960BC723007614C618DC600D4268AD168C0268ED2CB72E09341040181D802B285937A739ACCEFFE9F4B6D30802DC94803D80292B5389DFEB2A440081CE0FCE951005AD800D04BF26B32FC9AFCF8D280592D65B9CE67DCEF20C530E13B7F67F8FB140D200E6673BA45C0086262FBB084F5BF381918017221E402474EF86280333100622FC37844200DC6A8950650005C8273133A300465A7AEC08B00103925392575007E63310592EA747830052801C99C9CB215397F3ACF97CFE41C802DBD004244C67B189E3BC4584E2013C1F91B0BCD60AA1690060360094F6A70B7FC7D34A52CBAE011CB6A17509F8DF61F3B4ED46A683E6BD258100667EA4B1A6211006AD367D600ACBD61FD10CBD61FD129003D9600B4608C931D54700AA6E2932D3CBB45399A49E66E641274AE4040039B8BD2C933137F95A4A76CFBAE122704026E700662200D4358530D4401F8AD0722DCEC3124E92B639CC5AF413300700010D8F30FE1B80021506A33C3F1007A314348DC0002EC4D9CF36280213938F648925BDE134803CB9BD6BF3BFD83C0149E859EA6614A8C");
            var p = new OperationalPackage(res);
            p.Parse();
            Console.WriteLine( p.VersionSum());
            Console.WriteLine( p.Value);
        }
    }

    public enum PackageType
    {
        Literal,
        Operational
    }

    public class Package
    {
        protected readonly string _input;
        protected readonly string _useableBits;
        public int Version { get; set; }
        public int Id { get; set; }

        public string UsedBits { get; set; }
        public long Value { get; set; }

        public PackageType PackageType => Id == 4 ? PackageType.Literal : PackageType.Operational;


        public Package(Package package)
        {
            _input = package._input;
            _useableBits = package._useableBits;
            Version = package.Version;
            Id = package.Id;
            UsedBits = package.UsedBits;
        }

        public Package(string input)
        {
            _input = input;
            Version = BinaryHelper.ToInt(input.Take(3).ToActualString());
            Id = BinaryHelper.ToInt(input.Skip(3).Take(3).ToActualString());
            UsedBits = input.Take(6).ToActualString();
            _useableBits = _input.Skip(6).ToActualString();
        }

        public virtual void Parse()
        {
        }

        public virtual int VersionSum()
        {
            return Version;
        }

        protected static Package Create(string input)
        {
            var p = new Package(input);
            if (p.PackageType == PackageType.Literal) return new LiteralPackage(p);
            return new OperationalPackage(p);
        }
    }

    public class LiteralPackage : Package
    {
        public LiteralPackage(string input) : base(input)
        {
        }

        public LiteralPackage(Package package) : base(package)
        {
        }

        public override void Parse()
        {
            var binaryNumber = "";
            var hasMore = true;
            var parsedAmountOfBits = 0;
            while (hasMore)
            {
                var subset = _useableBits.Skip(parsedAmountOfBits).Take(5).ToActualString();
                if (subset.First() == '0')
                    hasMore = false;

                var bits = subset.Skip(1).ToActualString();
                UsedBits += subset;
                binaryNumber += bits;
                parsedAmountOfBits += 5;
            }

            Value = BinaryHelper.ToLong(binaryNumber);
        }
    }

    public class OperationalPackage : Package
    {
        public List<Package> SubPackages { get; set; }

        public OperationalPackage(string input) : base(input)
        {
            SubPackages = new List<Package>();
        }

        public OperationalPackage(Package package) : base(package)
        {
            SubPackages = new List<Package>();
        }

        public long GetValue()
        {
            switch (Id)
            {
                case 0: return SubPackages.Sum(x => x.Value);
                case 1: return SubPackages.Aggregate((long) 1, (i, package) => i * package.Value);
                case 2: return SubPackages.Min(x => x.Value);
                case 3: return SubPackages.Max(x => x.Value);
                case 5: return SubPackages[0].Value > SubPackages[1].Value ? 1 : 0;
                case 6: return SubPackages[0].Value < SubPackages[1].Value ? 1 : 0;
                case 7: return SubPackages[0].Value == SubPackages[1].Value ? 1 : 0;
                default: return 0;
            }
        }
        

        public override void Parse()
        {
            var lengthTypeId = _useableBits.First();
            UsedBits += lengthTypeId;
            if (lengthTypeId == '1') IdOne();
            else IdZero();
            Value = GetValue();
        }

        private void IdZero()
        {
            var typeLengthBits = _useableBits.Skip(1).Take(15).ToActualString();
            var typeLengthValue = BinaryHelper.ToInt(typeLengthBits);
            var subset = _useableBits.Skip(1).Skip(15).Take(typeLengthValue).ToActualString();
            UsedBits += typeLengthBits;
            UsedBits += subset;
            while (!string.IsNullOrEmpty(subset) && subset.Any(x => x == '1'))
            {
                var package = Create(subset);
                package.Parse();
                SubPackages.Add(package);
                subset = subset.ReplaceFirst(package.UsedBits, "");
            }
        }

        private void IdOne()
        {
            var typeLengthBits = _useableBits.Skip(1).Take(11).ToActualString();
            var typeLengthValue = BinaryHelper.ToInt(typeLengthBits);
            var subset = _useableBits.Skip(1).Skip(11).ToActualString();
            UsedBits += typeLengthBits;
            for (var i = 0; i < typeLengthValue; i++)
            {
                var package = Create(subset);
                package.Parse();
                SubPackages.Add(package);
                UsedBits += package.UsedBits;
                subset = subset.ReplaceFirst(package.UsedBits, "");
            }
        }

        public override int VersionSum()
        {
            return SubPackages.Sum(x => x.VersionSum()) + Version;
        }
    }

    public static class BinaryHelper
    {
        public static readonly Dictionary<char, string> HexCharacterToBinary = new Dictionary<char, string>
        {
            { '0', "0000" },
            { '1', "0001" },
            { '2', "0010" },
            { '3', "0011" },
            { '4', "0100" },
            { '5', "0101" },
            { '6', "0110" },
            { '7', "0111" },
            { '8', "1000" },
            { '9', "1001" },
            { 'A', "1010" },
            { 'B', "1011" },
            { 'C', "1100" },
            { 'D', "1101" },
            { 'E', "1110" },
            { 'F', "1111" }
        };

        public static int ToInt(string value) => Convert.ToInt32(value, 2);
        public static long ToLong(string value) => Convert.ToInt64(value, 2);

        public static string HexToBinaryString(string value) =>
            value.Aggregate("", (s, c) => s += HexCharacterToBinary[c]);
    }

    public static class Extensions
    {
        public static string ToActualString(this IEnumerable<char> val) => new string(val.ToArray());

        public static string ReplaceFirst(this string text, string search, string replace)
        {
            var pos = text.IndexOf(search, StringComparison.Ordinal);
            if (pos < 0)
                return text;

            return text[..pos] + replace + text[(pos + search.Length)..];
        }
    }
}