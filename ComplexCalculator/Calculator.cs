namespace ComplexCalculator;

public class Calculator(INumberStack stack, IComplexNumberConverter converter)
{
    private readonly IComplexNumberConverter
        converter = converter ?? throw new ArgumentNullException(nameof(converter));

    private readonly INumberStack stack = stack ?? throw new ArgumentNullException(nameof(stack));

    public void Add()
    {
        if (stack.Count < 2)
        {
            return;
        }

        var first = stack.Pop();
        var second = stack.Pop();
        stack.Push(first + second);
    }

    public void Sub()
    {
        if (stack.Count < 2)
        {
            return;
        }

        var first = stack.Pop();
        var second = stack.Pop();
        stack.Push(first - second);
    }

    public void Enter(string number)
    {
        var complexNumber = converter.FromString(number);
        stack.Push(complexNumber);
    }
}