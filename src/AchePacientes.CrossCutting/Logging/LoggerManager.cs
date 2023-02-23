
using Microsoft.Extensions.Configuration;
using Serilog;

namespace AchePacientes.CrossCutting.Logging
{
    public static class LoggerManager
    {
        public static ILogger CreateLogger()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(configuration)
              .CreateLogger();

            return Log.Logger;
        }
    }
}
