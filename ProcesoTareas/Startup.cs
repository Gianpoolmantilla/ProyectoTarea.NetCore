using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProcesoTareas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;
using ProcesoTareas.Services;
using Microsoft.AspNetCore.Identity;

namespace ProcesoTareas
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
            services.AddDistributedMemoryCache();
            services.AddSession();           
            services.AddControllersWithViews();
            services.AddDbContext<MyDBContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));
            services.AddScoped<ITareaService,TareaService>();
            services.AddScoped<IReporteService, ReporteService>();

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<MyDBContext>().AddErrorDescriber<ErroresCastellano>();
            services.Configure<IdentityOptions>(opciones => 
            {
                opciones.Password.RequiredLength = 6;
                opciones.Password.RequiredUniqueChars = 3;
                opciones.Password.RequireNonAlphanumeric = false;
            
            });
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            //app.UseAuthorization();

            app.UseRouting();
            app.UseAuthentication();//HERE~~~
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "Login",
            //        pattern: "Login/{modelo?}",
            //        defaults: new {controller="Cuentas",action="Login"});

            //});


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Cuentas}/{action=Login}/{modelo?}");
            //});

        }
    }
}
