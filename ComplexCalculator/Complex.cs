using System.Globalization;

namespace ComplexCalculator;

public class Complex(double re, double im) : IEquatable<Complex>
{
    private const int NumberOfDecimals = 7;
    
    public override string ToString()
    {
        var reString = Re.ToString(CultureInfo.InvariantCulture);
        var imString = Im.ToString(CultureInfo.InvariantCulture);
        return $"{reString} + {imString}i";
    }

    public double Re => double.Round(re, NumberOfDecimals);

    public double Im =>  double.Round(im, NumberOfDecimals);

    public static double Epsilon => Math.Pow(10, -NumberOfDecimals);

    public static Complex operator +(Complex first, Complex second)
    {
        var re = first.Re + second.Re;
        var im = first.Im + second.Im;
        return new Complex(re, im);
    }

    public static Complex operator -(Complex first, Complex second)
    {
        var re = first.Re - second.Re;
        var im = first.Im - second.Im;
        return new Complex(re, im);
    }

    public static bool operator ==(Complex? left, Complex? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(Complex? left, Complex? right)
        => !(left == right);

    public bool Equals(Complex? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Math.Abs(Re - other.Re) < Epsilon
               && Math.Abs(Im - other.Im) < Epsilon;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        return obj.GetType() == GetType() && this.Equals((Complex)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = hash * 23 + Re.GetHashCode();
            hash = hash * 23 + Im.GetHashCode();
            return hash;
        }
    }
}