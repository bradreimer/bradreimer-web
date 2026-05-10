using Schrody;
using Xunit;

namespace api.Tests;

public sealed class HelloRequestParserTests
{
    [Fact]
    public void ResolveName_PrefersQueryString()
    {
        string? name = HelloRequestParser.ResolveName("?name=Fletch", """{"name":"Brad"}""");

        Assert.Equal("Fletch", name);
    }

    [Fact]
    public void ResolveName_FallsBackToJsonBody()
    {
        string? name = HelloRequestParser.ResolveName(string.Empty, """{"name":"Fibs"}""");

        Assert.Equal("Fibs", name);
    }

    [Fact]
    public void ResolveName_TrimsWhitespace()
    {
        string? name = HelloRequestParser.ResolveName("?name=%20Brad%20", null);

        Assert.Equal("Brad", name);
    }

    [Fact]
    public void ResolveName_ReturnsNullWhenNameIsMissing()
    {
        string? name = HelloRequestParser.ResolveName(string.Empty, """{}""");

        Assert.Null(name);
    }
}
