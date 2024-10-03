using FluentAssertions;
using Moq;

namespace TimeDependent;

public class GreeterTests
{
    [Fact]
    public void Should_Compile()
    {
        var greeter = new Greeter(Mock.Of<ITimeTeller>(), Mock.Of<IMessageTemplater>());
        greeter.Should().NotBeNull();
    }
    
    [Fact]
    public void Ctor_GivenNullTimeTeller_ThrowsArgumentNullException()
    {
        // ReSharper disable once ObjectCreationAsStatement
        Action constructing = () => new Greeter(null!, Mock.Of<IMessageTemplater>());
        constructing.Should().Throw<ArgumentNullException>().WithParameterName("timeTeller");
    }
    
    [Fact]
    public void Ctor_GivenNullMessageTemplater_ThrowsArgumentNullException()
    {
        // ReSharper disable once ObjectCreationAsStatement
        Action constructing = () => new Greeter(Mock.Of<ITimeTeller>(), null!);
        constructing.Should().Throw<ArgumentNullException>().WithParameterName("messageTemplater");
    }
}