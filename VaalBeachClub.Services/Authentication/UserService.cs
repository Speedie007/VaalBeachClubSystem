using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using VaalBeachClub.Common.Interfaces;
using VaalBeachClub.Web.Data.Identity;
using VaalBreachClub.Web.Data.Intefaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace VaalBeachClub.Services.Authentication
{
    public partial class UserService : IUserService
    {

        #region Fields

        private readonly IServiceProvider _serviceProvider;
        private readonly UserManager<BeachClubMember> _userManager;
        private readonly RoleManager<BeachClubRole> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
       // private readonly IEntityCRUDResponse _entityCRUDResponse;




        #endregion
        public UserService(
            IServiceProvider serviceProvider,
            UserManager<BeachClubMember> userManager,
            RoleManager<BeachClubRole> roleManager,
            IHttpContextAccessor httpContextAccessor
           
           // IEntityCRUDResponse entityCRUDResponse
            )
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._httpContextAccessor = httpContextAccessor;
            this._serviceProvider = serviceProvider;
            
        }
        public void DeleteUser(BeachClubMember user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserRole(BeachClubMemberRole userRole)
        {
            throw new NotImplementedException();
        }

        public string FormatUserName(BeachClubMember user, bool stripTooLong = false, int maxLength = 0)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<string>> GetAllUserRolesAsync(bool showHidden = false)
        {
            return await _userManager.GetRolesAsync((BeachClubMember)_httpContextAccessor.HttpContext.User.Identity);
            
        }

        public IPagedList<BeachClubMember> GetAllUsers(DateTime? createdFromUtc = null, DateTime? createdToUtc = null, int[] UserRoleIds = null, string email = null, string username = null, string firstName = null, string lastName = null, string phone = null, int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false)
        {
            throw new NotImplementedException();
        }

        public BeachClubMember GetCurrentLoginInUser()
        {
            var currentUser = _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
            return currentUser;
        }

        public string GetCurrentPassword(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BeachClubMember> GetUserByEmailAsync(string email)
        {
            BeachClubMember user;
            using (var serviceScope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var _userManager = serviceScope.ServiceProvider.GetService<UserManager<BeachClubMember>>();

                user = await _userManager.FindByEmailAsync(email.ToUpper());

            }
            return user;
        }

        public BeachClubMember GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public BeachClubMember GetUserBySystemName(string systemName)
        {
            throw new NotImplementedException();
        }

        public BeachClubMember GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public string GetUserFullName(BeachClubMember user)
        {
            throw new NotImplementedException();
        }

        public int GetUserID()
        {
            int id = Convert.ToInt32(_userManager.GetUserId(_httpContextAccessor.HttpContext.User));
            return id;
        }

        public IList<string> GetUserPasswords(int? userId = null, int? passwordsToReturn = null)
        {
            throw new NotImplementedException();
        }

        public BeachClubMemberRole GetUserRoleById(int userRoleId)
        {
            throw new NotImplementedException();
        }

        public BeachClubMemberRole GetUserRoleBySystemName(string systemName)
        {
            throw new NotImplementedException();
        }

        public IList<BeachClubMember> GetUsersByIds(int[] userIds)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> InsertUserAsync(BeachClubMember NewUser, string password)
        {
            IdentityResult CreatedSuccessfully;
            using (var serviceScope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var _userManager = serviceScope.ServiceProvider.GetService<UserManager<BeachClubMember>>();
                var success = await _userManager.CreateAsync(NewUser, password);
                CreatedSuccessfully = success;
            }
            return CreatedSuccessfully;//await _userManager.CreateAsync(NewUser, password); ;
        }

        public void InsertUserPassword(string userPassword)
        {
            throw new NotImplementedException();
        }

        public async Task InsertUserRoleAsync(string role, string userNameAsEmailAddress)
        {
            using (var serviceScope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var _userManager = serviceScope.ServiceProvider.GetService<UserManager<BeachClubMember>>();
                await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(userNameAsEmailAddress), role);
            }
        }

        public bool IsPasswordRecoveryTokenValid(BeachClubMember user, string token)
        {
            throw new NotImplementedException();
        }

        public bool PasswordIsExpired(BeachClubMember user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(BeachClubMember user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserPassword(string userPassword)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserRole(BeachClubMemberRole userRole)
        {
            throw new NotImplementedException();
        }
    }
}
