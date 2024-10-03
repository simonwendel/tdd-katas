using FluentAssertions;
using Moq;

namespace TimeDependent;

public class GreeterTests
{
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
        var timeTeller = new Mock<ITimeTeller>();
        timeTeller.Setup(t => t.GetTimeOfDay()).Returns(TimeOfDay.Morning);

        var sut = new Greeter(timeTeller.Object, Mock.Of<IMessageTemplater>());
        sut.Greet();

        timeTeller.VerifyAll();
    }

    [Fact]
    public void Greet_WhenTimeOfDayRetrieved_RetrievesGreetingTemplate()
    {
        var timeTeller = new Mock<ITimeTeller>();
        timeTeller.Setup(t => t.GetTimeOfDay()).Returns(TimeOfDay.Morning);

        var messageTemplater = new Mock<IMessageTemplater>();
        messageTemplater.Setup(m => m.GetGreetingTemplate(TimeOfDay.Morning)).Returns("Good morning!");

        var sut = new Greeter(timeTeller.Object, messageTemplater.Object);
        sut.Greet();

        messageTemplater.VerifyAll();
    }
}