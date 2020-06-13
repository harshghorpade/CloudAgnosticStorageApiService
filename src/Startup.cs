// ==================================================
// Cloud Agnostic Storage API Startup class
// ==================================================

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CloudAgnosticStorageAPI.Interface;
using CloudAgnosticStorageAPI.Service;
using CloudAgnosticStorageAPI.Repository;

namespace CloudAgnosticStorageAPI
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
            services.AddControllers();
            services.AddSingleton<IStorageRepository, AzureStorageRepository>();
            services.AddSingleton<IStorageRepository, AWSStorageRepository>();
            services.AddSingleton<IStorageRepository, GCPStorageRepository>();
            services.AddSingleton<IStorageRepositoryFactory, StorageRepositoryFactory>();
            services.AddSingleton<IStorageService, StorageService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
