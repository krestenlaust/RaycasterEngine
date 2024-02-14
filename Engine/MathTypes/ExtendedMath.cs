namespace Engine.MathTypes;

public static class ExtendedMath
{
    /// <summary>
    /// True modulo, with proper handling of negative operands.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="m"></param>
    /// <returns></returns>
    public static float Modulo(float x, float m)
    {
        return (x % m + m) % m;
    }
}
