namespace ComplexCalculator;

public interface INumberStack
{
    void Push(ComplexNumber number);

    ComplexNumber Pop();

    int Count { get; }

    string ToString();
}