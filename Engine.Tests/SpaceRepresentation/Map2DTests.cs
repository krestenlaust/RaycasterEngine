namespace Engine.Tests.SpaceRepresentation;

[TestClass]
public class Map2DTests
{
    [DataRow(0, 0, false)]
    [DataRow(1, 1, true)]
    [DataRow(0, 1, false)]
    [DataRow(1, 0, true)]
    [DataRow(1, 0, true)]
    [DataTestMethod]
    public void TestCartesianPlaneIndexing4x4EveryOtherColumn(int x, int y, bool hit)
    {
        var space = TestSpaces.Space4x4EveryOtherColumn;

        bool actualHit = space.IsHit(new Engine.MathTypes.Vector2D(x, y));

        Assert.AreEqual(hit, actualHit);
    }
}
