using Microsoft.Extensions.DependencyInjection;
using AchePacientes.CrossCutting.Logging;

namespace AchePacientes.CrossCutting.DependecyInjector
{
    public static class LoggingServiceCollectionExtension
    {
        public static IServiceCollection AddLogger(this IServiceCollection services)
        {
            var logger = LoggerManager.CreateLogger();
            services.AddSingleton(logger);
            return services;
        }
    }
}
