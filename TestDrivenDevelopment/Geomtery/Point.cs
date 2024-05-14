using static System.Math;

namespace Geomtery;

public class Point : IMoveable
{
    public double _x;

    public double _y;

    public double X => _x;

    public double Y => _y;

    public Point() { }

    public Point(double a) : this(a, a) { }

    public Point(double x, double y) => (_x, _y) = (x, y);

    public void Move(double x, double y)
    {
        _x += x; 
        _y += y;
    }

    public object Distance() => Sqrt(X * X + Y * Y);
}
