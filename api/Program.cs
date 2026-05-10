using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Schrody;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddSingleton<GreetingCounter>();
    })
    .Build();

host.Run();
