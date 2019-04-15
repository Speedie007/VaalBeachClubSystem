using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.ViewModels.Authentication;

namespace VaalBeachClub.Services.Authentication
{
    public interface IUserRegistrationService
    {

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Result</returns>
        UserRegistrationResult RegisterUser(RegisterViewModel request);
    }
}
