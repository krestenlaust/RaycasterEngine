using Engine.MathTypes;

namespace Engine.Tests.MathTypes;

[TestClass]
public class Vector2DTests
{
    public static Vector2D ComponentsToVector2D(float[] components) => new(components[0], components[1]);

    [DataRow(new float[] { 1, 1 }, new float[] { 1, 1 })]
    [DataRow(new float[] { 0.9f, 0.9f }, new float[] { 0, 0 })]
    [DataRow(new float[] { -0.9f, -0.9f }, new float[] { -1, -1 })]
    [DataTestMethod]
    public void TestFloorMethod(float[] components, float[] expectedComponents)
    {
        Vector2D expected = ComponentsToVector2D(expectedComponents);
        Vector2D a = ComponentsToVector2D(components);

        Vector2D aFloor = a.Floor;

        Assert.AreEqual(expected, aFloor);
    }

    [DataRow(new float[] { 10, 10 }, new float[] { 5, 5 })]
    [DataRow(new float[] { -1, -1 }, new float[] { -5, -5 })]
    [DataRow(new float[] { 5, -5 }, new float[] { -5, 5 })]
    [DataTestMethod]
    public void TestPlusArithmetic(float[] componentsA, float[] componentsB)
    {
        Vector2D a = ComponentsToVector2D(componentsA);
        Vector2D b = ComponentsToVector2D(componentsB);

        Vector2D plus = a + b;

        Assert.AreEqual(componentsA[0] + componentsB[0], plus.X);
        Assert.AreEqual(componentsA[1] + componentsB[1], plus.Y);
    }

    [DataRow(new float[] { 3, 4 }, new float[] { 0.6f, 0.8f })]
    //[DataRow(0, 0, 0)] TODO: Decide what to do on zero vector normalization.
    [DataRow(new float[] { -3, -4 }, new float[] { -0.6f, -0.8f })]
    [DataTestMethod]
    public void TestNormalization(float[] components, float[] expectedComponents)
    {
        Vector2D expectedNorm = ComponentsToVector2D(expectedComponents);
        Vector2D vec = ComponentsToVector2D(components);

        Vector2D norm = vec.Normalized;

        Assert.AreEqual(expectedNorm, norm);
    }

    [DataRow(new float[] { 3, 4 }, 5)]
    [DataRow(new float[] { 0, 0 }, 0)]
    [DataRow(new float[] { -3, -4 }, 5)]
    [DataTestMethod]
    public void TestLengthProperty(float[] components, float expectedLength)
    {
        Vector2D vec = ComponentsToVector2D(components);

        float actualLength = vec.Length;

        Assert.AreEqual(expectedLength, actualLength);
    }

    [DataRow(new float[] { 1, 1 }, new float[] { 1, 1 }, true)]
    [DataRow(new float[] { 0, 0 }, new float[] { 0, 0 }, true)]
    [DataRow(new float[] { 0, 1 }, new float[] { 1, 0 }, false)]
    [DataRow(new float[] { 1.5f, 1.5f }, new float[] { 1, 1 }, false)]
    [DataRow(new float[] { 1.5f, 1.5f }, new float[] { 1.5f, 1.5f }, true)]
    [DataTestMethod]
    public void TestComparisonOperator(float[] componentsA, float[] componentsB, bool equals)
    {
        Vector2D a = ComponentsToVector2D(componentsA);
        Vector2D b = ComponentsToVector2D(componentsB);

        Assert.AreEqual(a == b, equals);
        Assert.AreEqual(a != b, !equals);
        Assert.AreEqual(b == a, equals);
        Assert.AreEqual(b != a, !equals);
    }

    [DataRow(new float[] { 0, 0 }, "(0, 0)")]
    [DataRow(new float[] { -0, -0 }, "(0, 0)")]
    [DataRow(new float[] { 100, 0 }, "(100, 0)")]
    [DataRow(new float[] { 0, 100 }, "(0, 100)")]
    [DataRow(new float[] { -10, 10 }, "(-10, 10)")]
    [DataRow(new float[] { 10, -10 }, "(10, -10)")]
    [DataRow(new float[] { -10, -10 }, "(-10, -10)")]
    [DataRow(new float[] { -5.1f, 5.5f }, "(-5.1, 5.5)")]
    [DataRow(new float[] { 0, 1.5f }, "(0, 1.5)")]
    [DataTestMethod]
    public void TestToStringImpl(float[] components, string expectedResult)
    {
        Vector2D a = ComponentsToVector2D(components);

        string? converted = a.ToString();

        Assert.IsNotNull(converted);
        Assert.AreEqual(expectedResult, converted);
    }
}
