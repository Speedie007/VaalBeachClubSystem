﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VaalBeachClub.Models.Domain.Members;

namespace VaalBeachClub.Services.Authentication
{
   public partial class UserRegistrationResult
    {
        public UserRegistrationResult()
        {
            this.Errors = new List<string>();
        }

        /// <summary>
        /// Gets a value indicating whether request has been completed successfully
        /// </summary>
        public bool Success => !Errors.Any();

        /// <summary>
        /// Add error
        /// </summary>
        /// <param name="error">Error</param>
        public void AddError(string error)
        {
            Errors.Add(error);
        }

        /// <summary>
        /// Errors
        /// </summary>
        public IList<string> Errors { get; set; }

        public BeachClubMember NewlyRegistredUser { get; set; }
    }
}
