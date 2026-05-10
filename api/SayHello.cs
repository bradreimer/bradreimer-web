using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Schrody;

public sealed class SayHello
{
    private readonly GreetingCounter _counter;
    private readonly ILogger<SayHello> _logger;

    public SayHello(GreetingCounter counter, ILogger<SayHello> logger)
    {
        _counter = counter;
        _logger = logger;
    }

    [Function("SayHello")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        using var reader = new StreamReader(req.Body);
        string requestBody = await reader.ReadToEndAsync();

        string? name = HelloRequestParser.ResolveName(req.Url.Query, requestBody);
        int count = _counter.IncrementFor(name);

        _logger.LogInformation("Processed SayHello for {Name}. Current count is {Count}.", name ?? "<none>", count);

        HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/html; charset=utf-8");
        await response.WriteStringAsync($"<strong>Hello human!</strong> {count} people have said hello to me");
        return response;
    }
}
