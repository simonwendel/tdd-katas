namespace TimeDependent;

public sealed class TimeOfDay : IEquatable<TimeOfDay>
{
    private readonly TimeOfDayValue timeOfDayValue;

    public static readonly TimeOfDay Morning = new(TimeOfDayValue.Morning);
    public static readonly TimeOfDay Afternoon = new(TimeOfDayValue.Afternoon);
    public static readonly TimeOfDay Evening = new(TimeOfDayValue.Evening);
    public static readonly TimeOfDay Night = new(TimeOfDayValue.Night);

    private enum TimeOfDayValue
    {
        Morning,
        Afternoon,
        Evening,
        Night
    }

    private TimeOfDay(TimeOfDayValue timeOfDayValue) => this.timeOfDayValue = timeOfDayValue;

    public bool Equals(TimeOfDay? other) => other != null && other.timeOfDayValue == timeOfDayValue;

    public override bool Equals(object? obj) => ReferenceEquals(this, obj) || obj is TimeOfDay other && Equals(other);

    public override int GetHashCode() => (int)timeOfDayValue;

    public static bool operator ==(TimeOfDay? left, TimeOfDay? right) => Equals(left, right);

    public static bool operator !=(TimeOfDay? left, TimeOfDay? right) => !Equals(left, right);
}