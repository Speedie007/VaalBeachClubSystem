using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.ViewModels.Authentication;
using VaalBeachClub.Services.Authentication;
using VaalBeachClub.Web.Data.Identity;

namespace VaalBeachClub.ViewFactory.Users
{
    public partial class UserViewModelFactory : IUserViewModelFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserService _userService;
        private readonly UserManager<BeachClubMember> _userManager;


        #region Ctor
        public UserViewModelFactory(IServiceProvider serviceProvider,
            IUserService userService,
            UserManager<BeachClubMember> userManager)
        {
            this._serviceProvider = serviceProvider;
            this._userService = userService;
            this._userManager = userManager;
        }
        #endregion

        #region User Login
        /// <summary>
        /// Prepare the login model
        /// </summary>
        /// <returns>Login model</returns>
        public virtual LoginViewModel PrepareLoginModel()
        {
            //Currently No Additional Configuring is required.
            var model = new LoginViewModel();
            model.EmailVerified = false;
            return model;
        }

        public RegisterViewModel PrepareRegistrationLoginModel()
        {
            //Currently No Additional Configuring is required.

            var model = new RegisterViewModel();
            model.UserRole = "Member";
            //using (var serviceScope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            //{
            //    var _roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IntegratorRole>>();
            //    var allUserRoles = _roleManager.Roles.ToList();
            //    foreach (IntegratorRole role in allUserRoles)
            //    {//UserRolesSelectItemViewModel
            //        model.UserRoles.Add(new SelectListItem()
            //        {
            //            Text = role.Name,
            //            Value = role.Name
            //        });
            //    }
            //}
            return model;
        }

        #endregion


    }
}
