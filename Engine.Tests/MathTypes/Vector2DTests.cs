using Engine.MathTypes;

namespace Engine.Tests.MathTypes;

[TestClass]
public class Vector2DTests
{
    [DataRow(1, 1, 1, 1)]
    [DataRow(0.9f, 0.9f, 0, 0)]
    [DataRow(-0.9f, -0.9f, -1, -1)]
    [DataTestMethod]
    public void TestFloorMethod(float x, float y, float expectedX, float expectedY)
    {
        Vector2D expected = new(expectedX, expectedY);
        Vector2D a = new(x, y);

        Vector2D aFloor = a.Floor;

        Assert.AreEqual(expected, aFloor);
    }

    [DataRow(10, 10, 5, 5)]
    [DataRow(-1, -1, -5, -5)]
    [DataRow(5, -5, -5, 5)]
    [DataTestMethod]
    public void TestPlusArithmetic(float xA, float yA, float xB, float yB)
    {
        Vector2D a = new(xA, yA);
        Vector2D b = new(xB, yB);

        Vector2D plus = a + b;

        Assert.AreEqual(xA + xB, plus.X);
        Assert.AreEqual(yA + yB, plus.Y);
    }

    [DataRow(3, 4, 0.6f, 0.8f)]
    //[DataRow(0, 0, 0)] TODO: Decide what to do on zero vector normalization.
    [DataRow(-3, -4, -0.6f, -0.8f)]
    [DataTestMethod]
    public void TestNormalization(float x, float y, float normX, float normY)
    {
        Vector2D expectedNorm = new(normX, normY);
        Vector2D vec = new(x, y);

        Vector2D norm = vec.Normalized;

        Assert.AreEqual(expectedNorm, norm);
    }

    [DataRow(3, 4, 5)]
    [DataRow(0, 0, 0)]
    [DataRow(-3, -4, 5)]
    [DataTestMethod]
    public void TestLengthProperty(float x, float y, float expectedLength)
    {
        Vector2D vec = new(x, y);

        float actualLength = vec.Length;

        Assert.AreEqual(expectedLength, actualLength);
    }

    [DataRow(1, 1, 1, 1, true)]
    [DataRow(0, 0, 0, 0, true)]
    [DataRow(0, 1, 1, 0, false)]
    [DataRow(1.5f, 1.5f, 1, 1, false)]
    [DataRow(1.5f, 1.5f, 1.5f, 1.5f, true)]
    [DataTestMethod]
    public void TestComparisonOperator(float xA, float yA, float xB, float yB, bool equals)
    {
        Vector2D a = new(xA, yA);
        Vector2D b = new(xB, yB);

        Assert.AreEqual(a == b, equals);
        Assert.AreEqual(a != b, !equals);
        Assert.AreEqual(b == a, equals);
        Assert.AreEqual(b != a, !equals);
    }

    [DataRow(0, 0, "(0, 0)")]
    [DataRow(-0, -0, "(0, 0)")]
    [DataRow(100, 0, "(100, 0)")]
    [DataRow(0, 100, "(0, 100)")]
    [DataRow(-10, 10, "(-10, 10)")]
    [DataRow(10, -10, "(10, -10)")]
    [DataRow(-10, -10, "(-10, -10)")]
    [DataRow(-5.1f, 5.5f, "(-5.1, 5.5)")]
    [DataRow(0, 1.5f, "(0, 1.5)")]
    [DataTestMethod]
    public void TestToStringImpl(float x, float y, string expectedResult)
    {
        Vector2D a = new(x, y);

        string? converted = a.ToString();

        Assert.IsNotNull(converted);
        Assert.AreEqual(expectedResult, converted);
    }
}
