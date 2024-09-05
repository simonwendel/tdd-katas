using FluentAssertions;
using Moq;

namespace FizzBuzz;

public class FizzBuzzerTests
{
    private readonly Mock<IArbiter> arbiter;
    private readonly FizzBuzzer sut;

    public FizzBuzzerTests()
    {
        arbiter = new Mock<IArbiter>();
        sut = new FizzBuzzer(arbiter.Object);
    }

    [Fact]
    public void Should_BeConstructable()
    {
        sut.Should().NotBeNull();
    }

    [Fact]
    public void Constructor_GivenNullArbiter_ShouldThrowExceptionWithParameterName()
    {
        // ReSharper disable once ObjectCreationAsStatement
        Action constructing = () => new FizzBuzzer(null!);
        constructing.Should().Throw<ArgumentNullException>().WithParameterName("arbiter");
    }

    [Fact]
    public void FizzBuzz_WhenArbiterIsProvided_UsesArbiter()
    {
        sut.FizzBuzz(100);
        arbiter.Verify(a => a.Decide(It.IsAny<int>()), Times.Exactly(100));
    }

    [Fact]
    public void FizzBuzz_WhenArbiterIsProvided_ReturnsFromArbiter()
    {
        var expected = new[] { "1", "2", "Fizz", "4", "Buzz" };
        
        var sequence = new MockSequence();
        arbiter.InSequence(sequence).Setup(a => a.Decide(1)).Returns("1");
        arbiter.InSequence(sequence).Setup(a => a.Decide(2)).Returns("2");
        arbiter.InSequence(sequence).Setup(a => a.Decide(3)).Returns("Fizz");
        arbiter.InSequence(sequence).Setup(a => a.Decide(4)).Returns("4");
        arbiter.InSequence(sequence).Setup(a => a.Decide(5)).Returns("Buzz");
        
        sut.FizzBuzz(5).Should().BeEquivalentTo(expected);
        
        arbiter.VerifyAll();
    }
}