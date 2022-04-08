using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Infra.Data.Repositories;
using Infra.Data.Repositories.Generics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.IoC
{
    public class NativeDependencyInjectionConfig
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITabTelecomConsolidadoRepository, TabTelecomConsolidadoRepository>();
            services.AddScoped<ITabTelecomConsolidadoService, TabTelecomConsolidadoService>();
 
        }
    }
}
