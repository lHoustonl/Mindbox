using Geometry.Library.Classes;
using Geometry.Library.Constants;
using Geometry.Library.Helpers;

namespace Geometry.Library.Tests.Unit;

public sealed class TriangleTest
{
    private readonly double accuracy = Accuracy.CalculationAccuracy;

    [TestCase(0, 0, 0)]
    [TestCase(1, 1, -1)]
    [TestCase(1, -1, 1)]
    [TestCase(-1, 1, 1)]
    public void CreateTriangle_GivenInvalidSides_ReturnsArgumentException(double a, double b, double c)
    {
        Assert.Catch<ArgumentException>(() => new Triangle(a, b, c));
    }

    [Test]
    public void CreateTriangle_GivenValidSides_ReturnsTrue()
    {
        #region Given

        double a = 5d, b = 4d, c = 3d;

        #endregion

        #region When

        var triangle = new Triangle(a, b, c);

        #endregion

        #region Should

        Assert.NotNull(triangle);
        Assert.Less(Math.Abs(triangle.SideA - a), accuracy);
        Assert.Less(Math.Abs(triangle.SideB - b), accuracy);
        Assert.Less(Math.Abs(triangle.SideC - c), accuracy);

        #endregion
    }

    [Test]
    public void CalculateArea_GivenValidSides_ReturnsTrue()
    {
        #region Given

        double a = 5d, b = 4d, c = 3d;
        double result = 6d;
        var triangle = new Triangle(a, b, c);

        #endregion

        #region When

        var area = CalculateAreaHelper.CalculateArea(triangle);

        #endregion

        #region Should

        Assert.NotNull(area);
        Assert.Less(Math.Abs(area - result), accuracy);

        #endregion
    }

    [Test]
    public void CalculateArea_GivenNonExistedTriangleSides_ReturnsArgumentException()
    {
        Assert.Catch<ArgumentException>(() => new Triangle(1, 1, 4));
    }

    [TestCase(3, 4, 3, ExpectedResult = false)]
    [TestCase(3, 4, 5 + 1e-7, ExpectedResult = false)]
    [TestCase(3, 4, 5, ExpectedResult = true)]
    [TestCase(3, 4, 5.000000001, ExpectedResult = true)]
    public bool IsRightTriangle_GivenTriangleSides_ReturnsTrue(double a, double b, double c)
    {
        #region Given

        var triangle = new Triangle(a, b, c);

        #endregion

        #region When

        var isRight = triangle.IsRightTriangle;

        #endregion

        #region Should

        return isRight;

        #endregion
    }
}