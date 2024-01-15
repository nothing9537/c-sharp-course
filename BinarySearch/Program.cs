var sortedCollection = new List<int> { 1, 2, 4, 7, 9, 15, 21, 34, 35, 55, 68 };

var isCollectionContains1 = sortedCollection.FindIndex(1);
var isCollectionContains68 = sortedCollection.FindIndex(68);
var isCollectionContains4 = sortedCollection.FindIndex(4);
var isCollectionContains3 = sortedCollection.FindIndex(3);
var isCollectionContains0 = sortedCollection.FindIndex(0);

Console.ReadKey();
public static class ListExtentions
{
    public static int? FindIndex<T>(this List<T> input, T toFind) where T : IComparable<T>
    {
        var leftBound = 0;
        var rightBound = input.Count - 1;

        while (leftBound <= rightBound)
        {
            int middle = (leftBound + rightBound) / 2;

            if (toFind.Equals(input[middle]))
            {
                return middle;
            }
            else if (toFind.CompareTo(input[middle]) < 0)
            {
                rightBound = middle - 1;
            }
            else
            {
                leftBound = middle + 1;
            }
        }

        return null;
    }
}