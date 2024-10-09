namespace ComplexCalculator;

public class Calculator
{
    public ComplexNumber Add(ComplexNumber first, ComplexNumber second)
    {
        var re = first.Re + second.Re;
        var im = first.Im + second.Im;
        return new ComplexNumber(re, im);
    }

    public ComplexNumber Sub(ComplexNumber first, ComplexNumber second)
    {
        var re = first.Re - second.Re;
        var im = first.Im - second.Im;
        return new ComplexNumber(re, im);
    }
}