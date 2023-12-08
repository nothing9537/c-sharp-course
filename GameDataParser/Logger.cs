namespace GameDataParser.Logger;

static class Logger
{
    public static void WriteToLogFile(Exception ex, string filePath)
    {
        Console.WriteLine("An unexpected message was occured." + ex.Message);

        string logMessage = $"{DateTime.Now} - message: {ex.Message}\n";
        string dataToWrite;

        if (File.Exists(filePath))
        {
            string fileContent = File.ReadAllText(filePath);
            dataToWrite = fileContent + logMessage;
        }
        else
        {
            dataToWrite = logMessage;
        }

        File.WriteAllText(filePath, dataToWrite);
    }
}
