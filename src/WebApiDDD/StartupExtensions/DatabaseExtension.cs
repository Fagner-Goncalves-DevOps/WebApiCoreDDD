using CrossCutting.Identity.Data;
using Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiDDD.StartupExtensions
{
    public static class DatabaseExtension
    {                                                                                                                           // não implementamos envio ainda
        public static IServiceCollection AddCustomizedDatabase(this IServiceCollection services, IConfiguration configuration) // IWebHostEnvironment env
        {
            //obs: entitycore em 2 bibliotecas nao necessariamente, inverter processo depois se necessario
            services.AddDbContext<IdentitySqlDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<SqlDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                // options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            });
            return services;
        }
    }
}
