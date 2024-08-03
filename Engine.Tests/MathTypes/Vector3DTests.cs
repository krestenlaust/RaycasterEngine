using Engine.MathTypes;

namespace Engine.Tests.MathTypes;

[TestClass]
public class Vector3DTests
{
    const float tolerance = 1e-6F;
    public static Vector3D ComponentsToVector3D(float[] components) => new(components[0], components[1], components[2]);

    [DataRow(new float[] { 1, 1, 1 }, new float[] { 1, 1, 1 })]
    [DataRow(new float[] { 0.9f, 0.9f, 0.9f }, new float[] { 0, 0, 0 })]
    [DataRow(new float[] { -0.9f, -0.9f, -0.9f }, new float[] { -1, -1, -1 })]
    [DataRow(new float[] { 1.1f, 1.1f, 1.1f }, new float[] { 1, 1, 1 })]
    [DataRow(new float[] { 0.5f, 1.7f, -2.2f }, new float[] { 0, 1, -3 })]
    [DataRow(new float[] { -1.5f, -1.2f, 3.3f }, new float[] { -2, -2, 3 })]
    [DataTestMethod]
    public void TestFloorMethod(float[] components, float[] expectedComponents)
    {
        Vector3D expected = ComponentsToVector3D(expectedComponents);
        Vector3D a = ComponentsToVector3D(components);

        Vector3D aFloor = a.Floor;

        Assert.AreEqual(expected, aFloor);
    }

    [DataRow(new float[] { 10, 10, 10 }, new float[] { 5, 5, 5 })]
    [DataRow(new float[] { -1, -1, -1 }, new float[] { -5, -5, -5 })]
    [DataRow(new float[] { 5, -5, 5 }, new float[] { -5, 5, -5 })]
    [DataRow(new float[] { 0, 0, 0 }, new float[] { 0, 0, 0 })]
    [DataRow(new float[] { 3.2f, -7.1f, 8.5f }, new float[] { -2.5f, 4.4f, -3.2f })]
    [DataTestMethod]
    public void TestPlusArithmetic(float[] componentsA, float[] componentsB)
    {
        Vector3D a = ComponentsToVector3D(componentsA);
        Vector3D b = ComponentsToVector3D(componentsB);

        Vector3D plus = a + b;

        Assert.AreEqual(componentsA[0] + componentsB[0], plus.X);
        Assert.AreEqual(componentsA[1] + componentsB[1], plus.Y);
        Assert.AreEqual(componentsA[2] + componentsB[2], plus.Z);
    }

    //[DataRow(0, 0, 0)] TODO: Decide what to do on zero vector normalization.
    [DataRow(new float[] { 3, 4, 5 }, new float[] { 0.424264f, 0.565685f, 0.707107f })]
    [DataRow(new float[] { -3, -4, -5 }, new float[] { -0.424264f, -0.565685f, -0.707107f })]
    [DataRow(new float[] { 1, 1, 1 }, new float[] { 0.577350f, 0.577350f, 0.577350f })] // Unit vector in positive octant
    [DataRow(new float[] { 0, 0, 1 }, new float[] { 0, 0, 1 })] // Already normalized vector along Z-axis
    [DataTestMethod]
    public void TestNormalization(float[] components, float[] expectedComponents)
    {
        Vector3D vec = ComponentsToVector3D(components);

        Vector3D norm = vec.Normalized;

        Assert.AreEqual(expectedComponents[0], norm.X, tolerance);
        Assert.AreEqual(expectedComponents[1], norm.Y, tolerance);
        Assert.AreEqual(expectedComponents[2], norm.Z, tolerance);
    }

    [DataRow(new float[] { 3, 4, 0 }, 5)] // Existing 2D case extended to 3D
    [DataRow(new float[] { 0, 0, 0 }, 0)] // Zero vector
    [DataRow(new float[] { -3, -4, 0 }, 5)] // Existing 2D case extended to 3D with negative components
    [DataRow(new float[] { 1, 2, 2 }, 3)] // New test case with integer components
    [DataRow(new float[] { 3, 4, 5 }, 7.071068f)] // 3D vector with positive components
    [DataTestMethod]
    public void TestLengthProperty(float[] components, float expectedLength)
    {
        Vector3D vec = ComponentsToVector3D(components);

        float actualLength = vec.Length;

        Assert.AreEqual(expectedLength, actualLength, tolerance);
    }

    [DataRow(new float[] { 1, 1, 1 }, new float[] { 1, 1, 1 }, true)] // Identical vectors
    [DataRow(new float[] { 0, 0, 0 }, new float[] { 0, 0, 0 }, true)] // Zero vectors
    [DataRow(new float[] { 0, 1, 0 }, new float[] { 1, 0, 0 }, false)] // Different vectors
    [DataRow(new float[] { 1.5f, 1.5f, 1.5f }, new float[] { 1, 1, 1 }, false)] // Vectors with different values
    [DataRow(new float[] { 1.5f, 1.5f, 1.5f }, new float[] { 1.5f, 1.5f, 1.5f }, true)] // Identical vectors with float values
    [DataRow(new float[] { 1, 2, 3 }, new float[] { 3, 2, 1 }, false)] // Different order of components
    [DataTestMethod]
    public void TestComparisonOperator(float[] componentsA, float[] componentsB, bool equals)
    {
        Vector3D a = ComponentsToVector3D(componentsA);
        Vector3D b = ComponentsToVector3D(componentsB);

        Assert.AreEqual(a == b, equals);
        Assert.AreEqual(a != b, !equals);
        Assert.AreEqual(b == a, equals);
        Assert.AreEqual(b != a, !equals);
    }

    [DataRow(new float[] { 0, 0, 0 }, "(0, 0, 0)")]
    [DataRow(new float[] { -0, -0, -0 }, "(0, 0, 0)")]
    [DataRow(new float[] { 100, 0, 0 }, "(100, 0, 0)")]
    [DataRow(new float[] { 0, 100, 0 }, "(0, 100, 0)")]
    [DataRow(new float[] { -10, 10, 0 }, "(-10, 10, 0)")]
    [DataRow(new float[] { 10, -10, 0 }, "(10, -10, 0)")]
    [DataRow(new float[] { -10, -10, 10 }, "(-10, -10, 10)")]
    [DataRow(new float[] { -5.1f, 5.5f, 2.2f }, "(-5.1, 5.5, 2.2)")]
    [DataRow(new float[] { 0, 1.5f, -3.3f }, "(0, 1.5, -3.3)")]
    [DataTestMethod]
    public void TestToStringImpl(float[] components, string expectedResult)
    {
        Vector3D a = ComponentsToVector3D(components);

        string? converted = a.ToString();

        Assert.IsNotNull(converted);
        Assert.AreEqual(expectedResult, converted);
    }
}
