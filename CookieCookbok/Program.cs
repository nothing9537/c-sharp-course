using CookieCookbook;
using CookieCookbook.Types;

var fileFormat = FileFormat.JSON;
var filePath = fileFormat == FileFormat.TXT ? "data.txt" : "data.json";
var cookbook = new MainCookbook(fileFormat, filePath);

cookbook.Init();

Console.WriteLine("Press any key to close.");
Console.ReadKey();