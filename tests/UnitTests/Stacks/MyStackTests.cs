using Stacks;

namespace UnitTests.Stacks;

public class MyStackTests
{
    [Fact]
    public void MyStack_Should_ContainInitialItem_AfterConstruction()
    {
        MyStack<int> stack = new(42);
        Assert.False(stack.IsEmpty);
        Assert.Equal(1, stack.Count);
        Assert.Equal(42, stack.Peek());
    }

    [Fact]
    public void MyStack_Should_PushItems_And_PeekReturnsLastPushed()
    {
        MyStack<string> stack = new("first");
        stack.Push("second");
        stack.Push("third");
        Assert.Equal(3, stack.Count);
        Assert.Equal("third", stack.Peek());
    }

    [Fact]
    public void MyStack_Should_PopItems_InLIFOOrder()
    {
        MyStack<int> stack = new(1);
        stack.Push(2);
        stack.Push(3);
        Assert.Equal(3, stack.Pop());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Pop());
        Assert.True(stack.IsEmpty);
        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void MyStack_Should_ThrowInvalidOperationException_When_PopOnEmpty()
    {
        MyStack<int> stack = new(1);
        stack.Pop();
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void MyStack_Should_PeekWithoutRemovingItem()
    {
        MyStack<string> stack = new("a");
        stack.Push("b");
        string top = stack.Peek();
        Assert.Equal("b", top);
        Assert.Equal(2, stack.Count);
        Assert.False(stack.IsEmpty);
    }

    [Fact]
    public void MyStack_Should_ThrowInvalidOperationException_When_PeekOnEmpty()
    {
        MyStack<int> stack = new(1);
        stack.Pop();
        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }

    [Fact]
    public void MyStack_Should_ReportIsEmptyAndCountCorrectly()
    {
        MyStack<int> stack = new(10);
        Assert.False(stack.IsEmpty);
        Assert.Equal(1, stack.Count);
        stack.Push(20);
        Assert.Equal(2, stack.Count);
        stack.Pop();
        stack.Pop();
        Assert.True(stack.IsEmpty);
        Assert.Equal(0, stack.Count);
    }
}