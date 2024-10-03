namespace TimeDependent;

public interface IMessageTemplater
{
    string GetGreetingTemplate(TimeOfDay timeOfDay);
}