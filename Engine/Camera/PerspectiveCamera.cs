namespace Engine.Camera;

public class PerspectiveCamera<TCastMethod, TPosition, TOrientation, TLength, TRenderingUnit>
    where TCastMethod : ICast<TPosition, TOrientation, TLength, TRenderingUnit>
    where TPosition : struct
    where TOrientation : struct
    where TLength : struct
{
    public TOrientation FieldOfView { get; set; }
    public TPosition Position { get; set; }
    public TOrientation Orientation { get; set; }
}
