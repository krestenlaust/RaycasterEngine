using Engine;
using Engine.CameraPattern;
using Engine.CastMethod;
using Engine.MathTypes;

namespace EngineImpl;

public class Game
{
    Camera<DiscreteRaycast,
           PerspectiveLineCameraPattern<
               DiscreteRaycast,
               Vector2D,
               float>,
           Vector2D,
           Orientation2D,
           float,
           char> player;

    public Game()
    {
        player =
            new Camera<
                DiscreteRaycast,
                PerspectiveLineCameraPattern<
                    DiscreteRaycast,
                    Vector2D,
                    float>,
                Vector2D,
                Orientation2D,
                float,
                char>
                (new PerspectiveLineCameraPattern<
                    DiscreteRaycast,
                    Vector2D,
                    float>
                    (Orientation2D.FromDegrees(90), 50), new DiscreteRaycast(0.05f), 10);
    }

    public void Tick()
    {
        // Read input to reorient camera.
    }
}
