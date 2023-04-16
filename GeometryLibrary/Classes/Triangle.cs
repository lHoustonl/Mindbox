using GeometryLibrary.Constants;
using GeometryLibrary.Helpers;

namespace GeometryLibrary.Classes;

public sealed class Triangle
{
    private readonly double _accuracy = Accuracy.CalculationAccuracy;

    private readonly double _sideA;
    private readonly double _sideB;
    private readonly double _sideC;

    private readonly bool _isRightTriangle;

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

        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;

        _isRightTriangle = IsRightAngled();
    }

    public bool IsRightTriangle => _isRightTriangle;

    public double CalculateArea()
    {
        var halfP = (_sideA + _sideB + _sideC) / 2d;

        var area = Math.Sqrt(halfP * (halfP - _sideA) * (halfP - _sideB) * (halfP - _sideC));

        return area;
    }

    private bool IsRightAngled()
    {
        double maxSide = _sideA, b = _sideB, c = _sideC;
        if (b - maxSide > _accuracy)
            SwapHelper.Swap(ref maxSide, ref b);

        if (c - maxSide > _accuracy)
            SwapHelper.Swap(ref maxSide, ref c);

        return Math.Abs(Math.Pow(maxSide, 2d) - Math.Pow(b, 2d) - Math.Pow(c, 2d)) < Accuracy.CalculationAccuracy;
    }
}