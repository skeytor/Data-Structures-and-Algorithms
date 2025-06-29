using LinkedLists.Double;

namespace Queues;

/// <summary>
/// Represents a generic queue data structure using a custom doubly linked list.
/// </summary>
/// <typeparam name="T">The type of elements in the queue.</typeparam>
public class MyQueue<T>
{
    private readonly MyDoubleLinkedList<T> _linkedList = new();

    /// <summary>
    /// Gets the number of elements contained in the queue.
    /// </summary>
    public int Count => _linkedList.Count;

    /// <summary>
    /// Gets a value indicating whether the queue is empty.
    /// </summary>
    public bool IsEmpty => _linkedList.IsEmpty;

    /// <summary>
    /// Initializes a new instance of the <see cref="MyQueue{T}"/> class with an initial value.
    /// </summary>
    /// <param name="value">The initial value to enqueue.</param>
    public MyQueue(T value) => Enqueue(value);

    /// <summary>
    /// Adds an item to the end of the queue.
    /// </summary>
    /// <param name="value">The value to enqueue.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <c>null</c>.</exception>
    public void Enqueue(T value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        _linkedList.AddLast(value);
    }

    /// <summary>
    /// Removes and returns the item at the beginning of the queue.
    /// </summary>
    /// <returns>The value removed from the front of the queue.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the queue is empty.</exception>
    public T Dequeue()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Queue empty");
        }
        return _linkedList.RemoveFirst();
    }

    /// <summary>
    /// Returns the item at the beginning of the queue without removing it.
    /// </summary>
    /// <returns>The value at the front of the queue.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the queue is empty.</exception>
    public T Peek()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Queue empty");
        }
        return _linkedList.First!.Value;
    }

    /// <summary>
    /// Determines whether the queue contains a specific value.
    /// </summary>
    /// <param name="value">The value to locate in the queue.</param>
    /// <returns><c>true</c> if the value is found; otherwise, <c>false</c>.</returns>
    public bool Contains(T value) => _linkedList.Find(value) is not null;
}