namespace TimeDependent;

public class Greeter(ITimeTeller timeTeller, IMessageTemplater messageTemplater)
{
    private readonly ITimeTeller timeTeller =
        timeTeller ?? throw new ArgumentNullException(nameof(timeTeller));

    private readonly IMessageTemplater messageTemplater =
        messageTemplater ?? throw new ArgumentNullException(nameof(messageTemplater));

    public void Greet()
    {
        var timeOfDay = timeTeller.GetTimeOfDay();
        messageTemplater.GetGreetingTemplate(timeOfDay);
    }
}