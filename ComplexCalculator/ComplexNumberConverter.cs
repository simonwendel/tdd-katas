using System.Globalization;
using System.Text.RegularExpressions;

namespace ComplexCalculator;

public partial class ComplexNumberConverter : IComplexNumberConverter
{
    public ComplexNumber FromString(string number)
    {
        ArgumentNullException.ThrowIfNull(number);
        ArgumentException.ThrowIfNullOrWhiteSpace(number);

        var regex = ComplexNumberRegex();
        var matches = regex.Matches(number.Trim());
        if (matches.Count != 1)
        {
            throw new ArgumentException(null, nameof(number));
        }

        var match = matches.First();

        var reString = match.Groups["Re"].Value;
        var re = reString switch
        {
            "" => 0,
            _ => Convert.ToDouble(reString, CultureInfo.InvariantCulture)
        };

        var imString = match.Groups["Im"].Value;
        var im = imString switch
        {
            "" => 0,
            "i" => 1,
            _ => Convert.ToDouble(imString.Replace("i", ""), CultureInfo.InvariantCulture)
        };

        return new ComplexNumber(re, im);
    }

    [GeneratedRegex(
        @"^(?<Re>\d+\.?\d*)?\s*\+?\s*(?<Im>(?:\d+\.?\d*)?i)?$",
        RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.RightToLeft)]
    private static partial Regex ComplexNumberRegex();
}