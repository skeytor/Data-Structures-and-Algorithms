using LinkedLists.Singly;

namespace UnitTests.LinkedLists;

public class MySinglyLinkedListTests
{
    [Fact]
    public void MySinglyLinkedList_Should_AddNodeAtHead_When_AddFirstCalled()
    {
        MySinglyLinkedList<int> list = new();
        Node<int> node = list.AddFirst(10);
        Assert.Equal(1, list.Count);
        Assert.Equal(10, node.Value);
        Node<int> node2 = list.AddFirst(20);
        Assert.Equal(2, list.Count);
        Assert.Equal(20, node2.Value);
        Assert.Equal("[ 20 ] -> [ 10 ] -> NULL", list.ToString());
    }

    [Fact]
    public void MySinglyLinkedList_Should_AddNodeAtTail_When_AddLastCalled()
    {
        MySinglyLinkedList<string> list = new();
        Node<string> node = list.AddLast("a");
        Assert.Equal(1, list.Count);
        Assert.Equal("a", node.Value);
        Node<string> node2 = list.AddLast("b");
        Assert.Equal(2, list.Count);
        Assert.Equal("b", node2.Value);
        Assert.Equal("[ a ] -> [ b ] -> NULL", list.ToString());
    }

    [Fact]
    public void MySinglyLinkedList_Should_IncrementCount_When_NodesAdded()
    {
        MySinglyLinkedList<int> list = new();
        list.AddFirst(1);
        list.AddLast(2);
        list.AddFirst(3);
        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void MySinglyLinkedList_Should_RemoveHeadAndReturnValue_When_RemoveFirstCalled()
    {
        MySinglyLinkedList<int> list = new();
        list.AddLast(1);
        list.AddLast(2);
        int removed = list.RemoveFirst();
        Assert.Equal(2, removed);
        Assert.Equal(1, list.Count);
        Assert.Equal("[ 2 ] -> NULL", list.ToString());
    }

    [Fact]
    public void MySinglyLinkedList_Should_ThrowInvalidOperationException_When_RemoveFirstOnEmpty()
    {
        MySinglyLinkedList<int> list = new();
        Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
    }

    [Fact]
    public void MySinglyLinkedList_Should_RemoveTailAndReturnValue_When_RemoveLastCalled()
    {
        MySinglyLinkedList<int> list = new();
        list.AddLast(1);
        list.AddLast(2);
        int removed = list.RemoveLast();
        Assert.Equal(2, removed);
        Assert.Equal(1, list.Count);
        Assert.Equal("[ 1 ] -> NULL", list.ToString());
    }

    [Fact]
    public void MySinglyLinkedList_Should_ThrowInvalidOperationException_When_RemoveLastOnEmpty()
    {
        MySinglyLinkedList<int> list = new();
        Assert.Throws<InvalidOperationException>(() => list.RemoveLast());
    }

    [Fact]
    public void MySinglyLinkedList_Should_RemoveFirstOccurrence_When_ValueExists()
    {
        MySinglyLinkedList<int> list = new();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        bool removed = list.Remove(2);
        Assert.True(removed);
        Assert.Equal(2, list.Count);
        Assert.Equal("[ 1 ] -> [ 3 ] -> NULL", list.ToString());
    }

    [Fact]
    public void MySinglyLinkedList_Should_ReturnFalse_When_ValueNotFound()
    {
        MySinglyLinkedList<int> list = new();
        list.AddLast(1);
        list.AddLast(2);
        bool removed = list.Remove(3);
        Assert.False(removed);
        Assert.Equal(2, list.Count);
    }

    [Fact]
    public void MySinglyLinkedList_Should_RemoveHead_When_ValueIsAtHead()
    {
        MySinglyLinkedList<int> list = new();
        list.AddLast(1);
        list.AddLast(2);
        bool removed = list.Remove(1);
        Assert.True(removed);
        Assert.Equal(1, list.Count);
        Assert.Equal("[ 2 ] -> NULL", list.ToString());
    }

    [Fact]
    public void MySinglyLinkedList_Should_RemoveTail_When_ValueIsAtTail()
    {
        MySinglyLinkedList<int> list = new();
        list.AddLast(1);
        list.AddLast(2);
        bool removed = list.Remove(2);
        Assert.True(removed);
        Assert.Equal(1, list.Count);
        Assert.Equal("[ 1 ] -> NULL", list.ToString());
    }

    [Fact]
    public void MySinglyLinkedList_Should_ClearAllNodes_When_ClearCalled()
    {
        MySinglyLinkedList<int> list = new();
        list.AddLast(1);
        list.AddLast(2);
        list.Clear();
        Assert.Equal(0, list.Count);
        Assert.True(list.IsEmpty);
        Assert.Equal("[]", list.ToString());
    }

    [Fact]
    public void MySinglyLinkedList_Should_ReturnTrue_When_ListIsEmpty()
    {
        MySinglyLinkedList<int> list = new();
        Assert.True(list.IsEmpty);
        list.AddLast(1);
        Assert.False(list.IsEmpty);
        list.Clear();
        Assert.True(list.IsEmpty);
    }

    [Fact]
    public void MySinglyLinkedList_Should_ReturnCorrectStringRepresentation_When_Called()
    {
        MySinglyLinkedList<int> list = new();
        Assert.Equal("[]", list.ToString());
        list.AddLast(1);
        list.AddLast(2);
        Assert.Equal("[ 1 ] -> [ 2 ] -> NULL", list.ToString());
    }
}
