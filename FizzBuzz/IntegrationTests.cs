using FluentAssertions;

namespace FizzBuzz;

public class IntegrationTests
{
    [Fact, Trait("Category", "Integration")]
    public void FizzBuzz_CountingToTwenty_ShouldReturnAppropriately()
    {
        var sut = new FizzBuzzer(new Arbiter());
        var expected = new[]
        {
            "1",
            "2",
            "Fizz",
            "4",
            "Buzz",
            "Fizz",
            "7",
            "8",
            "Fizz",
            "Buzz",
            "11",
            "Fizz",
            "13",
            "14",
            "FizzBuzz",
            "16",
            "17",
            "Fizz",
            "19",
            "Buzz"
        };
        sut.FizzBuzz(20).Should().BeEquivalentTo(expected);
    }
    
    [Fact, Trait("Category", "Integration")]
    public void FizzBuzz_CountingToOneHundred_HaveAppropriateStatistics()
    {
        var sut = new FizzBuzzer(new Arbiter());
        var results = sut.FizzBuzz(100);
        
        results.Count(r => r.Contains("Fizz")).Should().Be(100 / 3);
        results.Count(r => r.Contains("Buzz")).Should().Be(100 / 5);
        results.Count(r => r.Contains("FizzBuzz")).Should().Be(100 / 15);
    }
}
