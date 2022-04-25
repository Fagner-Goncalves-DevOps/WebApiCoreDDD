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
            services.AddDbContext<IdentitySqlDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<SqlDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}
