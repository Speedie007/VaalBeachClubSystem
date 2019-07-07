using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using VaalBeachClub.Common.Interfaces;

using VaalBreachClub.Web.Data.Intefaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VaalBeachClub.Models.Domain.Files;
using VaalBeachClub.Models.Domain.Interfaces;
using System.Linq;
using VaalBeachClub.Models.Domain.Members;
using VaalBeachClub.Models.ViewModels.Members;

namespace VaalBeachClub.Services.Authentication
{
    public interface IUserService
    {


        #region User
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <param name="createdFromUtc"></param>
        /// <param name="createdToUtc"></param>
        /// <param name="UserRoleIds"></param>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phone"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="getOnlyTotalCount"></param>
        /// <returns></returns>
        IPagedList<BeachClubMember> GetAllUsers(DateTime? createdFromUtc = null,
           DateTime? createdToUtc = null,
           int[] UserRoleIds = null, string email = null, string username = null,
           string firstName = null, string lastName = null, string phone = null,
           int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false);



        BeachClubMember GetCurrentLoginInUser();

        int GetUserID();
        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="user">BeachClubMember</param>
        void DeleteUser(BeachClubMember user);

        /// <summary>
        /// Gets a user
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <returns>A user</returns>
        BeachClubMember GetUserById(int userId);

        /// <summary>
        /// Get users by identifiers
        /// </summary>
        /// <param name="userIds">User identifiers</param>
        /// <returns>Users</returns>
        IList<BeachClubMember> GetUsersByIds(int[] userIds);



        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>User</returns>
        Task<BeachClubMember> GetUserByEmailAsync(string email);

        /// <summary>
        /// Get user by system role
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>User</returns>
        BeachClubMember GetUserBySystemName(string systemName);

        /// <summary>
        /// Get user by username
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User</returns>
        BeachClubMember GetUserByUsername(string username);



        /// <summary>
        /// Insert a user
        /// </summary>
        /// <param name="user">User</param>
        Task<IdentityResult> InsertUserAsync(BeachClubMember NewUser, string password);

        /// <summary>
        /// Updates the user
        /// </summary>
        /// <param name="user">BeachClubMember</param>
        void UpdateUser(BeachClubMember user);

        /// <summary>
        /// Get full name
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>User full name</returns>
        string GetUserFullName(BeachClubMember user);

        /// <summary>
        /// Formats the user name
        /// </summary>
        /// <param name="user">Source</param>
        /// <param name="stripTooLong">Strip too long user name</param>
        /// <param name="maxLength">Maximum user name length</param>
        /// <returns>Formatted text</returns>
        string FormatUserName(BeachClubMember user, bool stripTooLong = false, int maxLength = 0);
        #endregion

        #region User roles

        /// <summary>
        /// Delete a user role
        /// </summary>
        /// <param name="userRole">User role</param>
        void DeleteUserRole(BeachClubMemberRole userRole);

        /// <summary>
        /// Gets a user role
        /// </summary>
        /// <param name="userRoleId">User role identifier</param>
        /// <returns>User role</returns>
        BeachClubMemberRole GetUserRoleById(int userRoleId);

        /// <summary>
        /// Gets a user role
        /// </summary>
        /// <param name="systemName">User role system name</param>
        /// <returns>User role</returns>
        BeachClubMemberRole GetUserRoleBySystemName(string systemName);

        /// <summary>
        /// Gets all user roles
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>User roles</returns>
        Task<IList<string>> GetAllUserRolesAsync(bool showHidden = false);

        /// <summary>
        /// Inserts a user role
        /// </summary>
        /// <param name="userRole">User role</param>
        Task InsertUserRoleAsync(string role, string userNameAsEmailAddress);

        /// <summary>
        /// Updates the user role
        /// </summary>
        /// <param name="userRole">User role</param>
        void UpdateUserRole(BeachClubMemberRole userRole);

