[AttributeUsage(AttributeTargets.Property)]
public class MustBeLargerThanAttribute : Attribute
{
    public int Min { get; }

    public MustBeLargerThanAttribute(int min)
    {
        Min = min;
    }
}