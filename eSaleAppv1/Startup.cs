using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSale.Data;
using eSale.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
            });

            services.AddDbContext<eSaleDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("eSaleDbContext")));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<eSaleDbContext>();

        // services.AddDefaultIdentity<IdentityUser>()
            //services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<eSaleDbContext>();

            services.AddControllersWithViews();
            services.AddScoped<ShoppingCart>(sc => ShoppingCart.GetCart(sc));


            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddRazorPages();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //.AddRazorPagesOptions(options =>
            //     {
            //options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
            //options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
            //    });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
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
