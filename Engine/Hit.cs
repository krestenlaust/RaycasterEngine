namespace Engine;

public record Hit<TPosition, TLength, TRenderingUnit>(TPosition Origin, TPosition Point, TLength Distance, TRenderingUnit renderingUnit);
