using System;
using System.Threading.Tasks;
using System.Collections;

public class MyOwnCollectionCollection<T> : IEnumerable
{
    private T[] _items;
    private int _limit;
    private int _filledItems;
    public MyOwnCollectionCollection(int sizeOfCollection)
    {
        _limit = sizeOfCollection;
        _items = new T[sizeOfCollection];
    }
    public T this[int i]
    {
        get => _items[i];

        set => _items[i] = value;
    }
    public void Add(T item)
    {
        var _idx = _filledItems - _limit;
        var _left = _limit - _filledItems;
        if (_limit <= _filledItems)
        {
            Console.WriteLine($"{_items[_idx]} was deleted");
            _items[_idx] = item;
        }
        else
        {
            _items[_filledItems] = item;
            _filledItems++;
            Console.WriteLine($"{item} was added");
            if (_left >= 0)
            {
                Console.WriteLine($"{_left} Place left");
            }
        }
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public ItemEnum<T> GetEnumerator() => new ItemEnum<T>(_items, _filledItems);
}
public class ItemEnum<T> : IEnumerator
{
    private T[] _items;

    private int _idx = -1;

    public ItemEnum(T[] list, int _filledItems) => _items = list[0.._filledItems];

    public bool MoveNext()
    {
        _idx++;
        return (_idx < _items.Length);
    }

    public void Reset() => _idx = -1;


    object IEnumerator.Current
    {
        get => Current;
    }

    public T Current
    {
        get => _items[_idx];
    }
}
class Program
{
    static void Main()
    {
        var sizeOfCollection = 5;
        var collection = new MyOwnCollectionCollection<int>(sizeOfCollection);
        collection.Add(0);
        collection.Add(1);
        collection.Add(2);
        collection.Add(3);
        collection.Add(4);
        foreach (var item in collection)
        {
            Console.WriteLine($"In foreach item is {item}");
        }
        Console.ReadKey();
    }
}