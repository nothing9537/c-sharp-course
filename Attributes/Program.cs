var validPerson = new Person("John", 1985);
var invalidDog = new Dog("D");
var validator = new Validator();

Console.WriteLine(validator.Validate(validPerson) ? "Person valid" : "Person invalid");
Console.WriteLine(validator.Validate(invalidDog) ? "Dog valid" : "Dog invalid");

Console.ReadKey();

public class Dog
{
    [StringLengthValidate(2, 10)]
    public string Name { get; } // Length must be between 2 and 10
    public Dog(string name) => Name = name;
}

public class Person
{
    [StringLengthValidate(2, 10)]
    public string Name { get; } // Length must be between 2 and 25
    public int YearOfBirth { get; }

    public Person(string name, int yearOfBirth)
    {
        Name = name;
        YearOfBirth = yearOfBirth;
    }

    public Person(string name) => Name = name;
}

public class Validator
{
    public bool Validate(object obj)
    {
        var type = obj.GetType();
        var propertiesToValidate = type.GetProperties().Where(property => Attribute.IsDefined(property, typeof(StringLengthValidateAttribute)));

        foreach (var property in propertiesToValidate)
        {
            object? propertyValue = property.GetValue(obj);

            if (propertyValue is not string)
            {
                throw new InvalidOperationException($"Attribute {nameof(StringLengthValidateAttribute)} can only be applied to strings.");
            }

            var value = (string)propertyValue;
            var attribute = (StringLengthValidateAttribute)property.GetCustomAttributes(typeof(StringLengthValidateAttribute), true).First();

            if (value.Length < attribute.Min || value.Length > attribute.Max)
            {
                Console.WriteLine($"Property `{property.Name}` in `{obj}` is invalid. Value is `{value}`.");
                return false;
            }
        }

        return true;
    }
}
[AttributeUsage(AttributeTargets.Property)]
public class StringLengthValidateAttribute : Attribute
{
    public int Min { get; }
    public int Max { get; }

    public StringLengthValidateAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }
}