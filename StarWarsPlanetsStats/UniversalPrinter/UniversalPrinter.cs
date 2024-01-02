namespace StarWarsPlanetsStats.UniversalPrinter;

public class UniversalPrinter(int columnLength)
{
    private readonly int _columnLength = columnLength;

    public void Print<T>(IEnumerable<T> data) where T : class
    {
        var itemsCount = data.Count();

        var baseItem = data.First();
        var baseItemProperties = baseItem.GetType().GetProperties();

        var columns = baseItemProperties.Length;

        PrintInLine(baseItemProperties.Select(prop => prop.Name));
        PrintSeparatorLine(columns);
        PrintData(data);
    }

    private string MakeRecord<T>(T item)
    {
        var spacesCount = _columnLength - item!.ToString()!.Length;
        var record = item.ToString();

        for (int i = 0; i < spacesCount - 1; i++)
        {
            record += " ";
        }

        return $"{record}|";
    }

    private void PrintInLine<T>(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Console.Write(MakeRecord(item));
        }

        Console.Write("\n");
    }

    private void PrintSeparatorLine(int columns)
    {
        var separatorCount = columns * _columnLength;

        for (int i = 0; i < separatorCount; i++)
        {
            Console.Write("-");
        }

        Console.Write("\n");
    }
    private void PrintData<T>(IEnumerable<T> data)
    {
        foreach (var dataItem in data)
        {
            var dataItemProperties = dataItem!.GetType().GetProperties();

            PrintInLine(dataItemProperties.Select(property => property.GetValue(dataItem)));
        }
    }
}
