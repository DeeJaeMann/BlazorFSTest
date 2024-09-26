
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BlazorFS.Test.Access;
using BlazorFS.Access;


namespace BlazorFS.Test.Infrastructure;
public static class TestConfiguration
{
    public static IHostBuilder ConfigureTestConfiguration(this IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Using AddSingleton instead of TryAddSingleton to explicitly overwrite the injected instances
            services.AddSingleton<IExampleService, TestService>();
        });
        return builder;
    }
}