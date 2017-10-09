using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GlobalBlue.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;

namespace GlobalBlue.Mvc
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
            services.AddMvc();

            //Add DB Contexts
            services.AddDbContext<ShoppingCartContext>(options => 
                options.UseSqlite("Data Source=GlobalBlue.Mvc/GlobalBlue.db"
                    , builder => builder.MigrationsAssembly("GlobalBlue.Mvc")));
            
            // Require SSL
            // services.Configure<MvcOptions>(options =>
            // {
            //     options.Filters.Add(new RequireHttpsAttribute());
            // });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Redirect to HTTPS
            // var options = new RewriteOptions().AddRedirectToHttps();
            // app.UseRewriter(options);

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=ShoppingCart}/{action=Index}/{id?}");
                    //defaults: new { controller = "ShoppingCart", action = "Index" });
            });
        }
    }
}
