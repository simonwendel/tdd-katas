namespace ComplexCalculator;

public interface IComplexNumberConverter
{
    ComplexNumber FromString(string number);
}