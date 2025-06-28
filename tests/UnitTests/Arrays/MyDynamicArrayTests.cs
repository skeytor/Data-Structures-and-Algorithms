using Xunit.Abstractions;

namespace UnitTests.Arrays;

public class MyDynamicArrayTests(ITestOutputHelper outputHelper)
{
    [Fact]
    public void Constructor_Should_InitializeWithDefaultCapacity_When_NoArgument()
    {
        MyDynamicArray<int> arr = new();
        arr.Add(1);
        arr.Add(2);
        arr.Add(3);
        outputHelper.WriteLine($"Array: {arr}");
        Assert.Equal(3, arr.Count);
    }
    [Fact]
    public void Constructor_Should_InitializeWithGivenCapacity_When_ArgumentProvided()
    {
        MyDynamicArray<int> arr = new(10);
        Assert.Equal(0, arr.Count);
        arr.Add(5);
        Assert.Equal(1, arr.Count);
    }

    [Fact]
    public void Add_Should_AddElementsAndIncreaseCount_When_AddCalled()
    {
        MyDynamicArray<string> arr = new();
        arr.Add("a");
        arr.Add("b");
        Assert.Equal(2, arr.Count);
        Assert.Equal("a", arr[0]);
        Assert.Equal("b", arr[1]);
    }

    [Fact]
    public void Add_Should_Resize_When_ExceedingCapacity()
    {
        MyDynamicArray<int> arr = new(2);
        arr.Add(1);
        arr.Add(2);
        arr.Add(3); // Should trigger resize
        Assert.Equal(3, arr.Count);
        Assert.Equal(1, arr[0]);
        Assert.Equal(2, arr[1]);
        Assert.Equal(3, arr[2]);
    }

    [Fact]
    public void Index_Should_ReturnElementAtIndex_When_ValidIndex()
    {
        MyDynamicArray<string> arr = new();
        arr.Add("x");
        arr.Add("y");
        Assert.Equal("x", arr[0]);
        Assert.Equal("y", arr[1]);
    }

    [Fact]
    public void Index_Should_ThrowArgumentOutOfRange_When_IndexInvalid()
    {
        MyDynamicArray<int> arr = new();
        arr.Add(1);
        outputHelper.WriteLine($"Array: {arr}");
        Assert.Throws<ArgumentOutOfRangeException>(() => arr[1]);
        Assert.Throws<ArgumentOutOfRangeException>(() => arr[-1]);
        Assert.Throws<ArgumentOutOfRangeException>(() => { arr[0] = 2; });
        Assert.Throws<ArgumentOutOfRangeException>(() => { arr[2] = 3; });
    }

    [Fact]
    public void RemoveAt_Should_RemoveElementAtIndex_AndShiftElements()
    {
        MyDynamicArray<int> arr = new();
        arr.Add(1);
        arr.Add(2);
        arr.Add(3);
        arr.RemoveAt(1);
        Assert.Equal(2, arr.Count);
        Assert.Equal(1, arr[0]);
        Assert.Equal(3, arr[1]);
    }

    [Fact]
    public void RemoveAt_Should_ThrowArgumentOutOfRange_When_IndexInvalid_RemoveAt()
    {
        MyDynamicArray<int> arr = new();
        arr.Add(1);
        Assert.Throws<ArgumentOutOfRangeException>(() => arr.RemoveAt(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => arr.RemoveAt(1));
    }

    [Fact]
    public void Remove_Should_RemoveFirstOccurrence_When_ItemExists()
    {
        MyDynamicArray<string> arr = new();
        arr.Add("a");
        arr.Add("b");
        arr.Add("a");
        bool removed = arr.Remove("a");
        Assert.True(removed);
        Assert.Equal(2, arr.Count);
        Assert.Equal("b", arr[0]);
        Assert.Equal("a", arr[1]);
    }

    [Fact]
    public void Remove_Should_ReturnFalse_When_ItemNotFound()
    {
        MyDynamicArray<int> arr = new();
        arr.Add(1);
        bool removed = arr.Remove(2);
        Assert.False(removed);
        Assert.Equal(1, arr.Count);
    }

    [Fact]
    public void TryFind_Should_ReturnTrueAndResult_When_ItemExists_TryFind()
    {
        MyDynamicArray<string> arr = new();
        arr.Add("foo");
        arr.Add("bar");
        bool found = arr.TryFind("bar", out string? result);
        Assert.True(found);
        Assert.Equal("bar", result);
    }

    [Fact]
    public void TryFind_Should_ReturnFalseAndDefault_When_ItemNotFound_TryFind()
    {
        MyDynamicArray<int> arr = new();
        arr.Add(1);
        bool found = arr.TryFind(2, out int result);
        Assert.False(found);
        Assert.Equal(default, result);
    }

    [Fact]
    public void ToString_Should_ReturnCorrectStringRepresentation_When_Called()
    {
        MyDynamicArray<int> arr = new();
        arr.Add(1);
        arr.Add(2);
        arr.Add(3);
        Assert.Equal("[1, 2, 3]", arr.ToString());
        MyDynamicArray<int> emptyArr = new();
        Assert.Equal("[]", emptyArr.ToString());
    }
}
