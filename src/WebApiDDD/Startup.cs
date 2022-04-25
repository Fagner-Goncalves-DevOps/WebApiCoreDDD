using Application.AutoMapper;
using CrossCutting.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiDDD.StartupExtensions;

namespace WebApiDDD
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // ----- Database -----
            services.AddCustomizedDatabase(Configuration, _env);

            // ----- Auth -----
            services.AddCustomizedAuth(Configuration);

            // ----- AutoMapper -----
            services.AddAutoMapper(typeof(AutoMapperSetup)); //metodo absoleto, deixa assim por enquanto

            // ----- Swagger UI srv-----
            services.AddCustomizedSwagger(_env);

            // ----- .NET Native DI Abstraction -----
            RegisterServices(services);

            services.AddControllers();


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseHttpsRedirection();
            //app.UseAuthentication();

            // ----- Auth Interno -----
            app.UseAuthorization();

            // ----- Auth app -----
            app.UseCustomizedAuth();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // ----- Swagger UI app-----
            app.UseCustomizedSwagger(_env);
        }

        private static void RegisterServices(IServiceCollection services) 
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeDependencyInjectionConfig.RegisterServices(services);
        }
    }
}
