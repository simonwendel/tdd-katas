using AutoFixture.Xunit2;
using FluentAssertions;
using System.Linq;

namespace ComplexCalculator;

public class NumberStackTests
{
    [Fact]
    public void Push_GivenNumber_ShouldAddNumberToStack()
    {
        var sut = new NumberStack();
        var number = new ComplexNumber(1, 2);
        sut.Push(number);
        sut.Count.Should().Be(1);
    }
    
    [Fact]
    public void Pop_WhenCalled_ReturnsLastPushedNumber()
    {
        var sut = new NumberStack();
        var last = new ComplexNumber(3.5, 4);
        sut.Push(new ComplexNumber(1, 2));
        sut.Push(last);
        sut.Pop().Should().Be(last);
    }
    
    [Fact]
    public void Pop_WhenCalled_RemovesLastPushedNumberFromStack()
    {
        var sut = new NumberStack();
        sut.Push(new ComplexNumber(1, 2));
        sut.Push(new ComplexNumber(3.5, 4));
        _ = sut.Pop();
        sut.Count.Should().Be(1);
    }
    
    [Theory]
    [AutoData]
    public void Push_GivenMultipleNumbers_AddsNumbersToStack(List<ComplexNumber> numbers)
    {
        var sut = new NumberStack();
        numbers.ForEach(sut.Push);
        sut.Count.Should().Be(numbers.Count);
    }
    
    [Fact]
    public void CountGetter_WhenNewInstance_ShouldReturnZero()
    {
        var sut = new NumberStack();
        sut.Count.Should().Be(0);
    }

    [Theory]
    [AutoData]
    public void Equals_GivenSameNumbersPushedInOrder_ReturnsTrue(List<ComplexNumber> numbers)
    {
        var first = new NumberStack();
        numbers.ForEach(first.Push);
        
        var second = new NumberStack();
        numbers.ForEach(second.Push);
        
        first.Equals(second).Should().BeTrue();
    }

    [Fact]
    public void Equals_GivenSameReference_ReturnsTrue()
    {
        var first = new NumberStack();
        // ReSharper disable once EqualExpressionComparison 
#pragma warning disable CS1718
        first.Equals(first).Should().BeTrue();
#pragma warning restore CS1718
    }
    
    [Fact]
    public void ToString_WhenNumbersArePushed_ReturnsStringRepresentationOfStack()
    {
        var sut = new NumberStack();
        sut.Push(new ComplexNumber(1, 2));
        sut.Push(new ComplexNumber(3.5, 4));
        sut.ToString().Should().Be($"1 + 2i{Environment.NewLine}3.5 + 4i");
    }

    [Theory]
    [AutoData]
    public void Equals_GivenThatNotSameNumbersPushedOrOutOfOrder_ReturnsFalse(List<ComplexNumber> numbers)
    {
        var first = new NumberStack();
        numbers.ForEach(first.Push);
        
        var second = new NumberStack();
        numbers.ForEach(n => second.Push(new ComplexNumber(n.Re + 1, n.Im + 1)));
        
        var third = new NumberStack();
        Enumerable.Reverse(numbers).ToList().ForEach(third.Push);
        
        first.Equals(second).Should().BeFalse();
    }

    [Fact]
    public void Equals_GivenObjectOfWrongType_ReturnsFalse()
    {
        var first = new NumberStack();
#pragma warning disable CS0252, CS0253
        first.Equals(new object()).Should().BeFalse();
#pragma warning restore CS0252, CS0253
    }

    [Fact]
    public void Equals_GivenNull_ReturnsFalse()
    {
        var first = new NumberStack();
        first.Equals(null).Should().BeFalse();
    }
    
    [Fact]
    public void GetHashCode_ReturnsFabulousHashCode()
    {
        var sut = new NumberStack();
        sut.Push(new ComplexNumber(12.5, 3.5));
        sut.Push(new ComplexNumber(5, 7));
        sut.GetHashCode().Should().Be(798387769);
    }
}