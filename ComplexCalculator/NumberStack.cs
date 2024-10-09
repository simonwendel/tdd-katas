using System.Text;

namespace ComplexCalculator;

public class NumberStack : IEquatable<NumberStack>
{
    private readonly Stack<ComplexNumber> stack = new();

    public int Count => stack.Count;

    public void Push(ComplexNumber number) => stack.Push(number);

    public ComplexNumber Pop() => stack.Pop();

    public override string ToString()
    {
        var builder = new StringBuilder();
        foreach (var number in stack.Reverse())
        {
            builder.AppendLine(number.ToString());
        }

        return builder.ToString().TrimEnd();
    }

    public bool Equals(NumberStack? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Count == other.Count && stack.SequenceEqual(other.stack);
    }

    public override bool Equals(object? obj) => Equals(obj as NumberStack);

    public override int GetHashCode()
    {
        unchecked
        {
            return stack.Aggregate(17, (current, number) => current * 23 + number.GetHashCode());
        }
    }
}