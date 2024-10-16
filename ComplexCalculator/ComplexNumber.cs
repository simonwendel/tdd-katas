﻿using System.Globalization;

namespace ComplexCalculator;

public class ComplexNumber(double re, double im) : IEquatable<ComplexNumber>
{
    private const int NumberOfDecimals = 7;

    public double Re => double.Round(re, NumberOfDecimals);

    public double Im => double.Round(im, NumberOfDecimals);

    public static double Epsilon => Math.Pow(10, -NumberOfDecimals);

    public bool Equals(ComplexNumber? other)
    {
        if (other is null) return false;

        if (ReferenceEquals(this, other)) return true;

        return Math.Abs(Re - other.Re) < Epsilon
               && Math.Abs(Im - other.Im) < Epsilon;
    }

    public override string ToString()
    {
        var reString = Re.ToString(CultureInfo.InvariantCulture);
        var imString = Im.ToString(CultureInfo.InvariantCulture);
        return $"{reString} + {imString}i";
    }

    public static ComplexNumber operator +(ComplexNumber first, ComplexNumber second)
    {
        var re = first.Re + second.Re;
        var im = first.Im + second.Im;
        return new ComplexNumber(re, im);
    }

    public static ComplexNumber operator -(ComplexNumber first, ComplexNumber second)
    {
        var re = first.Re - second.Re;
        var im = first.Im - second.Im;
        return new ComplexNumber(re, im);
    }

    public static bool operator ==(ComplexNumber? left, ComplexNumber? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(ComplexNumber? left, ComplexNumber? right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        return obj.GetType() == GetType() && Equals((ComplexNumber)obj);
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