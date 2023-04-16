namespace Geometry.Library.Helpers;

public static class SwapHelper
{
    public static void Swap<T>(ref T a, ref T b)
    {
        (b, a) = (a, b);
    }
}