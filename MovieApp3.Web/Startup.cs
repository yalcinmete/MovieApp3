using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieApp3.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieApp3.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers(); //API icin.
            //services.AddRazorPages(); //Razor sayfalar için.,

            services.AddDbContext<MovieContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MsSQLConnection")));
            //options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews(); //MVC kullanýmý icin.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                DataSeeding.Seed(app);
            }

            app.UseStaticFiles(); //wwwroot'u dýþarýya açar.

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            
            app.UseEndpoints(endpoints =>
            {
                //default route.
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });


            //    //localhost:5000/
            //    endpoints.MapControllerRoute(
            //        name: "home",
            //        pattern: "",
            //        defaults: new { controller = "Home", action = "index" }
            //    );

            //    //localhost:5000/about
            //    endpoints.MapControllerRoute(
            //        name: "about",
            //        pattern: "hakkýmýzda",
            //        defaults: new { controller = "Home", action = "about" }
            //    );


            //    endpoints.MapControllerRoute(
            //        name: "movieList",
            //        pattern: "movies/list",
            //        defaults: new { controller = "Movies", action = "List" }
            //    );

            //    endpoints.MapControllerRoute(
            //        name: "movieDetails",
            //        pattern: "movies/details",
            //        defaults: new { controller = "Movies", action = "Details" }
            //    );

            //localhost:5000/movies
            //endpoints.MapControllerRoute(
            //    name: "movieList",
            //    pattern: "movies",
            //    defaults: new { controller = "Movies", action = "List" }
            //    );



            ////localhost:5000
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            ////localhost:5000/movies
            /// //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/movies", async context =>
            //    {
            //        await context.Response.WriteAsync("Movie List");
            //    });
            //});
        }
    }
}
