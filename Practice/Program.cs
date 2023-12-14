using System.Numerics;

var employees = new List<Employee>
{
    new Employee("Jake Smith", "Space Navigation", 15000m),
    new Employee("Anna Kretova", "Space Navigation", 17000m),
    new Employee("John Doe", "Space Navigation", 10000m),
    new Employee("Barbara Oek", "Software Development", 12000m),
    new Employee("Anna Smith", "Software Development", 7000m),
    new Employee("Vitaliy Tsal", "Software Development", 8500m),
    new Employee("Jessica Smith", "Robotics", 7000m),
    new Employee("Noel Parker", "Robotics", 8000m),
    new Employee("Gustavo Sanchez", "Robotics", 11000m),
};

Dictionary<string, decimal> AverageSalaryOnDepartment(IEnumerable<Employee> employees)
{
    Dictionary<string, decimal> res = new Dictionary<string, decimal>();
    Dictionary<string, List<decimal>> temp = new Dictionary<string, List<decimal>>();

    foreach (var employee in employees)
    {
        if (!res.ContainsKey(employee.Department))
        {
            temp[employee.Department] = new List<decimal> { employee.Salary };
        }
        else
        {
            temp[employee.Department].Add(employee.Salary);
        }
    }

    foreach (var tempData in temp)
    {
        res.Add(tempData.Key, CalcAverage(tempData.Value));
    }

    return res;
}

var res = AverageSalaryOnDepartment(employees);

foreach (var item in res)
{
    Console.WriteLine($"On department {item.Key} avarage salary is: {item.Value}");
}

T CalcAverage<T>(IEnumerable<T> values) where T : INumber<T>
{
    dynamic sum = 0;
    int count = 0;

    foreach (var item in values)
    {
        sum += item;
        count++;
    }

    return sum / count;
}

Console.ReadKey();

public class Employee
{
    public string Name { get; init; }
    public string Department { get; init; }
    public decimal Salary { get; init; }

    public Employee(string name, string department, decimal mothlySalary)
    {
        Name = name;
        Department = department;
        Salary = mothlySalary;
    }
}