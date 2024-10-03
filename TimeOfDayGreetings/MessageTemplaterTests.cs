using FluentAssertions;

namespace TimeOfDayGreetings;

public class MessageTemplaterTests
{
    private readonly MessageTemplater sut = new();

    [Fact]
    public void GetGreetingTemplate_GivenMorning_ReturnsMorningTemplate() =>
        sut.GetGreetingTemplate(TimeOfDay.Morning).Should().Be("Good morning, {0}!");

    [Fact]
    public void GetGreetingTemplate_GivenAfternoon_ReturnsAfternoonTemplate() =>
        sut.GetGreetingTemplate(TimeOfDay.Afternoon).Should().Be("Good afternoon, {0}!");

    [Fact]
    public void GetGreetingTemplate_GivenEvening_ReturnsEveningTemplate() =>
        sut.GetGreetingTemplate(TimeOfDay.Evening).Should().Be("Good evening, {0}!");

    [Fact]
    public void GetGreetingTemplate_GivenNight_ReturnsNightTemplate() =>
        sut.GetGreetingTemplate(TimeOfDay.Night).Should().Be("Good night, {0}!");
}