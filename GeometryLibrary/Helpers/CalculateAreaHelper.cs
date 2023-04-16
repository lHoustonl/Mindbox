using Microsoft.CSharp.RuntimeBinder;

namespace Geometry.Library.Helpers;

public static class CalculateAreaHelper
{
    public static double CalculateArea(dynamic shape)
    {
        double area;

        try
        {
            area = shape.CalculateArea();
        }
        catch (RuntimeBinderException ex)
        {
            throw new ArgumentException(ex.Message);
        }

        return area;
    }
}