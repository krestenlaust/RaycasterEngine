using Engine.SpaceRepresentation;
using Engine.MathTypes;

namespace Engine.Tests;

public static class TestSpaces
{
    public static readonly IHitSpace<Vector2D> Space5x5Bordered = new CartesianPlane<int>(new int?[,]
        {
            { 1, 1,     1,      1, 1 },
            { 1, null, null, null, 1 },
            { 1, null, null, null, 1 },
            { 1, null, null, null, 1 },
            { 1, 1,     1,      1, 1 },
        });

    public static readonly IHitSpace<Vector2D> Space5x5NoBorder = new CartesianPlane<int>(new int?[,]
    {
            { null, null, null, null, null },
            { null, null, null, null, null },
            { null, null, null, null, null },
            { null, null, null, null, null },
            { null, null, null, null, null },
    });

    public static readonly IHitSpace<Vector2D> Space4x4EveryOtherColumn = new CartesianPlane<int>(new int?[,]
    {
        { null, null, null, null },
        { 1, 1, 1, 1 },
        { null, null, null, null },
        { 1, 1, 1, 1 },
    });
}
