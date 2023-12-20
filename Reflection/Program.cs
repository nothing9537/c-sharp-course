var converter = new ObjectToTextConverter();
var convertedValue = converter.Convert(new House("123 Maple Road", 178.9, 5));

Console.WriteLine(convertedValue);

Console.ReadKey();
public class ObjectToTextConverter
{
    public string Convert(object obj)
    {
        Type type = obj.GetType();
        var properties = type.GetProperties().Where(p => p.Name != "EqualityContract");

        return string.Join(", ", properties.Select(property => $"{property.Name} is {property.GetValue(obj)}"));
    }
}

public record Pet(string Name, PetType PetType, float Weight);
public record House(string Address, double Area, int Floors);

public enum PetType
{
    Cat,
    Dog,
    Fish
}