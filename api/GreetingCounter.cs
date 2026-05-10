using System.Collections.Concurrent;

namespace Schrody;

public sealed class GreetingCounter
{
    private static readonly HashSet<string> SupportedNames = new(StringComparer.OrdinalIgnoreCase)
    {
        "Brad",
        "Fibs",
        "Fletch"
    };

    private readonly ConcurrentDictionary<string, int> _counts = new(StringComparer.OrdinalIgnoreCase);

    public int IncrementFor(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return 0;
        }

        string normalizedName = name.Trim();
        if (!SupportedNames.Contains(normalizedName))
        {
            return 0;
        }

        return _counts.AddOrUpdate(normalizedName, 1, (_, count) => count + 1);
    }
}
