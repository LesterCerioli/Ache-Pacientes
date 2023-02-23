using AchePacientes.Application.Services.Pacientes.Contratos;
using AchePacientes.Application.Services.Pacientes.Implementations;
using AchePacientes.Domain.Pacientes.Interfaces;
using AchePacientes.Infrastructure.Contexts;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchePacientes.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Infrastructure
            services.AddScoped<IPacienteRepository>();
            services.AddScoped<AchePacientesContext>();

            // Application
            services.AddScoped<IPacienteService, PacienteService>();

        }
    }
}
