﻿using Engine.Tests.CastMethod;

namespace Engine.Tests;

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
}
