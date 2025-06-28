using LinkedLists.Double;

namespace UnitTests.LinkedLists;

public class MyDoubleLinkedListTests
{
    [Fact]
    public void MyDoubleLinkedList_Should_AddNodeAtTail_When_AddLastCalled()
    {
        MyDoubleLinkedList<int> list = new();
        list.AddLast(1);
        list.AddLast(2);
        Assert.Equal(2, list.Count);
        Assert.Equal(1, list.First!.Value);
        Assert.Equal(2, list.Last!.Value);
        Assert.Equal("[1 <-> 2 <-> null]", list.ToString().Replace(" ", ""));
    }

    [Fact]
    public void MyDoubleLinkedList_Should_AddNodeAtHead_When_AddFirstCalled()
    {
        MyDoubleLinkedList<string> list = new();
        list.AddFirst("a");
        list.AddFirst("b");
        Assert.Equal(2, list.Count);
        Assert.Equal("b", list.First!.Value);
        Assert.Equal("a", list.Last!.Value);
        Assert.Equal("[b <-> a <-> null]", list.ToString().Replace(" ", ""));
    }

    [Fact]
    public void MyDoubleLinkedList_Should_RemoveHeadAndReturnValue_When_RemoveFirstCalled()
    {
        MyDoubleLinkedList<int> list = new();
        list.AddLast(1);
        list.AddLast(2);
        int removed = list.RemoveFirst();
        Assert.Equal(1, removed);
        Assert.Equal(1, list.Count);
        Assert.Equal(2, list.First!.Value);
    }

    [Fact]
    public void MyDoubleLinkedList_Should_ThrowInvalidOperationException_When_RemoveFirstOnEmpty()
    {
        MyDoubleLinkedList<int> list = new();
        Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
    }

    [Fact]
    public void MyDoubleLinkedList_Should_RemoveTailAndReturnValue_When_RemoveLastCalled()
    {
        MyDoubleLinkedList<int> list = new();
        list.AddLast(1);
        list.AddLast(2);
        int removed = list.RemoveLast();
        Assert.Equal(2, removed);
        Assert.Equal(1, list.Count);
        Assert.Equal(1, list.Last!.Value);
    }

    [Fact]
    public void MyDoubleLinkedList_Should_ThrowInvalidOperationException_When_RemoveLastOnEmpty()
    {
        MyDoubleLinkedList<int> list = new();
        Assert.Throws<InvalidOperationException>(() => list.RemoveLast());
    }

    [Fact]
    public void MyDoubleLinkedList_Should_RemoveFirstOccurrence_When_ValueExists()
    {
        MyDoubleLinkedList<int> list = new();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        bool removed = list.Remove(2);
        Assert.True(removed);
        Assert.Equal(2, list.Count);
        Assert.Equal(1, list.First!.Value);
        Assert.Equal(3, list.Last!.Value);
    }

    [Fact]
    public void MyDoubleLinkedList_Should_ReturnFalse_When_ValueNotFound()
    {
        MyDoubleLinkedList<int> list = new();
        list.AddLast(1);
        list.AddLast(2);
        bool removed = list.Remove(3);
        Assert.False(removed);
        Assert.Equal(2, list.Count);
    }

    [Fact]
    public void MyDoubleLinkedList_Should_RemoveHead_When_ValueIsAtHead()
    {
        MyDoubleLinkedList<int> list = new();
        list.AddLast(1);
        list.AddLast(2);
        bool removed = list.Remove(1);
        Assert.True(removed);
        Assert.Equal(1, list.Count);
        Assert.Equal(2, list.First!.Value);
    }

    [Fact]
    public void MyDoubleLinkedList_Should_RemoveTail_When_ValueIsAtTail()
    {
        MyDoubleLinkedList<int> list = new();
        list.AddLast(1);
        list.AddLast(2);
        bool removed = list.Remove(2);
        Assert.True(removed);
        Assert.Equal(1, list.Count);
        Assert.Equal(1, list.Last!.Value);
    }

    [Fact]
    public void MyDoubleLinkedList_Should_FindNode_When_ValueExists()
    {
        MyDoubleLinkedList<string> list = new();
        list.AddLast("a");
        list.AddLast("b");
        Node<string>? found = list.Find("b");
        Assert.NotNull(found);
        Assert.Equal("b", found.Value);
    }

    [Fact]
    public void MyDoubleLinkedList_Should_ReturnNull_When_ValueNotFound()
    {
        MyDoubleLinkedList<int> list = new();
        list.AddLast(1);
        Node<int>? found = list.Find(2);
        Assert.Null(found);
    }

    [Fact]
    public void MyDoubleLinkedList_Should_AddBeforeNode_When_AddBeforeCalled()
    {
        MyDoubleLinkedList<int> list = new();
        list.AddLast(1);
        list.AddLast(3);
        Node<int>? node = list.Find(3);
        list.AddBefore(node!, 2);
        Assert.Equal(3, list.Count);
        Assert.Equal(2, list.First!.Next!.Value);
    }

    [Fact]
    public void MyDoubleLinkedList_Should_AddAfterNode_When_AddAfterCalled()
    {
        MyDoubleLinkedList<int> list = new();
        list.AddLast(1);
        list.AddLast(2);
        Node<int>? node = list.Find(1);
        list.AddAfter(node!, 5);
        Assert.Equal(3, list.Count);
        Assert.Equal(5, list.First!.Next!.Value);
    }

    [Fact]
    public void MyDoubleLinkedList_Should_ReturnCorrectStringRepresentation_When_Called()
    {
        MyDoubleLinkedList<int> list = new();
        Assert.Equal("[]", list.ToString());
        list.AddLast(1);
        list.AddLast(2);
        Assert.Equal("[1 <-> 2 <-> null]", list.ToString().Replace(" ", ""));
    }
}
