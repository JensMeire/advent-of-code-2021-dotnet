using NUnit.Framework;

namespace D3_BinaryDiagnostic.Tests
{
    public class Tests
    {
        private IReportGenerator _testReportGenerator;
        [SetUp]
        public void Setup()
        {
            _testReportGenerator = new TestReportGenerator();
        }

        [Test]
        public void Test1()
        {
            var submarine = new Submarine(_testReportGenerator);
            var powerUsage = submarine.GetPowerUsage();
            Assert.AreEqual(198, powerUsage);
        }
        
        [Test]
        public void Test2()
        {
            var submarine = new Submarine(_testReportGenerator);
            var oxygen = submarine.GetOxygenGeneratorRating();
            var co2 = submarine.GetCo2ScrubberRating();
            Assert.AreEqual(230, oxygen * co2);
        }
    }
}