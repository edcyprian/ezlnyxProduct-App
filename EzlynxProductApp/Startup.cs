using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;

using EzlynxProductApp.Models;

using Microsoft.Framework.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;

namespace EzlynxProductApp
{
    public class Startup
    {
        public IConfiguration configuration { get; set; }

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv )
        {
            var configurationBuilder = new ConfigurationBuilder(appEnv.ApplicationBasePath);

            configurationBuilder.AddJsonFile("config.json");
            configurationBuilder.AddEnvironmentVariables();

            configuration = configurationBuilder.Build();
        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
         services.AddMvc();
               services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ModelsContext>(options => options.UseSqlServer(configuration["Data:ConnectionString"]));
            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Configure the HTTP request pipeline.
            app.UseStaticFiles();

            // Add MVC to the request pipeline.
            app.UseMvc();
            // Add the following route for porting Web API 2 controllers.
            // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
        }
    }
}
