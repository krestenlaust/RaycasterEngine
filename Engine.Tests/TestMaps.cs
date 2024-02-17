using Engine.MapRepresentation;
using Engine.MathTypes;

namespace Engine.Tests;

public static class TestMaps
{
    public static readonly IHitMap<Vector2D> Map5x5Bordered = new Map2D<int>(new int?[,]
        {
            { 1, 1,     1,      1, 1 },
            { 1, null, null, null, 1 },
            { 1, null, null, null, 1 },
            { 1, null, null, null, 1 },
            { 1, 1,     1,      1, 1 },
        });

    public static readonly IHitMap<Vector2D> Map5x5NoBorder = new Map2D<int>(new int?[,]
    {
            { null, null, null, null, null },
            { null, null, null, null, null },
            { null, null, null, null, null },
            { null, null, null, null, null },
            { null, null, null, null, null },
    });

    public static readonly IHitMap<Vector2D> Map4x4EveryOtherColumn = new Map2D<int>(new int?[,]
    {
        { null, 1, null, 1 },
        { null, 1, null, 1 },
        { null, 1, null, 1 },
        { null, 1, null, 1 },
    });
}
