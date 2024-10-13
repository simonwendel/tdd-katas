using FluentAssertions;

namespace ComplexCalculator;

public class ComplexNumberConverterTests
{
    private readonly ComplexNumberConverter sut = new();

    [Fact]
    public void FromString_GivenNullNumber_ThrowsException()
    {
        Action converting = () => sut.FromString(null!);
        converting.Should().Throw<ArgumentNullException>().WithParameterName("number");
    }

    [Theory]
    [InlineData("3 + 2.5i + 5 + 6i")]
    [InlineData("3 + 2.5 + 6i")]
    [InlineData("3 + 5i + 6i")]
    [InlineData("3i + 2.5i")]
    [InlineData("abc")]
    [InlineData("3.6 ++ i2")]
    [InlineData("3..6+i2")]
    [InlineData("0.0.0+i2")]
    [InlineData("0+2..0i")]
    [InlineData("2.5ii")]
    [InlineData("ii2.5")]
    [InlineData($"\r\n")]
    [InlineData($"\n")]
    [InlineData("   ")]
    [InlineData("")]
    public void FromString_GivenInvalidStringRepresentationOfNumber_ThrowsException(string number)
    {
        Action converting = () => sut.FromString(number);
#pragma warning disable CA1507
        converting.Should().Throw<ArgumentException>().WithParameterName("number");
#pragma warning restore CA1507
    }

    [Theory]
    [InlineData("3 + 2.5i", 3, 2.5)]
    [InlineData(" 3+2.5i", 3, 2.5)]
    [InlineData("2.5i ", 0, 2.5)]
    [InlineData("i", 0, 1)]
    [InlineData(" 3", 3, 0)]
    [InlineData("3 +   2.5i\r\n", 3, 2.5)]
    [InlineData("3 + 2.5i\n", 3, 2.5)]
    public void FromString_GivenValidStringRepresentationOfNumber_ReturnsNumber(string number, double re, double im)
    {
        sut.FromString(number).Should().Be(new ComplexNumber(re, im));
    }
}