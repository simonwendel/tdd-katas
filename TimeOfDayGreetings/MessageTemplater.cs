namespace TimeOfDayGreetings;

public class MessageTemplater : IMessageTemplater
{
    private static readonly Dictionary<TimeOfDay, string> Templates = new()
    {
        { TimeOfDay.Morning, "Good morning, {0}!" },
        { TimeOfDay.Afternoon, "Good afternoon, {0}!" },
        { TimeOfDay.Evening, "Good evening, {0}!" },
        { TimeOfDay.Night, "Good night, {0}!" }
    };

    public string GetGreetingTemplate(TimeOfDay timeOfDay) => Templates[timeOfDay];
}