namespace Engine.Camera;

public class PerspectiveCamera<TCastMethod, TPosition, TOrientation, TLength>
    where TCastMethod : ICast<TPosition, TOrientation, TLength>
    where TPosition : struct
    where TOrientation : struct
    where TLength : struct
{
    public TPosition Position { get; set; }
    public TOrientation Orientation { get; set; }
}
