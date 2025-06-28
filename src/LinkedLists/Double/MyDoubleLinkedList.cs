using LinkedLists.Singly;
using System.Text;

namespace LinkedLists.Double;

/// <summary>
/// Represents a doubly linked list data structure.
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
public class MyDoubleLinkedList<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    /// <summary>
    /// Gets the number of elements contained in the list.
    /// </summary>
    public int Count { get; private set; } = default;

    /// <summary>
    /// Gets a value indicating whether the list is empty.
    /// </summary>
    public bool IsEmpty => _head is null;

    /// <summary>
    /// Gets the first node of the list.
    /// </summary>
    public Node<T>? First => _head;

    /// <summary>
    /// Gets the last node of the list.
    /// </summary>
    public Node<T>? Last => _tail;

    /// <summary>
    /// Adds a new node containing the specified value at the end of the list.
    /// </summary>
    /// <param name="value">The value to add at the end of the list.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <c>null</c>.</exception>
    public void AddLast(T value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Node<T> node = new(value, next: null, previous: _tail);
        if (IsEmpty)
        {
            _head = node;
            _tail = node;
        }
        else
        {
            _tail!.Next = node;
            _tail = node;
        }
        Count++;
    }

    /// <summary>
    /// Adds a new node containing the specified value at the start of the list.
    /// </summary>
    /// <param name="value">The value to add at the beginning of the list.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <c>null</c>.</exception>
    public void AddFirst(T value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Node<T> node = new(value, next: _head, previous: null);
        if (IsEmpty)
        {
            _head = node;
            _tail = node;
        }
        else
        {
            _head!.Previous = node;
            _head = node;
        }
        Count++;
    }

    /// <summary>
    /// Removes the first node from the list and returns its value.
    /// </summary>
    /// <returns>The value of the removed node.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the list is empty.</exception>
    public T RemoveFirst()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Linked list is empty");
        }
        T value = _head!.Value;
        Node<T>? next = _head.Next;
        if (next is null)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _head.Next = null;
            next.Previous = null;
            _head = next;
        }
        Count--;
        return value;
    }

    /// <summary>
    /// Removes the last node from the list and returns its value.
    /// </summary>
    /// <returns>The value of the removed node.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the list is empty.</exception>
    public T RemoveLast()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Linked list is empty");
        }
        T value = _tail!.Value;
        Node<T>? prev = _tail!.Previous;
        if (prev is null)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _tail!.Previous = null;
            prev!.Next = null;
            _tail = prev;
        }
        Count--;
        return value;
    }

    /// <summary>
    /// Removes the first occurrence of the specified value from the list.
    /// </summary>
    /// <param name="value">The value to remove from the list.</param>
    /// <returns><c>true</c> if the value was found and removed; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <c>null</c>.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the list is empty.</exception>
    public bool Remove(T value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        if (IsEmpty)
        {
            throw new InvalidOperationException("Empty list");
        }
        Node<T>? current = _head;
        while (current is not null)
        {
            if (Equals(current.Value, value))
            {
                // If the list has only one node, update head and tail to null.
                if (current.Previous is null && current.Next is null)
                {
                    _head = null;
                    _tail = null;
                }
                else
                {
                    // Remove the first node if the node to remove is the head.
                    if (current.Previous is null)
                    {
                        _head = current.Next;
                        _head!.Previous = null;
                    }
                    // Remove the last node if the node to remove is the tail.
                    else if (current.Next is null)
                    {
                        _tail = current.Previous;
                        _tail.Next = null;
                    }
                    // Otherwise, remove the node from the middle of the list.
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }
                }
                Count--;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    /// <summary>
    /// Finds the first node containing the specified value.
    /// </summary>
    /// <param name="value">The value to locate in the list.</param>
    /// <returns>The first <see cref="Node{T}"/> that contains the specified value, or <c>null</c> if not found.</returns>
    public Node<T>? Find(T value)
    {
        Node<T>? current = _head;
        // To find a node, it always have O(n) time complexity
        while (current is not null)
        {
            if (Equals(current.Value, value))
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }

    /// <summary>
    /// Adds a new node containing the specified value before the specified node.
    /// </summary>
    /// <param name="node">The node before which to insert the new value.</param>
    /// <param name="value">The value to insert.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="node"/> or <paramref name="value"/> is <c>null</c>.</exception>
    public void AddBefore(Node<T> node, T value)
    {
        ArgumentNullException.ThrowIfNull(node);
        ArgumentNullException.ThrowIfNull(value);
        if (node == _head)
        {
            AddFirst(value);
            return;
        }
        Node<T>? prev = node.Previous;
        Node<T>? newNode = new(value, next: node, previous: prev);
        prev!.Next = newNode;
        node.Previous = newNode;
    }

    /// <summary>
    /// Adds a new node containing the specified value after the specified node.
    /// </summary>
    /// <param name="node">The node after which to insert the new value.</param>
    /// <param name="value">The value to insert.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="node"/> or <paramref name="value"/> is <c>null</c>.</exception>
    public void AddAfter(Node<T> node, T value)
    {
        ArgumentNullException.ThrowIfNull(node, nameof(node));
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        if (node == _tail)
        {
            AddLast(value);
            return;
        }
        Node<T>? next = node.Next;
        Node<T> newNode = new(value, next, node);
        node.Next = newNode;
        next!.Previous = newNode;
    }

    /// <summary>
    /// Returns a string that represents the current list.
    /// </summary>
    /// <returns>A string representation of the list.</returns>
    public override string ToString()
    {
        StringBuilder sb = new();
        if (IsEmpty)
        {
            return "[]";
        }
        Node<T>? current = _head;
        while (current != null)
        {
            sb.Append($"{current.Value} <-> ");
            current = current.Next;
        }
        sb.Append("null");
        return sb.ToString();
    }
}

/// <summary>
/// Represents a node in a doubly linked list.
/// </summary>
/// <typeparam name="T">The type of value stored in the node.</typeparam>
/// <param name="value">The value to store in the node.</param>
public sealed class Node<T>(T value)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Node{T}"/> class with the specified value, next node, and previous node.
    /// </summary>
    /// <param name="value">The value to store in the node.</param>
    /// <param name="next">The next node in the list.</param>
    /// <param name="previous">The previous node in the list.</param>
    public Node(T value, Node<T>? next, Node<T>? previous) : this(value)
    {
        Next = next;
        Previous = previous;
    }

    /// <summary>
    /// Gets the value stored in the node.
    /// </summary>
    public T Value { get; } = value;

    /// <summary>
    /// Gets the next node in the list.
    /// </summary>
    public Node<T>? Next { get; internal set; }

    /// <summary>
    /// Gets the previous node in the list.
    /// </summary>
    public Node<T>? Previous { get; internal set; }
}