        #endregion

        #region User passwords

        /// <summary>
        /// Gets user passwords
        /// </summary>
        /// <param name="userId">User identifier; pass null to load all records</param>
        /// <param name="passwordFormat">Password format; pass null to load all records</param>
        /// <param name="passwordsToReturn">Number of returning passwords; pass null to load all records</param>
        /// <returns>List of user passwords</returns>
        IList<string> GetUserPasswords(int? userId = null, int? passwordsToReturn = null);

        /// <summary>
        /// Get current user password
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <returns>User password</returns>
        string GetCurrentPassword(int userId);

        /// <summary>
        /// Insert a user password
        /// </summary>
        /// <param name="userPassword">User password</param>
        void InsertUserPassword(string userPassword);

        /// <summary>
        /// Update a user password
        /// </summary>
        /// <param name="userPassword">User password</param>
        void UpdateUserPassword(string userPassword);

        /// <summary>
        /// Check whether password recovery token is valid
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="token">Token to validate</param>
        /// <returns>Result</returns>
        bool IsPasswordRecoveryTokenValid(BeachClubMember user, string token);



        /// <summary>
        /// Check whether user password is expired 
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>True if password is expired; otherwise false</returns>
        bool PasswordIsExpired(BeachClubMember user);
        #endregion

        #region User Files
        void AddUserProfilePicture(BeachClubFile entity);

        BeachClubFile GetUserProfilePicture();
        #endregion
    }
    public partial class UserService : IUserService
    {

        #region Fields

        private readonly IServiceProvider _serviceProvider;
        private readonly UserManager<BeachClubMember> _userManager;
        private readonly RoleManager<BeachClubRole> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<BeachClubFile> _beachClubFileRepository;
        private readonly IRepository<FileBlob> _fileBlobRepository;
        private readonly IRepository<MemberProfileImage> _memberProfileImageRepository;
      
        // private readonly IEntityCRUDResponse _entityCRUDResponse;




        #endregion
        public UserService(
            IServiceProvider serviceProvider,
            UserManager<BeachClubMember> userManager,
            RoleManager<BeachClubRole> roleManager,
            IHttpContextAccessor httpContextAccessor,
            IRepository<BeachClubFile> beachClubFileRepository,
            IRepository<FileBlob> fileBlobFileRepository,
            IRepository<MemberProfileImage> memberProfileImageRepository

            // IEntityCRUDResponse entityCRUDResponse
            )
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._httpContextAccessor = httpContextAccessor;
            this._serviceProvider = serviceProvider;
            this._beachClubFileRepository = beachClubFileRepository;
            this._fileBlobRepository = fileBlobFileRepository;
            this._memberProfileImageRepository = memberProfileImageRepository;
        }

        public void AddUserProfilePicture(BeachClubFile entity)
        {
            try
            {
                if (entity.Id != 0)
                {
                    var CurrentFileBlob = _fileBlobRepository.Table.Where(x => x.Id == entity.Id).FirstOrDefault();
                    CurrentFileBlob.BlobData = entity.FileBlob.BlobData;
                    _fileBlobRepository.Update(CurrentFileBlob);

                    var CurrentMemberProfileImage = _memberProfileImageRepository.Table.Where(x => x.Id == entity.Id).FirstOrDefault();
                    CurrentMemberProfileImage.DateLastUpdated = DateTime.Now;
                    _memberProfileImageRepository.Update(CurrentMemberProfileImage);
                }
                else
                {
                    _beachClubFileRepository.Insert(entity);
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public BeachClubFile GetUserProfilePicture()
        {
            BeachClubFile MemberProfilePicDetails = _beachClubFileRepository.Table
                .Include(x=>x.FileBlob)
                .Where(x => x.MemberProfileImage.BeachClubMemberID == GetCurrentLoginInUser().Id).FirstOrDefault();
             
            return MemberProfilePicDetails;
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
