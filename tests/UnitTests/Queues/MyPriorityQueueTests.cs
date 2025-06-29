using Queues;

namespace UnitTests.Queues;

public class MyPriorityQueueTests
{
    [Fact]
    public void MyPriorityQueue_Should_EnqueueAndDequeue_InMinHeapOrder()
    {
        MyPriorityQueue<int> queue = new();
        queue.Enqueue(5);
        queue.Enqueue(3);
        queue.Enqueue(8);
        queue.Enqueue(1);
        
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(3, queue.Dequeue());
        Assert.Equal(5, queue.Dequeue());
        Assert.Equal(8, queue.Dequeue());
    }

    [Fact]
    public void MyPriorityQueue_Should_Peek_ReturnSmallestElement()
    {
        MyPriorityQueue<int> queue = new();
        queue.Enqueue(10);
        queue.Enqueue(2);
        queue.Enqueue(7);

        Assert.Equal(2, queue.Peek());
        Assert.Equal(2, queue.Peek()); // Should not remove
    }

    [Fact]
    public void MyPriorityQueue_Should_EnqueueDeque_ReturnSmallestAfterEnqueue()
    {
        MyPriorityQueue<int> queue = new();
        queue.Enqueue(4);
        queue.Enqueue(6);
        int result = queue.EnqueueDeque(2);
        Assert.Equal(2, result);
        Assert.Equal(4, queue.Peek());
    }

    [Fact]
    public void MyPriorityQueue_Should_Clear_AllElements()
    {
        MyPriorityQueue<int> queue = new();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Clear();
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    [Fact]
    public void MyPriorityQueue_Should_Throw_When_DequeueOrPeekOnEmpty()
    {
        MyPriorityQueue<int> queue = new();
        queue.Enqueue(1);
        queue.Dequeue();
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    [Fact]
    public void MyPriorityQueue_Should_Throw_When_EnqueueNullReferenceType()
    {
        MyPriorityQueue<string> queue = new();
        Assert.Throws<ArgumentNullException>(() => queue.Enqueue(null));
        Assert.Throws<ArgumentNullException>(() => queue.EnqueueDeque(null));
    }

    [Fact]
    public void MyPriorityQueue_Should_ConstructWithEnumerable()
    {
        int[] items = [7, 3, 5, 1];
        MyPriorityQueue<int> queue = new(items);
        Assert.Equal(1, queue.Peek());
    }

    [Fact]
    public void MyPriorityQueue_Should_ConstructWithInitialCapacity()
    {
        MyPriorityQueue<int> queue = new(32);
        queue.Enqueue(10);
        Assert.Equal(10, queue.Peek());
    }

}