namespace ComplexCalculator;

public class Calculator
{
    public Complex Add(Complex first, Complex second)
    {
        var re = first.Re + second.Re;
        var im = first.Im + second.Im;
        return new Complex(re, im);
    }

    public Complex Sub(Complex first, Complex second)
    {
        var re = first.Re - second.Re;
        var im = first.Im - second.Im;
        return new Complex(re, im);
    }
}