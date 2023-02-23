using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AchePacientes.CrossCutting.HealthChecks
{
    public static class HealthCheckManager
    {
        public static IServiceCollection AddHealthCheckConfigurations(this IServiceCollection services)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json", true, true)
                .Build();

            services.AddHealthChecks();

            return services;
        }

    }
}
