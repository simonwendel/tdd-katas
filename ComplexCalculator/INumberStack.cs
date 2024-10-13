namespace ComplexCalculator;

public interface INumberStack
{
    int Count { get; }
    void Push(ComplexNumber number);
    ComplexNumber Pop();
    string ToString();
}