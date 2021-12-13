using bookstoreproject.Data;
using bookstoreproject.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstoreproject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>(
                options => options.UseSqlServer(" Server=.;Database=BookStore;Integrated Security=True;")); /// database connection

            services.AddControllersWithViews(); /// Line to use MVC Architecture

#if DEBUG // For development environment

            services.AddRazorPages().AddRazorRuntimeCompilation();  /// line to Auto reload browser

       /*          // enable / disable client side validation
                  .AddViewOptions(option =>
            {
                option.HtmlHelperOptions.ClientValidationEnabled = false;
            });*/
           
            
#endif
            services.AddScoped<BookRepository, BookRepository>(); // dependency injection setup/resolve
            services.AddScoped<LanguageRepository, LanguageRepository>(); // dependency injection setup/resolve
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapDefaultControllerRoute();

                /*endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });*/
            });
        }
    }
}
