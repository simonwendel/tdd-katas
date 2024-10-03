using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;

namespace TimeDependent;

public class GreeterTests
{
    private readonly Mock<ITimeTeller> timeTeller;
    private readonly Mock<IMessageTemplater> messageTemplater;
    private readonly Greeter sut;

    public GreeterTests()
    {
        timeTeller = new Mock<ITimeTeller>();
        timeTeller.Setup(t => t.GetTimeOfDay()).Returns(TimeOfDay.Morning);

        messageTemplater = new Mock<IMessageTemplater>();
        messageTemplater.Setup(m => m.GetGreetingTemplate(TimeOfDay.Morning)).Returns("Good morning, {0}!");

        sut = new Greeter(timeTeller.Object, messageTemplater.Object);
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

    [Theory, AutoData]
    public void Greet_GivenName_RetrievesTimeOfDay(string name)
    {
        sut.Greet(name);
        timeTeller.VerifyAll();
    }

    [Theory, AutoData]
    public void Greet_WhenTimeOfDayRetrieved_RetrievesGreetingTemplate(string name)
    {
        sut.Greet(name);
        messageTemplater.VerifyAll();
    }

    [Fact]
    public void Greet_GivenName_ReturnsPersonalizedGreeting()
    {
        var greeting = sut.Greet("Demerzel");
        greeting.Should().Be("Good morning, Demerzel!");
    }
}