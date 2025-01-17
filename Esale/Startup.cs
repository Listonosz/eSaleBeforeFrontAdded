using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSale.Data;
using eSale.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace eSale
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<eSaleDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("eSaleDbContext")));
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<eSaleDbContext>().AddDefaultTokenProviders();
            
            

            services.Configure<IdentityOptions>(opts => {
                opts.Password.RequiredLength = 8;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = true;
                opts.User.RequireUniqueEmail = true;

            });

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddSession(options =>
            {
                options.Cookie.Name = "eSale.Session"; // Cookie name
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(10); // 1 hours expiry
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ShoppingCart>(sc => ShoppingCart.GetCart(sc));
            services.AddRazorPages();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();

            });
        }
    }
}
