using System.Text;

namespace Arrays;

/// <summary>
/// This class implements a dynamic array, using generics and providing basic operations.
/// </summary>
/// <typeparam name="T"></typeparam>
public class MyDynamicArray<T>
{
    private const int DefaultCapacity = 4;
    private T[] _array;
    private int _size; // Number of elements in the array
    private int _capacity; // Actual array size

    public MyDynamicArray(int initialCapacity)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(initialCapacity, nameof(initialCapacity));
        _capacity = initialCapacity;
        _array = new T[_capacity];
    }
    public MyDynamicArray() : this(DefaultCapacity) { }

    // Supported by index
    public T this[int index]
    {
        get
        {
            if (index >= _size || index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return _array[index];
        }
        set
        {
            if (index >= _size || index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            _array[index] = value;
        }
    }
    public int Count => _size;
    /// <summary>
    /// Adds an item to the collection.
    /// </summary>
    /// <remarks>If the collection's capacity is exceeded, the internal storage is resized automatically  to
    /// accommodate the new item.</remarks>
    /// <param name="item">The item to add to the collection.</param>
    public void Add(T item)
    {
        if (_size >= _capacity)
        {
            Resize();
        }
        _array[_size++] = item;
    }
    /// <summary>
    /// Attempts to find the specified item in the collection.
    /// </summary>
    /// <param name="item">The item to search for in the collection. Cannot be <see langword="null"/>.</param>
    /// <param name="result">When this method returns, contains the found item if the search is successful; otherwise, contains the default
    /// value for the type <typeparamref name="T"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the specified item is found in the collection; otherwise, <see langword="false"/>.</returns>
    public bool TryFind(T item, out T? result)
    {
        ArgumentNullException.ThrowIfNull(item);
        // A linear search with O(n) complexity
        for (int i = 0; i < _size; i++)
        {
            if (Equals(_array[i], item))
            {
                result = _array[i];
                return true;
            }
        }
        result = default!;
        return false;
    }
    /// <summary>
    /// Removes the element at the specified index from the collection.
    /// </summary>
    /// <remarks>After the element is removed, all subsequent elements are shifted one position to the left to
    /// fill the gap. The last element in the collection is set to its default value.</remarks>
    /// <param name="index">The zero-based index of the element to remove. Must be greater than or equal to 0 and less than the current size
    /// of the collection.</param>
    public void RemoveAt(int index)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(index, nameof(index));
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, _size, nameof(index));
        // Shift elements left. Do not shrink, because it would be overload.
        for (int i = index; i < _size; i++)
        {
            _array[i] = _array[i + 1];
        }
        _array[_size - 1] = default!; // Clear last slot
        _size--;
    }
    /// <summary>
    /// Removes the first occurrence of the specified item from the collection.
    /// </summary>
    /// <param name="item">The item to remove from the collection. Cannot be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the item was successfully removed; otherwise, <see langword="false"/>. Returns <see
    /// langword="false"/> if the item was not found in the collection.</returns>
    public bool Remove(T item)
    {
        ArgumentNullException.ThrowIfNull(item, nameof(item));
        for (int i = 0; i < _size; i++)
        {
            if (Equals(_array[i], item))
            {
                RemoveAt(i);
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// Doubles the capacity of the internal array and copies existing elements to the new array.
    /// </summary>
    /// <remarks>This method is used to increase the storage capacity when the current array reaches its
    /// limit. It preserves the existing elements in the same order while allocating additional space for future
    /// elements.</remarks>
    private void Resize()
    {
        // Resize array capacity and copy elements
        _capacity = _capacity * 2;
        T[] array = new T[_capacity];
        for (int i = 0; i < _size; i++)
        {
            array[i] = _array[i];
        }
        _array = array;
    }
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append('[');
        for (int i = 0; i < _size; i++)
        {
            if (i == _size - 1)
            {
                sb.Append($"{_array[i]}");
            }
            else
            {
                sb.Append($"{_array[i]}, ");
            }
        }
        sb.Append(']');
        return sb.ToString();
    }
}