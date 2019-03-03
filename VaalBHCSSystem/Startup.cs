﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VaalBeachClub.Data;
using VaalBeachClub.Web.Data.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using VaalBeachClub.Data.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using VaalBeachClub.Services.Interfaces.BoatHouses;
using VaalBeachClub.Services.BoatHouses;
using VaalBeachClub.ViewFactory.BoatHouses;
using VaalBreachClub.Web.Data.Intefaces;
using VaalBeachClub.Models.ViewModels;
using VaalBeachClub.Models.Domain;
using VaalBeachClub.Models;
using VaalBeachClub.Models.Domain.BoatHouses;

using VaalBreachClub.Web.Extensions;

namespace VaalBeachClub.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});


            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<BeachClubMember, BeachClubRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>()

                .AddDefaultTokenProviders();



            services.Configure<IdentityOptions>(options =>
            {
                options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;

                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            // Add Database Initializer
            services.AddScoped<IDbInitializer, DbInitializer>();

            //services.AddScoped<IRepository<>,EfRepository<BoatHouse>>();
            //services.AddScoped<IBoatHouseService, BoatHouseService>();
            //services.AddScoped<IBoatHouseModelFactory, BoatHouseModelFactory>();

            //services.AddScoped<IEventPublisher>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return services.ConfigureApplicationServices(Configuration);

            //return Configuration;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IDbInitializer dbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();


            app.UseAuthentication();

            dbInitializer.Initialize();



            app.UseMvc(routes =>
            {

                routes.MapRoute(
                         name: "areaRouteForBoatHouseAdminSection",
                         template: "{area:exists}/{controller=BoatHouseAdmin}/{action=Index}/{id?}");

                routes.MapRoute(
                         name: "areaRouteForAdminSection",
                         template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}