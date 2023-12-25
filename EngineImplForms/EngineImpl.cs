using Engine;
using Engine.Camera;
using Engine.CastMethod;

namespace EngineImplForms;

public class EngineImpl
{
    public void Setup()
    {
        var cam = new PerspectiveCamera1D<DiscreteRaycast<Color>, Vector2D, float, Color>(Orientation2D.FullRotation / 3, 10);
    }

    public void Render()
    {

    }
}
