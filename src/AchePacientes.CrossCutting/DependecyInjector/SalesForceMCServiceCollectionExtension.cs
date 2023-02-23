using AchePacientes.Application.Services.SalesforceMc.Contratos;
using AchePacientes.Application.Services.SalesforceMc.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace AchePacientes.CrossCutting.DependecyInjector
{
    public static class SalesForceMCServiceCollectionExtension
    {
        public static IServiceCollection AddSalesForceServices(this IServiceCollection services)
        {
            services.AddScoped<ISendSmsSingleRecipientService, SendSmsSingleRecipientService>();

            return services;
        }
    }
}
