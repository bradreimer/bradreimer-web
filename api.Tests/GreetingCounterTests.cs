using Schrody;
using Xunit;

namespace api.Tests;

public sealed class GreetingCounterTests
{
    [Fact]
    public void IncrementFor_KnownName_IsCaseInsensitiveAndIncrements()
    {
        var counter = new GreetingCounter();

        int first = counter.IncrementFor("brad");
        int second = counter.IncrementFor("Brad");

        Assert.Equal(1, first);
        Assert.Equal(2, second);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("Unknown")]
    public void IncrementFor_UnsupportedName_ReturnsZero(string? name)
    {
        var counter = new GreetingCounter();

        int count = counter.IncrementFor(name);

        Assert.Equal(0, count);
    }
}
