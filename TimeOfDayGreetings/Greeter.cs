namespace TimeOfDayGreetings;

public class Greeter(ITimeTeller timeTeller, IMessageTemplater messageTemplater)
{
    private readonly ITimeTeller timeTeller =
        timeTeller ?? throw new ArgumentNullException(nameof(timeTeller));

    private readonly IMessageTemplater messageTemplater =
        messageTemplater ?? throw new ArgumentNullException(nameof(messageTemplater));

    public string Greet(string name)
    {
        var timeOfDay = timeTeller.GetTimeOfDay();
        var template = messageTemplater.GetGreetingTemplate(timeOfDay);
        return string.Format(template, name);
    }
}
