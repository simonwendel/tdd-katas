using FluentAssertions;

namespace ComplexCalculator;

public class ComplexNumberTests
{
    [Fact]
    public void PlusOperator_WhenCalled_ReturnsComplexNumberWithSumOfRealAndImaginaryParts()
    {
        var first = new ComplexNumber(3, 2.5);
        var second = new ComplexNumber(1.5, 3.05);
        var result = first + second;
        result.Re.Should().BeApproximately(4.5, ComplexNumber.Epsilon);
        result.Im.Should().BeApproximately(5.55, ComplexNumber.Epsilon);
    }

    [Fact]
    public void MinusOperator_WhenCalled_ReturnsComplexNumberWithDiffOfRealAndImaginaryParts()
    {
        var first = new ComplexNumber(3, 2.5);
        var second = new ComplexNumber(1.5, 3.05);
        var result = first - second;
        result.Re.Should().BeApproximately(1.5, ComplexNumber.Epsilon);
        result.Im.Should().BeApproximately(-0.55, ComplexNumber.Epsilon);
    }

    [Fact]
    public void EpsilonGetter_ReturnsSevenDecimalPrecision()
    {
        ComplexNumber.Epsilon.Should().Be(0.0000001);
    }

    [Fact]
    public void ReGetter_WhenRealPartSet_ReturnsRealPart()
    {
        var sut = new ComplexNumber(12.5, 3.5);
        sut.Re.Should().Be(12.5);
    }

    [Fact]
    public void ImGetter_WhenImaginaryPartSet_ReturnsImaginaryPart()
    {
        var sut = new ComplexNumber(12.5, 3.5);
        sut.Im.Should().Be(3.5);
    }

    [Fact]
    public void ToString_WhenRealAndImaginaryPartZero_ReturnsStringRepresentation()
    {
        var sut = new ComplexNumber(0, 0);
        sut.ToString().Should().Be("0 + 0i");
    }

    [Fact]
    public void ToString_WhenRealAndImaginaryPartSet_ReturnsStringRepresentation()
    {
        var sut = new ComplexNumber(12.5, 3.5);
        sut.ToString().Should().Be("12.5 + 3.5i");
    }

    [Fact]
    public void EqualsOperator_GivenReAndImPartsEqual_ReturnsTrue()
    {
        var first = new ComplexNumber(3, 2.5);
        var second = new ComplexNumber(3, 2.5);
        (first == second).Should().BeTrue();
    }

    [Fact]
    public void EqualsOperator_GivenSameReference_ReturnsTrue()
    {
        var first = new ComplexNumber(3, 2.5);
        // ReSharper disable once EqualExpressionComparison 
#pragma warning disable CS1718
        (first == first).Should().BeTrue();
#pragma warning restore CS1718
    }

    [Fact]
    public void EqualsOperator_GivenThatReAndImPartsNotEqual_ReturnsFalse()
    {
        var first = new ComplexNumber(3, 2.5);
        (first == new ComplexNumber(3.5, 2.5)).Should().BeFalse();
        (first == new ComplexNumber(3, 2)).Should().BeFalse();
        (first == new ComplexNumber(3.5, 3)).Should().BeFalse();
    }

    [Fact]
    public void EqualsOperator_GivenObjectOfWrongType_ReturnsFalse()
    {
        var first = new ComplexNumber(3, 2.5);
#pragma warning disable CS0252, CS0253
        (first == new object()).Should().BeFalse();
#pragma warning restore CS0252, CS0253
    }

    [Fact]
    public void EqualsOperator_GivenNull_ReturnsFalse()
    {
        var first = new ComplexNumber(3, 2.5);
        (first == null!).Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_GivenReAndImPartsEqual_ReturnsFalse()
    {
        var first = new ComplexNumber(3, 2.5);
        var second = new ComplexNumber(3, 2.5);
        (first != second).Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_GivenSameReference_ReturnsFalse()
    {
        var first = new ComplexNumber(3, 2.5);
        // ReSharper disable once EqualExpressionComparison
#pragma warning disable CS1718
        (first != first).Should().BeFalse();
#pragma warning restore CS1718
    }

    [Fact]
    public void NotEqualsOperator_GivenThatReAndImPartsNotEqual_ReturnsTrue()
    {
        var first = new ComplexNumber(3, 2.5);
        (first != new ComplexNumber(3.5, 2.5)).Should().BeTrue();
        (first != new ComplexNumber(3, 2)).Should().BeTrue();
        (first != new ComplexNumber(3.5, 3)).Should().BeTrue();
    }

    [Fact]
    public void NotEqualsOperator_GivenObjectOfWrongType_ReturnsTrue()
    {
        var first = new ComplexNumber(3, 2.5);
#pragma warning disable CS0252, CS0253
        (first != new object()).Should().BeTrue();
#pragma warning restore CS0252, CS0253
    }

    [Fact]
    public void NotEqualsOperator_GivenNull_ReturnsTrue()
    {
        var first = new ComplexNumber(3, 2.5);
        (first != null!).Should().BeTrue();
    }

    [Fact]
    public void Equals_GivenReAndImPartsEqual_ReturnsTrue()
    {
        var first = new ComplexNumber(3, 2.5);
        var second = new ComplexNumber(3, 2.5);
        first.Equals(second).Should().BeTrue();
    }

    [Fact]
    public void Equals_GivenSameReference_ReturnsTrue()
    {
        var first = new ComplexNumber(3, 2.5);
        // ReSharper disable once EqualExpressionComparison 
#pragma warning disable CS1718
        first.Equals(first).Should().BeTrue();
#pragma warning restore CS1718
    }

    [Fact]
    public void Equals_GivenThatReAndImPartsNotEqual_ReturnsFalse()
    {
        var first = new ComplexNumber(3, 2.5);
        first.Equals(new ComplexNumber(3.5, 2.5)).Should().BeFalse();
        first.Equals(new ComplexNumber(3, 2)).Should().BeFalse();
        first.Equals(new ComplexNumber(3.5, 3)).Should().BeFalse();
    }

    [Fact]
    public void Equals_GivenObjectOfWrongType_ReturnsFalse()
    {
        var first = new ComplexNumber(3, 2.5);
#pragma warning disable CS0252, CS0253
        first.Equals(new object()).Should().BeFalse();
#pragma warning restore CS0252, CS0253
    }

    [Fact]
    public void Equals_GivenNull_ReturnsFalse()
    {
        var first = new ComplexNumber(3, 2.5);
        first.Equals(null).Should().BeFalse();
    }

    [Fact]
    public void GetHashCode_ReturnsFabulousHashCode()
    {
        var sut = new ComplexNumber(12.5, 3.5);
        sut.GetHashCode().Should().Be(62595873);
    }
}