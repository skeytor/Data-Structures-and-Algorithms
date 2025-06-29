using Queues;

namespace UnitTests.Queues;

public class MyQueueTests
{
    [Fact]
    public void MyQueue_Should_ContainInitialItem_AfterConstruction()
    {
        MyQueue<int> queue = new(42);
        Assert.False(queue.IsEmpty);
        Assert.Equal(1, queue.Count);
        Assert.Equal(42, queue.Peek());
    }

    [Fact]
    public void MyQueue_Should_EnqueueItems_And_PeekReturnsFirst()
    {
        MyQueue<string> queue = new("first");
        queue.Enqueue("second");
        queue.Enqueue("third");
        Assert.Equal(3, queue.Count);
        Assert.Equal("first", queue.Peek());
    }

    [Fact]
    public void MyQueue_Should_DequeueItems_InFIFOOrder()
    {
        MyQueue<int> queue = new(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());
        Assert.Equal(3, queue.Dequeue());
        Assert.True(queue.IsEmpty);
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void MyQueue_Should_ThrowInvalidOperationException_When_DequeueOnEmpty()
    {
        MyQueue<int> queue = new(1);
        queue.Dequeue();
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Fact]
    public void MyQueue_Should_PeekWithoutRemovingItem()
    {
        MyQueue<string> queue = new("a");
        queue.Enqueue("b");
        string front = queue.Peek();
        Assert.Equal("a", front);
        Assert.Equal(2, queue.Count);
        Assert.False(queue.IsEmpty);
    }

    [Fact]
    public void MyQueue_Should_ThrowInvalidOperationException_When_PeekOnEmpty()
    {
        MyQueue<int> queue = new(1);
        queue.Dequeue();
        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    [Fact]
    public void MyQueue_Should_ReportIsEmptyAndCountCorrectly()
    {
        MyQueue<int> queue = new(10);
        Assert.False(queue.IsEmpty);
        Assert.Equal(1, queue.Count);
        queue.Enqueue(20);
        Assert.Equal(2, queue.Count);
        queue.Dequeue();
        queue.Dequeue();
        Assert.True(queue.IsEmpty);
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void MyQueue_Should_Contain_And_NotContain_Values()
    {
        MyQueue<int> queue = new(5);
        queue.Enqueue(10);
        queue.Enqueue(15);
        Assert.True(queue.Contains(5));
        Assert.True(queue.Contains(10));
        Assert.False(queue.Contains(20));
    }

    [Fact]
    public void MyQueue_Should_Throw_When_EnqueueNullReferenceType()
    {
        MyQueue<string> queue = new("a");
        Assert.Throws<ArgumentNullException>(() => queue.Enqueue(null));
    }
}