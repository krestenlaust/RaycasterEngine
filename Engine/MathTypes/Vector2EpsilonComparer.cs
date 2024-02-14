using System.Diagnostics.CodeAnalysis;

namespace Engine.MathTypes;

public class Vector2EpsilonComparer(float epsilonValue) : IEqualityComparer<Vector2D>
{
    public bool Equals(Vector2D a, Vector2D b) =>
        Math.Abs(a.X - b.X) <= epsilonValue &&
        Math.Abs(a.Y - b.Y) <= epsilonValue;

    public int GetHashCode([DisallowNull] Vector2D obj) => obj.GetHashCode();
}
