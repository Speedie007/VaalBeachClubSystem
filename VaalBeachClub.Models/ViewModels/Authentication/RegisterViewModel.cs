using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaalBeachClub.Models.ViewModels.ViewModelComponents;

namespace VaalBeachClub.Models.ViewModels.Authentication
{
    public partial class RegisterViewModel : BaseBeachClubViewModel
    {
        #region Cstor
        public RegisterViewModel()
        {

        }
        #endregion

        [EmailAddress]
        [Display(Name = "Email")]
        [Required]
        public string UserEmail { get; set; }

        [EmailAddress]
        [Display(Name ="Confirm Email")]
        [Required]
        [Compare("UserEmail", ErrorMessage ="")]
        public string UserConfirmEmail { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        // [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Confirm password")]
        [Compare("UserPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmUserPassword { get; set; }

        //public String RoleDefault { get; set; }

        //[Display(Name = "User Role")]
        //public String RoleLabel => "User Roles";

        [Display(Name = "Terms and Conditions")]
        //[Required]
        //[BooleanMustBeTrue(ErrorMessage = "You must agree to the terms and conditions")]
        public Boolean TermsAndConditions { get; set; }

        public string UserRole { get; set; }

        public Boolean RegistrationConfirmationSent { get; set; }

        //public Boolean IsComplexAddressAdded { get; set; }
        //public ComplexAddressViewModel ComplexAddress { get; set; }

        //public Boolean IsPOBoxAddressAdded { get; set; }
        //public POBoxAddressViewModel POBoxAddress { get; set; }

        //public Boolean IsStreetAddressAdded { get; set; }
        //public StreetAddressViewModel StreetAddress { get; set; }

    }
}
