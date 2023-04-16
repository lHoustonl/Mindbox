using Geometry.Library.Constants;
using Geometry.Library.Helpers;

namespace Geometry.Library.Classes;

public sealed class Triangle
{
    private readonly double _accuracy = Accuracy.CalculationAccuracy;

    private readonly bool _isRightTriangle;

    public readonly double SideA;
    public readonly double SideB;
    public readonly double SideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA < _accuracy)
            throw new ArgumentException("Invalid value", nameof(sideA));

        if (sideB < _accuracy)
            throw new ArgumentException("Invalid value", nameof(sideB));

        if (sideC < _accuracy)
            throw new ArgumentException("Invalid value", nameof(sideC));

        var maxSide = Math.Max(sideA, Math.Max(sideB, sideC));
        var perimeter = sideA + sideB + sideC;
        if ((perimeter - maxSide) - maxSide < _accuracy)
            throw new ArgumentException("The sum of two sides must be greater than the third side");

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;

        _isRightTriangle = IsRightAngled();
    }

    public bool IsRightTriangle => _isRightTriangle;

    public double CalculateArea()
    {
        var halfP = (SideA + SideB + SideC) / 2d;

        var area = Math.Sqrt(halfP * (halfP - SideA) * (halfP - SideB) * (halfP - SideC));

        return area;
    }

    private bool IsRightAngled()
    {
        double maxSide = SideA, b = SideB, c = SideC;
        if (b - maxSide > _accuracy)
            SwapHelper.Swap(ref maxSide, ref b);

        if (c - maxSide > _accuracy)
            SwapHelper.Swap(ref maxSide, ref c);

        return Math.Abs(Math.Pow(maxSide, 2d) - Math.Pow(b, 2d) - Math.Pow(c, 2d)) < Accuracy.CalculationAccuracy;
    }
}