using Engine.MathTypes;

namespace Engine.Tests.MathTypes;

[TestClass]
public class Vector2EpsilonComparerTests
{
    IEqualityComparer<Vector2D> epsilonComparer;

    [TestInitialize]
    public void InitializeComparer()
    {
        epsilonComparer = new Vector2EpsilonComparer(0.1f);
    }

    [DataRow(1, 0, 1.09f, 0, true)]
    [DataRow(1, 0, 1.2f, 0, false)]
    [DataTestMethod]
    public void TestEquality(float xA, float yA, float xB, float yB, bool equals)
    {
        Vector2D a = new(xA, yA);
        Vector2D b = new(xB, yB);

        bool actualEquals = epsilonComparer.Equals(a, b);

        Assert.AreEqual(equals, actualEquals);
    }
}
