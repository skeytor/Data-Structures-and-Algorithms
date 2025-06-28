using System.Text;

namespace LinkedLists.Singly;

/// <summary>
/// Represents a singly linked list data structure.
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
public class MySinglyLinkedList<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    /// <summary>
    /// Gets the number of elements contained in the list.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Adds a new node containing the specified item at the start of the list.
    /// </summary>
    /// <param name="item">The value to add at the beginning of the list.</param>
    /// <returns>The newly created <see cref="Node{T}"/>.</returns>
    public Node<T> AddFirst(T item)
    {
        Node<T> node = new(item);
        if (IsEmpty)
        {
            _head = node;
            _tail = node;
        }
        else
        {
            node.Next = _head;
            _head = node;
            _tail ??= node;
        }
        Count++;
        return node;
    }

    /// <summary>
    /// Adds a new node containing the specified item at the end of the list.
    /// </summary>
    /// <param name="item">The value to add at the end of the list.</param>
    /// <returns>The newly created <see cref="Node{T}"/>.</returns>
    public Node<T> AddLast(T item)
    {
        Node<T> node = new(item);
        if (IsEmpty)
        {
            _tail = node;
            _head = node;
        }
        else
        {
            _tail!.Next = node;
            _tail = node;
        }
        Count++;
        return node;
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
            throw new InvalidOperationException("Empty list");
        }
        Node<T>? next = _head!.Next;
        _head!.Next = null;
        _head = next;
        if (next is null)
        {
            _tail = null;
        }
        Count--;
        return next!.Value;
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
            throw new InvalidOperationException("Empty list");
        }
        Node<T>? current = _head;
        if (_head?.Next is null)
        {
            _head = null;
            _tail = null;
            Count--;
            return current!.Value;
        }
        else
        {
            Node<T>? prev = null;
            while (current is not null)
            {
                if (current.Next is null)
                {
                    _tail = prev;
                    _tail!.Next = null;
                    break;
                }
                prev = current;
                current = current!.Next;
            }
            Count--;
            return current!.Value;
        }
    }

    /// <summary>
    /// Removes the first occurrence of the specified value from the list.
    /// </summary>
    /// <param name="value">The value to remove from the list.</param>
    /// <returns><c>true</c> if the value was found and removed; otherwise, <c>false</c>.</returns>
    public bool Remove(T value)
    {
        if (IsEmpty)
        {
            return false;
        }
        Node<T>? current = _head, prev = null;
        while (current is not null)
        {
            if (Equals(current.Value, value))
            {
                // Remove head value
                if (prev is null)
                {
                    _head = current.Next;
                    // If the list has only one node, set tail to null.
                    if (_head is null)
                    {
                        _tail = null;
                    }
                }
                else
                {
                    // Remove a node in the middle or end of the list.
                    prev.Next = current.Next;
                    // If the current node is the tail, update the tail.
                    if (current.Next is null)
                    {
                        _tail = prev;
                    }
                }
                Count--;
                return true;
            }
            prev = current;
            current = current.Next;
        }
        return false;
    }

    /// <summary>
    /// Removes all nodes from the list.
    /// </summary>
    public void Clear()
    {
        Node<T>? current = _head;
        while (current is not null)
        {
            Node<T>? next = current.Next;
            current.Next = null;
            current = next;
        }
        _head = null;
        _tail = null;
        Count = 0;
    }

    /// <summary>
    /// Gets a value indicating whether the list is empty.
    /// </summary>
    public bool IsEmpty => _head is null;

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
            sb.Append($"[ {current.Value} ] -> ");
            current = current.Next;
        }
        sb.Append("NULL");
        return sb.ToString();
    }
}

/// <summary>
/// Represents a node in a singly linked list.
/// </summary>
/// <typeparam name="T">The type of value stored in the node.</typeparam>
/// <param name="value">The value to store in the node.</param>
public sealed class Node<T>(T value)
{
    /// <summary>
    /// Gets the value stored in the node.
    /// </summary>
    public T Value { get; } = value;

    /// <summary>
    /// Gets the next node in the list.
    /// </summary>
    public Node<T>? Next { get; internal set; } = null;
}
