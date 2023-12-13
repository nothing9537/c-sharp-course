var persons = new List<Person>
{
    new Person { Name = "John", YearOfBirth = 1980 },
    new Person { Name = "Anna", YearOfBirth = 1915 },
    new Person { Name = "Bill", YearOfBirth = 2011 },
};

persons.Sort();

var employees = new List<Employee>
{
    new Employee { Name = "John", YearOfBirth = 1980 },
    new Employee { Name = "Anna", YearOfBirth = 2050 },
    new Employee { Name = "Bill", YearOfBirth = 1800 },
};

var validPersons = GetOnlyValid<Person>(persons);
var validEmployees = GetOnlyValid<Employee>(employees);

foreach (var employee in validEmployees)
{
    employee.GoToWork();
}

var john = new Person { Name = "John", YearOfBirth = 1980 };
var anna = new Person { Name = "Anna", YearOfBirth = 2002 };

PrintInOrder(10, 5);
PrintInOrder("bbb", "aaa");
PrintInOrder(john, anna);

void PrintInOrder<T>(T first, T second) where T : IComparable<T>
{
    if (first.CompareTo(second) > 0)
    {
        Console.WriteLine($"{second} {first}");
    }
    else
    {
        Console.WriteLine($"{first} {second}");
    }
}

Console.ReadKey();

IEnumerable<TPerson> GetOnlyValid<TPerson>(IEnumerable<TPerson> persons) where TPerson : Person
{
    var res = new List<TPerson>();

    foreach (var person in persons)
    {
        if (person.YearOfBirth > 1900 && person.YearOfBirth < DateTime.Now.Year)
        {
            res.Add(person);
        }
    }

    return res;
}

class Person : IComparable<Person>
{
    public string Name { get; init; }
    public int YearOfBirth { get; init; }
    public override string ToString() => $"The person name is: {Name} and year of birth is {YearOfBirth}";

    public int CompareTo(Person person)
    {
        if (YearOfBirth < person.YearOfBirth)
        {
            return 1;
        }
        else if (YearOfBirth > person.YearOfBirth)
        {
            return -1;
        }

        return 0;
    }
}

class Employee : Person
{
    public void GoToWork() => Console.WriteLine("Going to work.");
}