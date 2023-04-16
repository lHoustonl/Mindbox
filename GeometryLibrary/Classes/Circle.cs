using GeometryLibrary.Constants;
using GeometryLibrary.Interfaces;

namespace GeometryLibrary.Classes;

public sealed class Circle : IShape
{
    public const double MinRadius = 1e-6;

    private readonly double _radius;

    public Circle (double radius)
    {
        if (radius - MinRadius < Accuracy.CalculationAccuracy)
            throw new ArgumentException("Invalid argument value");

        _radius = radius;
    }

    public double CalculateArea() => Math.PI * Math.Pow(_radius, 2d);
}
