using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.ViewModels.Authentication;

namespace VaalBeachClub.ViewFactory.Users
{
    public partial class UserViewModelFactory : IUserViewModelFactory
    {
        private readonly IServiceProvider _serviceProvider;


        #region Ctor
        public UserViewModelFactory(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
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
            return model;
        }

        public RegisterViewModel PrepareRegistrationLoginModel()
        {
            //Currently No Additional Configuring is required.
            var model = new RegisterViewModel();
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
