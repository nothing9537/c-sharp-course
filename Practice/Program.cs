using System.Collections;

var customCollection = new CustomCollection(["aaa", "bbb", "ccc"]);
//string[] words = ["aaa", "bbb", "ccc"];

//foreach (var word in words)
//{
//    Console.WriteLine(word); // Same result
//}

//IEnumerator wordsEnumenator = words.GetEnumerator();

//object currentItem;

//while (wordsEnumenator.MoveNext())
//{
//    currentItem = wordsEnumenator.Current;
//    Console.WriteLine(currentItem); // Same result
//}


foreach (var word in customCollection)
{
    Console.WriteLine(word);
}

Console.ReadKey();

public class CustomCollection : IEnumerable<string>
{
    public string[] Words { get; }

    public CustomCollection(string[] words)
    {
        Words = words;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<string> GetEnumerator()
    {
        return new WordsEnumenator(Words);
    }

    public string this[int index]
    {
        get => Words[index];
        set => Words[index] = value;
    }
}

public class WordsEnumenator : IEnumerator<string>, IDisposable
{
    private int _currentIndex = -1;
    private readonly string[] _items;

    public WordsEnumenator(string[] items)
    {
        _items = items;
    }

    object IEnumerator.Current => Current;

    public string Current
    {
        get
        {
            try
            {
                return _items[_currentIndex];

            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException($"{nameof(CustomCollection)}'s end reached", ex);
            }
        }
    }

    public bool MoveNext()
    {
        _currentIndex++;

        return _currentIndex < _items.Length;
    }

    public void Reset()
    {
        _currentIndex = 0;
    }

    public void Dispose() { }
}