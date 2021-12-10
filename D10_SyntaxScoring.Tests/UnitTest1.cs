using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace D10_SyntaxScoring.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var data =  File.ReadLines("./testdata.txt").Select(x => new SyntaxLine(x)).ToList();
            var corrupted = data.Where(x => x.IsCorrupted).ToList();
            Assert.AreEqual(5, corrupted.Count);
            Assert.AreEqual(26397, corrupted.Sum(x =>
            {
                var chars = x.GetCorruptedChars;
                switch (chars.actual)
                {
                    case ')': return 3;
                    case ']': return 57;
                    case '}': return 1197;
                    case '>': return 25137;
                    default: throw new NotImplementedException();
                }
            }));
        }
        
        [Test]
        public void Test2()
        {
            var data =  File.ReadLines("./testdata.txt").Select(x => new SyntaxLine(x)).ToList();
            var notCorrupted = data.Where(x => !x.IsCorrupted).OrderBy(x => x.CompletionScore).ToList();
            Assert.AreEqual(288957, notCorrupted[(notCorrupted.Count / 2) ].CompletionScore);
        }
    }
}