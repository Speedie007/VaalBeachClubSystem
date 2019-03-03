using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Data.Interfaces;
using VaalBeachClub.Web.Data.Identity;

namespace VaalBeachClub.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceProvider _serviceProvider;

        public DbInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        //This example just creates an Administrator role and one Admin users
        public async void Initialize()
        {
            using(var serviceScope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                //create database schema if none exists
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                //If there is already an Administrator role, abort
                var _roleManager = serviceScope.ServiceProvider.GetService<RoleManager<BeachClubRole>>();
                if (!(await _roleManager.RoleExistsAsync("Administrator")))
                {
                    //Create the Administartor Role
                    await _roleManager.CreateAsync(new BeachClubRole("Administrator"));
                }
                //Create the default Admin account and apply the Administrator role
                var _userManager = serviceScope.ServiceProvider.GetService<UserManager<BeachClubMember>>();
                string user = "Admin@Admin.com";
                string password = "Speedie@007";
                var success = await _userManager.CreateAsync(new BeachClubMember { UserName = user, Email = user, EmailConfirmed = true }, password);
                if (success.Succeeded)
                {
                    await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(user), "Administrator");
                }
            }
        }
    }
}
