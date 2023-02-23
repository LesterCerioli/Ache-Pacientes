using AchePacientes.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AchePacientes.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<AchePacientesContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            
        }
    }
}
