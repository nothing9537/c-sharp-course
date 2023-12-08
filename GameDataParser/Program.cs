using GameDataParser;

string logFilePath = "logs.log";

try
{
    var app = new App();
    app.Init();
}
catch (Exception ex)
{
    Logger.WriteToLogFile(ex, logFilePath);
}

Console.ReadKey();
