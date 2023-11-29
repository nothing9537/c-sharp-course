var app = new Exercise();
var stringsList = new List<string> { "bobcat", "wolverine", "grizzly" };
var result = app.ProcessAll(stringsList);

foreach (var item in result)
{
    Console.WriteLine(item);
}

Console.ReadKey();

public class Exercise
{
    public List<string> ProcessAll(List<string> words)
    {
        var stringsProcessors = new List<StringsProcessor>
            {
                new StringsTrimmingProcessor(),
                new StringsUppercaseProcessor()
            };

        List<string> result = words;

        foreach (var stringsProcessor in stringsProcessors)
        {
            result = stringsProcessor.Process(result);
        }

        return result;
    }

    class StringsProcessor
    {
        public List<string> Process(List<string> words)
        {
            List<string> transformedStrings = [];

            foreach (string item in words)
            {
                transformedStrings.Add(TransformHandler(item));
            }

            return transformedStrings;
        }

        public virtual string TransformHandler(string word) => word;
    }

    class StringsTrimmingProcessor : StringsProcessor
    {
        public override string TransformHandler(string word) => word.Substring(0, word.Length / 2);
    }
    class StringsUppercaseProcessor : StringsProcessor
    {
        public override string TransformHandler(string word) => word.ToUpper();
    }
}