using FluentAssertions;

namespace TimeOfDayGreetings;

public class TimeOfDayTests
{
    [Fact]
    public void Equals_GivenSameTimeOfDay_ReturnsTrue()
    {
        TimeOfDay.Morning.Equals(TimeOfDay.Morning).Should().BeTrue();
        TimeOfDay.Afternoon.Equals(TimeOfDay.Afternoon).Should().BeTrue();
        TimeOfDay.Evening.Equals(TimeOfDay.Evening).Should().BeTrue();
        TimeOfDay.Night.Equals(TimeOfDay.Night).Should().BeTrue();
    }

    [Fact]
    public void EqualOperator_GivenSameTimeOfDay_ReturnsTrue()
    {
        // ReSharper disable once EqualExpressionComparison
        (TimeOfDay.Morning == TimeOfDay.Morning).Should().BeTrue();

        // ReSharper disable once EqualExpressionComparison
        (TimeOfDay.Afternoon == TimeOfDay.Afternoon).Should().BeTrue();

        // ReSharper disable once EqualExpressionComparison
        (TimeOfDay.Evening == TimeOfDay.Evening).Should().BeTrue();

        // ReSharper disable once EqualExpressionComparison
        (TimeOfDay.Night == TimeOfDay.Night).Should().BeTrue();
    }

    [Fact]
    public void NotEqualOperator_GivenSameTimeOfDay_ReturnsFalse()
    {
        // ReSharper disable once EqualExpressionComparison
        (TimeOfDay.Morning != TimeOfDay.Morning).Should().BeFalse();

        // ReSharper disable once EqualExpressionComparison
        (TimeOfDay.Afternoon != TimeOfDay.Afternoon).Should().BeFalse();

        // ReSharper disable once EqualExpressionComparison
        (TimeOfDay.Evening != TimeOfDay.Evening).Should().BeFalse();

        // ReSharper disable once EqualExpressionComparison
        (TimeOfDay.Night != TimeOfDay.Night).Should().BeFalse();
    }

    [Fact]
    public void Equals_GivenDifferentTimeOfDay_ReturnsFalse()
    {
        TimeOfDay.Morning.Equals(TimeOfDay.Afternoon).Should().BeFalse();
        TimeOfDay.Morning.Equals(TimeOfDay.Evening).Should().BeFalse();
        TimeOfDay.Morning.Equals(TimeOfDay.Night).Should().BeFalse();

        TimeOfDay.Afternoon.Equals(TimeOfDay.Morning).Should().BeFalse();
        TimeOfDay.Afternoon.Equals(TimeOfDay.Evening).Should().BeFalse();
        TimeOfDay.Afternoon.Equals(TimeOfDay.Night).Should().BeFalse();

        TimeOfDay.Evening.Equals(TimeOfDay.Morning).Should().BeFalse();
        TimeOfDay.Evening.Equals(TimeOfDay.Afternoon).Should().BeFalse();
        TimeOfDay.Evening.Equals(TimeOfDay.Night).Should().BeFalse();

        TimeOfDay.Night.Equals(TimeOfDay.Morning).Should().BeFalse();
        TimeOfDay.Night.Equals(TimeOfDay.Afternoon).Should().BeFalse();
        TimeOfDay.Night.Equals(TimeOfDay.Evening).Should().BeFalse();
    }

    [Fact]
    public void Equals_GivenObjectOfDifferentType_ReturnsFalse()
    {
        TimeOfDay.Morning.Equals(new object()).Should().BeFalse();
    }

    [Fact]
    public void GetHashCode_GivenTimeOfDay_ReturnsTimeOfDayValueHashCode()
    {
        TimeOfDay.Morning.GetHashCode().Should().Be(0);
        TimeOfDay.Afternoon.GetHashCode().Should().Be(1);
        TimeOfDay.Evening.GetHashCode().Should().Be(2);
        TimeOfDay.Night.GetHashCode().Should().Be(3);
    }
}
