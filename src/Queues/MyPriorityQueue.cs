namespace Queues;

/// <summary>
/// Represents a min-heap based priority queue.
/// </summary>
/// <typeparam name="T">The type of elements in the priority queue. 
/// Must implement <see cref="IComparable{T}"/>.</typeparam>
public class MyPriorityQueue<T>(int initialCapacity) where T : IComparable<T>
{
    private const int DefaultCapacity = 16;
    private readonly List<T> _heap = new(initialCapacity);

    /// <summary>
    /// Initializes a new instance of the <see cref="MyPriorityQueue{T}"/> class with the default capacity.
    /// </summary>
    public MyPriorityQueue() : this(DefaultCapacity) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="MyPriorityQueue{T}"/> 
    /// class and enqueues the specified items.
    /// </summary>
    /// <param name="items">The collection of items to enqueue.</param>
    public MyPriorityQueue(IEnumerable<T> items) : this(DefaultCapacity)
    {
        foreach (T value in items)
        {
            Enqueue(value);
        }
    }

    /// <summary>
    /// Adds an item to the priority queue.
    /// </summary>
    /// <param name="item">The item to add.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="item"/> is <c>null</c>.</exception>
    public void Enqueue(T item)
    {
        ArgumentNullException.ThrowIfNull(item);
        _heap.Add(item);
        BubbleUp(_heap.Count - 1); // Start bubbling-up from the last element
    }

    /// <summary>
    /// Removes and returns the item with the highest priority (smallest value).
    /// </summary>
    /// <returns>The item with the highest priority.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the priority queue is empty.</exception>
    public T Dequeue()
    {
        if (_heap.Count == 0)
        {
            throw new InvalidOperationException("The priority queue is empty.");
        }
        T root = _heap[0];
        int lastIndex = _heap.Count - 1;
        _heap[0] = _heap[^1]; // Replace root with the last element
        _heap.RemoveAt(lastIndex); // Remove the last element
        BubbleDown(0); // Start bubbling-down from the root
        return root;
    }

    /// <summary>
    /// Returns the item with the highest priority (smallest value) without removing it.
    /// </summary>
    /// <returns>The item with the highest priority.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the priority queue is empty.</exception>
    public T Peek()
    {
        if (_heap.Count == 0)
        {
            throw new InvalidOperationException("The priority queue is empty.");
        }
        return _heap[0];
    }

    /// <summary>
    /// Adds an item to the priority queue and then removes and returns the item with the highest priority.
    /// </summary>
    /// <param name="value">The item to add.</param>
    /// <returns>The item with the highest priority after enqueueing.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is <c>null</c>.</exception>
    public T EnqueueDeque(T value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Enqueue(value);
        return Dequeue(); // Return the root after enqueueing
    }

    /// <summary>
    /// Removes all items from the priority queue.
    /// </summary>
    public void Clear() => _heap.Clear();

    /// <summary>
    /// Restores the heap property by moving the element at the specified index down the tree.
    /// </summary>
    /// <param name="current">The index of the element to bubble down.</param>
    private void BubbleDown(int current)
    {
        while (true)
        {
            int left = LeftChild(current);
            int right = RightChild(current);
            int smallest = current; // It supposes the current node is the smallest
            // Check if the left is smaller than the current node
            if (left < _heap.Count && LessThan(left, smallest))
            {
                smallest = left;
            }
            if (right < _heap.Count && LessThan(right, smallest))
            {
                smallest = right;
            }
            if (smallest == current)
            {
                break;
            }
            Swap(current, smallest);
            current = smallest;
        }
    }

    /// <summary>
    /// Restores the heap property by moving the element at the specified index up the tree.
    /// </summary>
    /// <param name="current">The index of the element to bubble up.</param>
    private void BubbleUp(int current)
    {
        while (current > 0 && LessThan(current, Parent(current)))
        {
            Swap(current, Parent(current));
            current = Parent(current); // Move up the heap (parent index)
        }
    }

    /// <summary>
    /// Determines whether the element at the left index is less than the element at the right index.
    /// </summary>
    /// <param name="left">The index of the first element.</param>
    /// <param name="right">The index of the second element.</param>
    /// <returns><see langword="true"/> if the element at <paramref name="left"/> is less than the element at <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
    private bool LessThan(int left, int right) => _heap[left].CompareTo(_heap[right]) < 0;

    /// <summary>
    /// Swaps the elements at the specified indices.
    /// </summary>
    /// <param name="left">The index of the first element.</param>
    /// <param name="right">The index of the second element.</param>
    private void Swap(int left, int right) => (_heap[right], _heap[left]) = (_heap[left], _heap[right]);

    /// <summary>
    /// Returns the index of the parent of the specified node.
    /// </summary>
    /// <param name="index">The index of the node.</param>
    /// <returns>The index of the parent node.</returns>
    private static int Parent(int index) => (index - 1) / 2;

    /// <summary>
    /// Returns the index of the left child of the specified node.
    /// </summary>
    /// <param name="index">The index of the node.</param>
    /// <returns>The index of the left child node.</returns>
    private static int LeftChild(int index) => (2 * index) + 1;

    /// <summary>
    /// Returns the index of the right child of the specified node.
    /// </summary>
    /// <param name="index">The index of the node.</param>
    /// <returns>The index of the right child node.</returns>
    private static int RightChild(int index) => (2 * index) + 2;
}