﻿using System.Collections;

var customLinkedList = new CustomLinkedList<string>();

customLinkedList.AddToFront("a");
customLinkedList.AddToFront("b");
customLinkedList.AddToFront("c");
customLinkedList.Add("d");
customLinkedList.Add("e");

customLinkedList.Remove("a");

Console.WriteLine($"contains a? {customLinkedList.Contains("a")}");
Console.WriteLine($"contains d? {customLinkedList.Contains("d")}");

foreach (var item in customLinkedList)
{
    Console.WriteLine(item);
}

Console.ReadKey();

public interface ILinkedList<T> : ICollection<T>
{
    void AddToFront(T item);
    void AddToEnd(T item);
}

public class CustomLinkedList<T> : ILinkedList<T?>
{
    private Node? _head = null;
    private int _count = 0;

    public int Count => _count;

    public bool IsReadOnly => false;

    public void Add(T? item)
    {
        AddToEnd(item);
    }

    public void AddToEnd(T? item)
    {
        var newNode = new Node(item);

        if (_head is null)
        {
            _head = newNode;
        }
        else
        {
            var tail = GetNodes().Last();
            tail.Next = newNode;
        }

        _count++;
    }

    public void AddToFront(T? item)
    {
        var newHead = new Node(item)
        {
            Next = _head
        };

        _head = newHead;

        _count++;
    }

    public void Clear()
    {
        Node? current = _head;

        while (current is not null)
        {
            Node? temp = current;
            current = current.Next;
            temp.Next = null;
        }

        _head = null;
        _count = 0;
    }

    public bool Contains(T? item)
    {
        if (item is null)
        {
            return GetNodes().Any(node => node.Value is null);
        }

        return GetNodes().Any(node => item.Equals(node.Value));
    }

    public void CopyTo(T?[] array, int arrayIndex)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (arrayIndex < 0 || arrayIndex >= array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        }

        if (array.Length < _count + arrayIndex)
        {
            throw new ArgumentException("Array is not long enough");
        }

        foreach (var node in GetNodes())
        {
            array[arrayIndex] = node.Value;
            arrayIndex++;
        }
    }
    public bool Remove(T? item)
    {
        Node? predecessor = null;

        foreach (var node in GetNodes())
        {
            if ((node.Value is null && item is null)
                || (node.Value is not null && node.Value.Equals(item)))
            {
                if (predecessor is null)
                {
                    _head = node.Next;
                }
                else
                {
                    predecessor.Next = node.Next;
                }

                _count--;

                return true;
            }

            predecessor = node;
        }

        return false;
    }

    public IEnumerator<T?> GetEnumerator()
    {
        foreach (var node in GetNodes())
        {
            yield return node.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private IEnumerable<Node> GetNodes()
    {
        Node? current = _head;

        while (current is not null)
        {
            yield return current;
            current = current.Next;
        }
    }

    private class Node
    {
        public T? Value { get; }
        public Node? Next { get; set; }
        public Node(T? value)
        {
            Value = value;
        }

        public override string ToString() => $"Value: {Value}, Next: {(Next is null ? "null" : Next.Value)}";
    }
}