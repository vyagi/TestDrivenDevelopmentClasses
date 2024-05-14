using static System.Math;

namespace Geomtery;

public class Segment
{
    public Point Start { get; private set; }
    public Point End { get; private set; }
    public double Length => 
        Sqrt(Pow(Start.X - End.X, 2) + Pow(Start.Y - End.Y, 2));

    public Segment(Point start, Point end) => (Start, End) = (start, end);
}
