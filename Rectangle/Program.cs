var rect = new Rectangle(0, 0);

Console.WriteLine($"Width is: {rect.Width}");
Console.WriteLine($"Height is: {rect.Height}");
Console.WriteLine($"Area is: {rect.CalcArea()}");
Console.WriteLine($"Circumference is: {rect.CalcCircumference()}");

Console.ReadKey();

class Rectangle
{
    private readonly int defaultValueIfNonPositive = 1;
    public int Width { get; init; }
    public int Height { get; init; }
    public Rectangle(int width, int height)
    {
        Width = GetInitialLengthOrDefault(width, nameof(Width));
        Height = GetInitialLengthOrDefault(height, nameof(Height));
    }

    private int GetInitialLengthOrDefault(int value, string param)
    {
        if (value > 0)
        {
            return value;
        }
        else
        {
            Console.WriteLine($"{param} must be positive.");
            return defaultValueIfNonPositive;
        }
    }

    public int CalcArea() => Width * Height;
    public int CalcCircumference() => (2 * Width + 2 * Height);
}