var point1 = new Point(1, 3);
var point2 = new Point(4, 8);

var addedPoint = point1 + point2;

Console.WriteLine(addedPoint);
Console.WriteLine($"point 1 == point 2 : {(point1 == point2)}");

var pointTuple = Tuple.Create(10, 20);
Point point3 = (Point)pointTuple;

var point4 = new Point(1, 3);

var valueTuple1 = new ValueTuple<int, string, bool>(1, "dddd", false);
var valueTuple2 = (Number: 5, Text: "aaa", Bool: false);

Console.WriteLine($"Point1 Hash Code: {point1.GetHashCode()}");
Console.WriteLine($"Point2 Hash Code: {point2.GetHashCode()}");
Console.WriteLine($"Point3 Hash Code: {point3.GetHashCode()}");
Console.WriteLine($"Point4 Hash Code: {point4.GetHashCode()}");

Console.ReadKey();

public readonly struct Point : IEquatable<Point>
{
    public int X { get; init; }
    public int Y { get; init; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool Equals(Point other)
    {
        return other.X == X && other.Y == Y;
    }

    override public bool Equals(object? obj)
    {
        return obj is Point point && Equals(point);
    }

    public override string ToString() => $"X is: {X}, Y is: {Y}";

    public static Point operator +(Point a, Point b) => new(a.X + b.X, a.Y + b.Y);
    public static bool operator ==(Point a, Point b) => a.Equals(b);
    public static bool operator !=(Point a, Point b) => !a.Equals(b);
    public static explicit operator Point(Tuple<int, int> tuple) => new(tuple.Item1, tuple.Item2);
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}