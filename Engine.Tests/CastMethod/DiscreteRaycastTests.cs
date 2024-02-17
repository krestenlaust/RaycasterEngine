using Engine.CastMethod;

namespace Engine.Tests.CastMethod;

[TestClass]
public class DiscreteRaycastTests : Vector2D_Orientation2DRaycastTests
{
    public DiscreteRaycastTests() : base(new DiscreteRaycast(0.05f))
    {
    }
}
