try
{
    Person invalidPersonAll = new Person(null, -100);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    Person invalidPersonName = new Person("", -100);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    Person invalidPersonYear = new Person("Valid name", 2024);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadKey();

class Person
{
    public string Name { get; set; }
    public int YearOfBirth { get; set; }

    public Person(string name, int yearOfBirth)
    {
        if (name is null)
        {
            throw new ArgumentNullException("The name cannot be null.");
        }

        if (name == string.Empty)
        {
            throw new ArgumentException("The name cannot be empty.");
        }

        if (yearOfBirth < 1900 || yearOfBirth > DateTime.Now.Year)
        {
            throw new ArgumentOutOfRangeException("The year of birth must be bewteen 1900 and the current year.");
        }

        Name = name;
        YearOfBirth = yearOfBirth;
    }
}