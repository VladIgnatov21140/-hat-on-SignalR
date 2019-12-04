using BusinessLayer;
using BusinessLayer.Services;
using DataLayer;
using DataLayer.ContextsInitialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Сhat_on_SignalR.SignalR.Hubs;

namespace Сhat_on_SignalR
{
    public class Startup
    {
        IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBusinessLibraryCollection();
            services.AddDataLibraryCollection(Configuration.GetSection("ConnectionStrings").GetValue<string>("DefaultConnection"));
            ApplicationContextInitializer appInit = new ApplicationContextInitializer();
            {
                appInit.InitializeApplicationContext(Configuration.GetSection("ConnectionStrings").GetValue<string>("DefaultConnection"));
            }
            services.AddSignalR();
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IBusinessServices businessServices)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<GeneralGroupHub>("/generalGroupHub");
            });

        }
    }
}
