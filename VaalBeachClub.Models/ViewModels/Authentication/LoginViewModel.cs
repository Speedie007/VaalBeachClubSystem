using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaalBeachClub.Models.ViewModels.ViewModelComponents;

namespace VaalBeachClub.Models.ViewModels.Authentication
{
    public partial class LoginViewModel: BaseBeachClubViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Required]
        public string Email { get; set; }

        public bool UsernamesEnabled { get; set; }
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "User Password")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}
