using Names_SRP.DataAccess;
using Names_SRP.Formatter;
using Names_SRP.FilePathBuilder;

var names = new Names();
var path = new NamesFilePathBuilder().BuildFilePath();
var stringsTexttualRepository = new StringsTextualRepository();

Stopwatch stopwatch = Stopwatch.StartNew();

if (File.Exists(path))
{
    Console.WriteLine("Names file already exists. Loading names.");

    var stringsFromFile = stringsTexttualRepository.Read(path);
    names.AddNames(stringsFromFile);
}
else
{
    Console.WriteLine("Names file does not yet exist.");

    //let's imagine they are given by the user
    names.AddName("John");
    names.AddName("not a valid name");
    names.AddName("Claire");
    names.AddName("123 definitely not a valid name");

    Console.WriteLine("Saving names to the file.");
    stringsTexttualRepository.Write(path, names.AllNames);
}

Console.WriteLine(new NamesFormatter().Format(names.AllNames));

stopwatch.Stop();

Console.WriteLine($"Execution time in ms: {stopwatch.ElapsedMilliseconds}");

Console.ReadLine();