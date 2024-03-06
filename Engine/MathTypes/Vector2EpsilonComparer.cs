using System.Diagnostics.CodeAnalysis;

namespace Engine.MathTypes;

/// <summary>
/// <see cref="IEqualityComparer{T}"/> to compare <see cref="Vector2D"/>.
/// </summary>
/// <param name="epsilonValue">The value to compare.</param>
public class Vector2EpsilonComparer(float epsilonValue) : IEqualityComparer<Vector2D>
{
    /// <inheritdoc/>
    public bool Equals(Vector2D a, Vector2D b) =>
        Math.Abs(a.X - b.X) <= epsilonValue &&
        Math.Abs(a.Y - b.Y) <= epsilonValue;

    /// <inheritdoc/>
    public int GetHashCode([DisallowNull] Vector2D obj) => obj.GetHashCode();
}
