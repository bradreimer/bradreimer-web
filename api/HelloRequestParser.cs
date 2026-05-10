using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;

namespace Schrody;

public static class HelloRequestParser
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static string? ResolveName(string query, string? body)
    {
        string? queryName = Normalize(GetQueryValue(query, "name"));
        if (queryName is not null)
        {
            return queryName;
        }

        if (string.IsNullOrWhiteSpace(body))
        {
            return null;
        }

        HelloRequest? payload = JsonSerializer.Deserialize<HelloRequest>(body, JsonOptions);
        return Normalize(payload?.Name);
    }

    private static string? GetQueryValue(string query, string key)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return null;
        }

        var parsedQuery = QueryHelpers.ParseQuery(query);
        if (!parsedQuery.TryGetValue(key, out var values))
        {
            return null;
        }

        return values.Count > 0 ? values[0] : null;
    }

    private static string? Normalize(string? value) =>
        string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}
