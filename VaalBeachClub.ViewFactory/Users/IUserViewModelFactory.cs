using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.ViewModels.Authentication;

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
    }
}
