using LinkedLists.Double;

namespace Stacks;

public class MyStack<T>
{
    // It uses the custom MyDoubleLinkedList<T> class implementation to implement a stack.
    // See MyDoubleLinkedList.cs.
    private readonly MyDoubleLinkedList<T> _list = new();
    public MyStack(T item)
    {
        Push(item);
    }
    public bool IsEmpty => _list.Count == 0;
    public int Count => _list.Count;
    public void Push(T item) => _list.AddFirst(item);
    public T Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException();
        }
        T value = _list.First!.Value;
        _list.RemoveFirst();
        return value;
    }
    public T Peek()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException();
        }
        return _list.First!.Value;
    }
}