public static class ExerciseShapes
{
    public static List<double> GetShapesAreas(List<Shape> shapes)
    {
        var result = new List<double>();

        foreach (var shape in shapes)
        {
            result.Add(shape.CalculateArea());
        }

        return result;
    }
}

public abstract class Shape
{
    public abstract double CalculateArea();
}

public class Square : Shape
{
    public double Side { get; }

    public Square(double side)
    {
        Side = side;
    }

    public override double CalculateArea() => Side * Side;
}


public class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    override public double CalculateArea() => Width * Height;
}

public class Circle : Shape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    override public double CalculateArea() => Math.PI * Math.Pow(Radius, 2);
}