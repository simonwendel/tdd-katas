namespace FizzBuzz;

public class Arbiter : IArbiter
{
    public string Decide(int value)
    {
        if (value < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be greater than or equal to 1.");
        }
        
        var result = value % 3 == 0 ? "Fizz" : string.Empty;
        result = value % 5 == 0 ? $"{result}Buzz" : result;
        return string.IsNullOrEmpty(result) ? value.ToString() : result;
    }
}
