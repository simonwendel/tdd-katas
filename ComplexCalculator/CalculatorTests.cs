using FluentAssertions;

namespace ComplexCalculator;

public class CalculatorTests
{
    private readonly Calculator sut = new();
    private readonly ComplexNumber first = new(3, 2.5);
    private readonly ComplexNumber second = new(1.5, 3.05);

    [Fact]
    public void Add_GivenTwoComplexNumbers_ReturnsSumOfComplexNumbers()
        => sut.Add(first, second).Should().Be(first + second);

    [Fact]
    public void Sub_GivenTwoComplexNumbers_ReturnsDiffOfComplexNumbers()
        => sut.Sub(first, second).Should().Be(first - second);

    [Fact]
    public void Add_GivenTwoComplexNumbers_ReturnsNumberWithImAsSumOfImParts()
        => sut.Add(first, second).Im.Should().BeApproximately(5.55, ComplexNumber.Epsilon);

    [Fact]
    public void Add_GivenTwoComplexNumbers_ReturnsNumberWithReAsSumOfReParts()
        => sut.Add(first, second).Re.Should().BeApproximately(4.5, ComplexNumber.Epsilon);

    [Fact]
    public void Sub_GivenTwoComplexNumbers_ReturnsNumberWithImAsDiffOfImParts()
        => sut.Sub(first, second).Im.Should().BeApproximately(-0.55, ComplexNumber.Epsilon);

    [Fact]
    public void Sub_GivenTwoComplexNumbers_ReturnsNumberWithReAsDiffOfReParts()
        => sut.Sub(first, second).Re.Should().BeApproximately(1.5, ComplexNumber.Epsilon);
}