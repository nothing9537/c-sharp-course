//var smallSubset = GenerateHugeListOfEvenNumbers().Skip(5).Take(10);

//foreach (var num in GenerateHugeListOfEvenNumbers())
//{
//    if (num == 50)
//    {
//        break;
//    }

//    Console.WriteLine(num);
//}

//var firstNum = GenerateHugeListOfEvenNumbers().First();

var evenNumbers = GenerateHugeListOfEvenNumbers();

foreach (var num in evenNumbers.Take(5)) // Instead of creating 2.1 billon of numbers (Max value for `int`), it only creates the ones that are necessary
{
    Console.WriteLine($"Number is: {num}");
}

Console.ReadKey();

IEnumerable<int> GenerateHugeListOfEvenNumbers()
{
    var res = new List<int>();

    for (int i = 0; i < int.MaxValue; i += 2)
    {
        Console.WriteLine($"Yielding index: {i}");
        yield return i;
    }

    //return res;
}