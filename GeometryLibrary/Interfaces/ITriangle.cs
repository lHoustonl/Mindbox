namespace Geometry.Library.Interfaces;

public interface ITriangle : IShape
{
    double SideA { get; }
    double SideB { get; }
    double SideC { get; }

    bool IsRightTriangle();
}