using NUnit.Framework;

namespace D15_Chiton.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var data = Parser.Parse("./testdata.txt");
        var cave = new Cave(data);
        Assert.AreEqual(40, cave.Travel());
    }
    
    [Test]
    public void Test2()
    {
        var data = Parser.ParseAndDuplicate("./testdata.txt");
        var cave = new Cave(data);
        Assert.AreEqual(315, cave.Travel());
    }
}