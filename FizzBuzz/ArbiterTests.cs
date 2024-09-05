using FluentAssertions;

namespace FizzBuzz;

public class ArbiterTests
{
    private readonly Arbiter sut = new();

    [Fact]
    public void Should_BeConstructable()
    {
        sut.Should().NotBeNull();
    }
    
    [Fact]
    public void Should_ImplementIArbiterInterface()
    {
        sut.Should().BeAssignableTo<IArbiter>();
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-10)]
    public void Decide_GivenValueLessThanOne_ThrowsException(int value)
    {
        var deciding = () => sut.Decide(value);
        deciding.Should().Throw<ArgumentOutOfRangeException>()
            .WithParameterName(nameof(value))
            .WithMessage("Value must be greater than or equal to 1. (Parameter 'value')");
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(4)]
    [InlineData(7)]
    public void Decide_GivenValueNotDivisibleByThreeOrFive_ReturnsValueAsString(int value)
    {
        sut.Decide(value).Should().Be(value.ToString());
    }
    
    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    [InlineData(9)]
    [InlineData(12)]
    public void Decide_GivenValueDivisibleByThreeButNotFive_ReturnsFizz(int value)
    {
        sut.Decide(value).Should().Be("Fizz");
    }
    
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(25)]
    public void Decide_GivenValueDivisibleByFiveButNotThree_ReturnsBuzz(int value)
    {
        sut.Decide(value).Should().Be("Buzz");
    }
    
    [Theory]
    [InlineData(15)]
    [InlineData(30)]
    [InlineData(45)]
    public void Decide_GivenValueDivisibleByThreeAndFive_ReturnsFizzBuzz(int value)
    {
        sut.Decide(value).Should().Be("FizzBuzz");
    }
}
