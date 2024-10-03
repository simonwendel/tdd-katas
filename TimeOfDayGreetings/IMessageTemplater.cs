namespace TimeOfDayGreetings;

public interface IMessageTemplater
{
    string GetGreetingTemplate(TimeOfDay timeOfDay);
}