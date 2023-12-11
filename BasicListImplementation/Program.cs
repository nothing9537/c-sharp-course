var numbers = new OwnList<int>();

public class OwnList<T>
{
    private int _size = 0;
    private T[] _items = new T[1];

    public OwnList(params T[] initialItems)
    {
        for (int i = 0; i < initialItems.Length; i++)
        {
            var item = initialItems[i];

            Add(item);
        }
    }

    public int Add(T item)
    {
        if (_size >= _items.Length)
        {
            var newItems = new T[_items.Length * 2];

            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }

        _items[_size] = item;
        _size++;

        return _size;
    }

    public void RemoveAt(int index)
    {
        ValidateIndex(index);

        --_size;

        for (int i = index; i < _size; i++)
        {
            _items[i] = _items[i + 1];
        }

        _items[_size] = default;
    }

    private void ValidateIndex(int index)
    {
        if (index >= 0 && index < _items.Length)
        {
            return;
        }
        else
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }
    }

    public T GetAtIndex(int index)
    {
        ValidateIndex(index);

        return _items[index];
    }
}