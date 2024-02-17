using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Engine.Tests.MapRepresentation;

[TestClass]
public class Map2DTests
{
    [DataRow(0, 0, false)]
    [DataRow(1, 1, true)]
    [DataRow(0, 1, false)]
    [DataRow(1, 0, true)]
    [DataRow(1, 0, true)]
    [DataTestMethod]
    public void TestMap2DIndexing4x4EveryOtherColumn(int x, int y, bool hit)
    {
        var map = TestMaps.Map4x4EveryOtherColumn;

        bool actualHit = map.IsHit(new Engine.MathTypes.Vector2D(x, y));

        Assert.AreEqual(hit, actualHit);
    }
}
