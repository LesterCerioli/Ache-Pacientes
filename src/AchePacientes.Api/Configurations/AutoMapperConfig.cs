
using AchePacientes.Application.AutoMapper;
using AchePacientes.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

namespace AchePacientes.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            
        }
    }
}
