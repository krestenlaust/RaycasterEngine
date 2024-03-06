namespace Engine.MathTypes;

/// <summary>
/// Contains miscellaneous mathematical functions.
/// </summary>
public static class ExtendedMath
{
    /// <summary>
    /// True modulo, with proper handling of negative operands.
    /// </summary>
    /// <param name="x">The quotient.</param>
    /// <param name="m">The dividend.</param>
    /// <returns>The remainder.</returns>
    public static float Modulo(float x, float m)
    {
        return ((x % m) + m) % m;
    }
}
