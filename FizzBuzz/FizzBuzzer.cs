namespace FizzBuzz;

public class FizzBuzzer(IArbiter arbiter)
{
    private readonly IArbiter arbiter = arbiter
                                        ?? throw new ArgumentNullException(nameof(arbiter));

    public string[] FizzBuzz(int upTo) =>
        Enumerable.Range(1, upTo).Select(value => arbiter.Decide(value)).ToArray();
}