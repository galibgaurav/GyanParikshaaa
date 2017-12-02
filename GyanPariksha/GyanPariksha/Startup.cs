using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using GyanPariksha.Services;
using Microsoft.Extensions.Configuration;
using GyanPariksha.Models;

namespace GyanPariksha
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;
        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();//to read configurable variable from config file
            _config = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)//configure service
        {
            services.AddSingleton(_config);

            //services.AddScoped reuses instance of GyanPariksha.Services.GyanPariksha but
            //only over single request,services.AddSingleton or services.AddTransient
            services.AddScoped<IGyanPariksha,GyanPariksha.Services.GyanPariksha>();
            //hooking entity framework
            services.AddDbContext<GyanParikshaContext>();//it is now injectibke ti different part if the project

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //gaurav- below method says when u start up,tells how u are going to listen web request
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)//configure HTTP pipe
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //   // await context.Response.WriteAsync("<html><body>galibgaurav</body></html>");

            //});
            //gaurav- changes the path to the default file path like index.html or default.html
            //when the request comes something as http://localhost:8888/ not something like  http://localhost:8888/index.html 
            app.UseDefaultFiles();
            //gaurav-when the web server comes up add the service of serving the static file
            //from wwwroot, which kind of considered as safe place
            app.UseStaticFiles();//for serving static files like index.html form wwwroot

            //Listen to request and see if it can be mapped with any actions in the controller
            app.UseMvc(cfg=> {
                cfg.MapRoute("Default","{controller}/{action}/{id?}",new { controller="App",Action="Index"});
            });
            //if(env.IsDevelopment())
            //{
            //    //app.UseDeveloperExceptionPage();
            //}
        }
    }
}
