using Engine.CastMethod;

namespace Engine.Tests.CastMethod;

[TestClass]
public class DiscreteRaycastTests : Vector2D_AngleRaycastTests
{
    public DiscreteRaycastTests() : base(new DiscreteRaycast(0.05f))
    {
    }
}
