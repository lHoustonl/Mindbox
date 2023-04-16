using Geometry.Library.Classes;
using Geometry.Library.Constants;
using Geometry.Library.Helpers;

namespace GeometryLibrary.Tests.Unit;

public sealed class CircleTest
{
    private readonly double accuracy = Accuracy.CalculationAccuracy;

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CreateCircle_GivenZeroRadius_ReturnsArgumentException()
    {
        Assert.Catch<ArgumentException>(() => new Circle(0d));
    }


    [Test]
    public void CreateCircle_GivenNegativeRadius_ReturnsArgumentException()
    {
        Assert.Catch<ArgumentException>(() => new Circle(-1d));
    }


    [Test]
    public void CreateCircle_GivenLessThanMinRadius_ReturnsArgumentException()
    {
        Assert.Catch<ArgumentException>(() => new Circle(Circle.MinRadius - 1e7));
    }


    [Test]
    public void CreateCircle_Given10Radius_ReturnsTrue()
    {
        #region Given

        var radius = 10;
        var circle = new Circle(radius);
        var expectedValue = Math.PI * Math.Pow(radius, 2d);

        #endregion

        #region When

        var area = CalculateAreaHelper.CalculateArea(circle);

        #endregion

        #region Should

        Assert.Less(Math.Abs(area - expectedValue), accuracy);

        #endregion
    }
}