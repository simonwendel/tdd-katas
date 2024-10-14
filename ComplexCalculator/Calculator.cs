namespace ComplexCalculator;

public class Calculator(INumberStack stack, IComplexNumberConverter converter)
{
    private readonly IComplexNumberConverter
        converter = converter ?? throw new ArgumentNullException(nameof(converter));

    private readonly INumberStack
        stack = stack ?? throw new ArgumentNullException(nameof(stack));

    public void Enter(string number)
    {
        var complexNumber = converter.FromString(number);
        stack.Push(complexNumber);
    }

    public void Add() => ApplyBinary((c1, c2) => c1 + c2);

    public void Sub() => ApplyBinary((c1, c2) => c1 - c2);

    public object Display() => stack.ToString();

    private void ApplyBinary(Func<ComplexNumber, ComplexNumber, ComplexNumber> operation)
    {
        if (stack.Count < 2)
        {
            return;
        }

        var first = stack.Pop();
        var second = stack.Pop();
        stack.Push(operation(first, second));
    }
}