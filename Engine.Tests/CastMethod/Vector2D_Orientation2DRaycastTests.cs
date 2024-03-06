using Engine.MathTypes;

namespace Engine.Tests.CastMethod;

/// <summary>
/// Tests for testing implementations of ICastMethod,
/// which use <see cref="Vector2D"/> for TPosition.
/// (And use <see cref="Orientation2D"/> for TAngle)
/// </summary>
public abstract class Vector2D_Orientation2DRaycastTests(ICastMethod<Vector2D, Orientation2D, float> cast)
{
    readonly ICastMethod<Vector2D, Orientation2D, float> cast = cast;

    [DataRow(0, 0, 0, 0)]
    [DataRow(1, 2, 1, 4)]
    [DataRow(2.5f, 2.5f, 2.5f, 4)]
    [DataRow(1.5f, 2.5f, 1.5f, 4)]
    [DataTestMethod]
    public void TestStraightRaycastUp5x5Map(float xOrigin, float yOrigin, float xPoint, float yPoint)
    {
        Vector2D expectedPoint = new(xPoint, yPoint);
        Vector2D origin = new(xOrigin, yOrigin);

        bool castHit = cast.Cast(TestSpaces.Space5x5Bordered, origin, Orientation2D.UpRotation, 5, out Hit<Vector2D, float>? hit);

        Assert.IsTrue(castHit);
        Assert.IsNotNull(hit);

        Assert.AreEqual(expectedPoint, hit.Value.Point, new Vector2EpsilonComparer(0.1f));
    }
}
