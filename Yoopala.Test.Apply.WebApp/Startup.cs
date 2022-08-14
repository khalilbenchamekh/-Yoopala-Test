using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yoopala.Test.Apply.WebApp.Models;
using Yoopala.Test.Apply.Infrastructure.Data.Models.Medias;
using Yoopala.Test.Apply.WebApp.Services;
using Yoopala.Test.Apply.Infrastructure.Repositories.Medias;
using Yoopala.Test.Apply.Common.Configuration;

namespace Yoopala.Test.Apply.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConfigureLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var mvcBuilder = services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                options.SuppressAsyncSuffixInActionNames = false;
            })
               .AddDataAnnotationsLocalization()
               .AddViewLocalization();

            //Configuration
            var configurationSection = Configuration.GetSection("Configuration");
            services.Configure<Configuration>(configurationSection);

            MapIterfacesToServices(services);
        }

        /// <summary>
        /// Maps Interfaces to thier implementations
        /// </summary>
        /// <param name="services">serviceCollection to be used for mapping</param>
        public void MapIterfacesToServices(IServiceCollection services)
        {
            #region Media
            services.AddTransient<IMediaService, MediaService>();
            services.AddSingleton<IRepository<Media>, MediaRepository>();
            #endregion
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void ConfigureLogger()
        {
            LoggingConfiguration nlogConfig = new NLogLoggingConfiguration(Configuration.GetSection("Nlog"));
            LogManager.Configuration = nlogConfig;
        }
    }
}
