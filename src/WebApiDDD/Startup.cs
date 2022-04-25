using Application.AutoMapper;
using CrossCutting.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApiDDD.StartupExtensions;

namespace WebApiDDD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // ----- Database -----
            services.AddCustomizedDatabase(Configuration);

            // ----- Auth -----
            services.AddCustomizedAuth(Configuration);

            // ----- .NET Native DI Abstraction -----
            RegisterServices(services);


            // ----- AutoMapper -----
            services.AddAutoMapper(typeof(AutoMapperSetup)); //metodo absoleto, deixa assim por enquanto


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi - DDD", Version = "v1" });
            });




        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiDDD v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseHttpsRedirection();
            //app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterServices(IServiceCollection services) 
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeDependencyInjectionConfig.RegisterServices(services);
        }
    }
}
