Console.WriteLine("Enter a number.");
string userInput = Console.ReadLine()!;

try
{
    int number = ParseStringToInt(userInput);
    Console.WriteLine($"String parsing was successfully, the result is: {number}");
    int result = 10 / number;
    Console.WriteLine($"Divison was succsessful. 10 / {number} = {result}");
}
catch (FormatException ex)
{
    Console.WriteLine($"Wrong format. Input string is not parsable to int. Message: {ex.Message}");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Division by zero is an invalid operation. Message: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error occured. Message: {ex.Message}");
}
finally
{
    Console.WriteLine("Finnaly block is being executed.");
}

Console.ReadKey();

int ParseStringToInt(string input)
{
    return int.Parse(input);
}