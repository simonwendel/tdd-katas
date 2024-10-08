using FluentAssertions;

namespace ComplexCalculator;

public class ComplexTests
{
    [Fact]
    public void PlusOperator_WhenCalled_ReturnsComplexNumberWithSumOfRealAndImaginaryParts()
    {
        var first = new Complex(3, 2.5);
        var second = new Complex(1.5, 3.05);
        var result = first + second;
        result.Re.Should().BeApproximately(4.5, Complex.Epsilon);
        result.Im.Should().BeApproximately(5.55, Complex.Epsilon);
    }
    
    [Fact]
    public void MinusOperator_WhenCalled_ReturnsComplexNumberWithDiffOfRealAndImaginaryParts()
    {
        var first = new Complex(3, 2.5);
        var second = new Complex(1.5, 3.05);
        var result = first - second;
        result.Re.Should().BeApproximately(1.5, Complex.Epsilon);
        result.Im.Should().BeApproximately(-0.55, Complex.Epsilon);
    }
    
    [Fact]
    public void EqualsOperator_WhenCalled_ReturnsTrueIfRealAndImaginaryPartsAreEqual()
    {
        var first = new Complex(3, 2.5);
        var second = new Complex(3, 2.5);
        (first == second).Should().BeTrue();
    }
    
    [Fact]
    public void EqualsOperator_WhenCalled_ReturnsTrueIfSameComplexNumberReference()
    {
        var first = new Complex(3, 2.5);
        // ReSharper disable once EqualExpressionComparison 
#pragma warning disable CS1718
        (first == first).Should().BeTrue();
#pragma warning restore CS1718
    }
    
    [Fact]
    public void EqualsOperator_WhenCalled_ReturnsFalseIfRealAndImaginaryPartsAreNotEqual()
    {
        var first = new Complex(3, 2.5);
        (first == new Complex(3.5, 2.5)).Should().BeFalse();
        (first == new Complex(3, 2)).Should().BeFalse();
        (first == new Complex(3.5, 3)).Should().BeFalse();
    }
    
    [Fact]
    public void EqualsOperator_WhenCalled_ReturnsFalseIfNotObjectOfCorrectType()
    {
        var first = new Complex(3, 2.5);
#pragma warning disable CS0252, CS0253
        (first == new object()).Should().BeFalse();
#pragma warning restore CS0252, CS0253
        (first == null!).Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_WhenCalled_ReturnsFalseIfRealAndImaginaryPartsAreEqual()
    {
        var first = new Complex(3, 2.5);
        var second = new Complex(3, 2.5);
        (first != second).Should().BeFalse();
    }
    
    [Fact]
    public void NotEqualsOperator_WhenCalled_ReturnsFalseIfSameComplexNumberReference()
    {
        var first = new Complex(3, 2.5);
        // ReSharper disable once EqualExpressionComparison
#pragma warning disable CS1718
        (first != first).Should().BeFalse();
#pragma warning restore CS1718
    }
    
    [Fact]
    public void NotEqualsOperator_WhenCalled_ReturnsTrueIfRealAndImaginaryPartsAreNotEqual()
    {
        var first = new Complex(3, 2.5);
        (first != new Complex(3.5, 2.5)).Should().BeTrue();
        (first != new Complex(3, 2)).Should().BeTrue();
        (first != new Complex(3.5, 3)).Should().BeTrue();
    }
    
    [Fact]
    public void NotEqualsOperator_WhenCalled_ReturnsTrueIfNotObjectOfCorrectType()
    {
        var first = new Complex(3, 2.5);
#pragma warning disable CS0252, CS0253
        (first != new object()).Should().BeTrue();
#pragma warning restore CS0252, CS0253
        (first != null!).Should().BeTrue();
    }
    
    [Fact]
    public void EpsilonGetter_ReturnsSevenDecimalPrecision()
    {
        Complex.Epsilon.Should().Be(0.0000001);
    }
    
    [Fact]
    public void ReGetter_WhenRealPartSet_ReturnsRealPart()
    {
        var sut = new Complex(12.5, 3.5);
        sut.Re.Should().Be(12.5);
    }

    [Fact]
    public void ImGetter_WhenImaginaryPartSet_ReturnsImaginaryPart()
    {
        var sut = new Complex(12.5, 3.5);
        sut.Im.Should().Be(3.5);
    }

    [Fact]
    public void ToString_WhenRealAndImaginaryPartZero_ReturnsStringRepresentation()
    {
        var sut = new Complex(0, 0);
        sut.ToString().Should().Be("0 + 0i");
    }

    [Fact]
    public void ToString_WhenRealAndImaginaryPartSet_ReturnsStringRepresentation()
    {
        var sut = new Complex(12.5, 3.5);
        sut.ToString().Should().Be("12.5 + 3.5i");
    }

    [Fact]
    public void GetHashCode_ReturnsFabulousHashCode()
    {
        var sut = new Complex(12.5, 3.5);
        sut.GetHashCode().Should().Be(62595873);
    }
}