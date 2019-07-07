using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Addresses;
using VaalBeachClub.Models.Domain.Files;
using VaalBeachClub.Models.Domain.Members;
using VaalBeachClub.Models.ViewModels.Authentication;
using VaalBeachClub.Models.ViewModels.Members;
using VaalBeachClub.Services.Addresses;
using VaalBeachClub.Services.Authentication;


namespace VaalBeachClub.ViewFactory.Users
{
    public interface IUserViewModelFactory
    {
        /// <summary>
        /// Prepare the login model
        /// </summary>
        /// <returns>Login model</returns>
        LoginViewModel PrepareLoginModel();

        /// <summary>
        /// Prepare the Registration model
        /// </summary>
        /// <returns>Login model</returns>
        RegisterViewModel PrepareRegistrationLoginModel();

        #region Member Regisration 

        MemberInfoModel PrepareMemberRegistraionViewModel();
        #endregion
    }
    public partial class UserViewModelFactory : IUserViewModelFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserService _userService;
        private readonly UserManager<BeachClubMember> _userManager;
        private readonly IAddressService<Address> _AddressService;

        #region Ctor
        public UserViewModelFactory(IServiceProvider serviceProvider,
            IUserService userService,
            UserManager<BeachClubMember> userManager,
            IAddressService<Address> AddressService)
        {
            this._serviceProvider = serviceProvider;
            this._userService = userService;
            this._userManager = userManager;
            this._AddressService = AddressService;
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


        #region Member Regisration Wizard
        public MemberInfoModel PrepareMemberRegistraionViewModel()
        {
            MemberInfoModel model = new MemberInfoModel();

            model.Memeber = _userService.GetCurrentLoginInUser();


            BeachClubFile CurrentProfilePicture = _userService.GetUserProfilePicture();

            model.ProfilePicture = new MemberProfilePicture()
            {
                Id = CurrentProfilePicture.Id,//FILEID
                ContentType = CurrentProfilePicture.ContentType,
                ProfileImage = CurrentProfilePicture.FileBlob.BlobData
            };

            model.AddAddressToCollection(_AddressService.ListAddressesByMember(_userService.GetUserID()));
            //
            return model;
        }
        #endregion
    }
}
