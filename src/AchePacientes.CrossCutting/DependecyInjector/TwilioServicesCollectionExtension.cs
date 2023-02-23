using AchePacientes.Application.Services.TwilioServices.Contratos;
using AchePacientes.Application.Services.TwilioServices.Implementacoes;
using Microsoft.Extensions.DependencyInjection;

namespace AchePacientes.CrossCutting.DependecyInjector
{
    public static class TwilioServicesCollectionExtension
    {
        public static IServiceCollection AddTwilioServices(this IServiceCollection services)
        {
            services.AddScoped<ITwilioSmsServices, TwilioSmsServices>();

            return services;
        }
    }
}
