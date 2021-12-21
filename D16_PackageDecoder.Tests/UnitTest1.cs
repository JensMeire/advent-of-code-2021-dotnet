using NUnit.Framework;

namespace D16_PackageDecoder.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var res = BinaryHelper.HexToBinaryString("8A004A801A8002F478");
        var p = new OperationalPackage(res);
        p.Parse();
        Assert.AreEqual(16, p.VersionSum());
    }
    
    [Test]
    public void Test2()
    {
        var res = BinaryHelper.HexToBinaryString("620080001611562C8802118E34");
        var p = new OperationalPackage(res);
        p.Parse();
        Assert.AreEqual(12, p.VersionSum());
    }
    
    [Test]
    public void Test3()
    {
        var res = BinaryHelper.HexToBinaryString("C0015000016115A2E0802F182340");
        var p = new OperationalPackage(res);
        p.Parse();
        Assert.AreEqual(23, p.VersionSum());
    }
    
    [Test]
    public void Test4()
    {
        var res = BinaryHelper.HexToBinaryString("A0016C880162017C3686B18A3D4780");
        var p = new OperationalPackage(res);
        p.Parse();
        Assert.AreEqual(31, p.VersionSum());
    }
    
    [Test]
    public void Test5()
    {
        var res = BinaryHelper.HexToBinaryString("C200B40A82");
        var p = new OperationalPackage(res);
        p.Parse();
        Assert.AreEqual(3, p.Value);
    }
    
    [Test]
    public void Test6()
    {
        var res = BinaryHelper.HexToBinaryString("04005AC33890");
        var p = new OperationalPackage(res);
        p.Parse();
        Assert.AreEqual(54, p.Value);
    }
    
    [Test]
    public void Test7()
    {
        var res = BinaryHelper.HexToBinaryString("880086C3E88112");
        var p = new OperationalPackage(res);
        p.Parse();
        Assert.AreEqual(7, p.Value);
    }
    
    [Test]
    public void Test8()
    {
        var res = BinaryHelper.HexToBinaryString("CE00C43D881120");
        var p = new OperationalPackage(res);
        p.Parse();
        Assert.AreEqual(9, p.Value);
    }
        
    [Test]
    public void Test9()
    {
        var res = BinaryHelper.HexToBinaryString("D8005AC2A8F0");
        var p = new OperationalPackage(res);
        p.Parse();
        Assert.AreEqual(1, p.Value);
    }
    
    [Test]
    public void Test10()
    {
        var res = BinaryHelper.HexToBinaryString("F600BC2D8F");
        var p = new OperationalPackage(res);
        p.Parse();
        Assert.AreEqual(0, p.Value);
    }
    
    [Test]
    public void Test11()
    {
        var res = BinaryHelper.HexToBinaryString("9C005AC2F8F0");
        var p = new OperationalPackage(res);
        p.Parse();
        Assert.AreEqual(0, p.Value);
    }
    
    [Test]
    public void Test12()
    {
        var res = BinaryHelper.HexToBinaryString("9C0141080250320F1802104A08");
        var p = new OperationalPackage(res);
        p.Parse();
        Assert.AreEqual(1, p.Value);
    }
}

//100010100000000001001010100000000001101010000000000000101111010001111000