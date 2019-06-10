using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VaalBeachClub.Models.ViewModels.Authentication;
using VaalBeachClub.Services.Authentication;
using VaalBeachClub.Services.EmailSending;
using VaalBeachClub.ViewFactory.Users;
using VaalBeachClub.Web.Data.Identity;


namespace VaalBreachClub.Web.Areas.Members.Controllers
{
    [Area("Members")]
    public class MembersController : Controller
    {

        #region Fields
        private readonly IUserViewModelFactory _userViewModelFactory;
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly UserManager<BeachClubMember> _userManager;
        //private readonly RoleManager<IntegratorRole> _roleManager;
        private readonly SignInManager<BeachClubMember> _signInManager;
        private readonly ICustomEmailSender _emailSender;
        #endregion


        #region Cstor
        public MembersController(
            IUserViewModelFactory userViewModelFactory,
            IUserRegistrationService userRegistrationService,
            SignInManager<BeachClubMember> signInManager,
            UserManager<BeachClubMember> userManager,
            ICustomEmailSender emailSender
            )
        {
            this._userViewModelFactory = userViewModelFactory;
            this._userRegistrationService = userRegistrationService;
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._emailSender = emailSender;
        }
        #endregion


        #region Registation
        [HttpGet]
        public IActionResult Register()
        {
            var model = _userViewModelFactory.PrepareRegistrationLoginModel();
            model.TermsAndConditions = false;
            return View(model);
        }
        public async Task<IActionResult> RegistrationConfirmation(string userId, string code)
        {
            var model = new RegistrationConfirmationViewModel();
            if (userId == null || code == null)
            {
                return RedirectToAction(
                     actionName: "Login",
                      controllerName: "Authentication"
                    );
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                //throw new InvalidOperationException($"Error confirming email for user with ID '{userId}':");
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                model.ShowInvalid = true;
            }
            else
            {
                //Login User
                await _signInManager.SignInAsync(user: user, isPersistent: false);
            }

            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public virtual async Task<IActionResult> Register(RegisterViewModel model)
        {
            RedirectToActionResult RedirectNextPage = RedirectToAction("Register", "Members");
            if (ModelState.IsValid)
            {
                var user = new BeachClubMember
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserEmail,
                    Email = model.UserEmail

                };
                var result = await _userManager.CreateAsync(user, model.UserPassword);
                if (result.Succeeded)
                {
                    //_logger.LogInformation("User created a new account with password.");
                    result = await _userManager.AddToRoleAsync(user, model.UserRole);
                    if (result.Succeeded)
                    {
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.Action(
                             action: "RegistrationConfirmation",
                             controller: "Members",
                            values: new { userId = user.Id, code = code },
                            protocol: Request.Scheme);

                        await _emailSender.SendEmailAsync(model.UserEmail, "Confirm your email",
                            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                        model.RegistrationConfirmationSent = true;
                    }
                    // await _signInManager.SignInAsync(user, isPersistent: false);
                    //return LocalRedirect(returnUrl);

                    //model.UserRole = "Member";
                    //UserRegistrationResult Result = _userRegistrationService.RegisterUser(model);

                    //if (Result.Success)
                    //{
                    //    await _signInManager.SignInAsync(Result.NewlyRegistredUser, isPersistent: false);

                    //    RedirectNextPage = RedirectToAction("Index", "DashBoard");
                    //}
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                // return RedirectNextPage;
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult MemberAppliactionWizard()
        {
            var model = _userViewModelFactory.PrepareRegistrationLoginModel();
            model.TermsAndConditions = false;
            return View(model);
        }

        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Profile()
        {
            return View();
        }
        #region Controller Internal methods
        private RedirectToActionResult RedirectToUserPortalByRole(string role)
        {
            RedirectToActionResult RedirectNextPage;
            switch (role.ToLower())
            {
                case "administrator":
                    RedirectNextPage = RedirectToAction("Home", "Administration", new { area = "Adminitration" });
                    break;
                case "agent":
                    RedirectNextPage = RedirectToAction("Home", "Agent");
                    break;
                case "individual":
                    RedirectNextPage = RedirectToAction("DashBoard", "Individual", new { area = "Individuals" });
                    break;
                case "company":
                    RedirectNextPage = RedirectToAction("Home", "Company");
                    break;
                default:
                    RedirectNextPage = RedirectToAction("Register", "User");
                    break;
            }
            return RedirectNextPage;
        }
        #endregion
    }
}