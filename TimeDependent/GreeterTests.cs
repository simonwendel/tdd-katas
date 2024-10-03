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
        messageTemplater = new Mock<IMessageTemplater>();
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

    [Fact]
    public void Greet_GivenName_RetrievesTimeOfDay()
    {
        timeTeller.Setup(t => t.GetTimeOfDay()).Returns(TimeOfDay.Morning);
        sut.Greet();
        timeTeller.VerifyAll();
    }

    [Fact]
    public void Greet_WhenTimeOfDayRetrieved_RetrievesGreetingTemplate()
    {
        timeTeller.Setup(t => t.GetTimeOfDay()).Returns(TimeOfDay.Morning);
        messageTemplater.Setup(m => m.GetGreetingTemplate(TimeOfDay.Morning)).Returns("Good morning!");
        sut.Greet();
        messageTemplater.VerifyAll();
    }
}