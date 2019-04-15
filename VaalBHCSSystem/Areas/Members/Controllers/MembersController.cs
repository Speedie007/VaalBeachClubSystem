using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VaalBeachClub.Models.ViewModels.Authentication;
using VaalBeachClub.Services.Authentication;
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
        //private readonly UserManager<IntegratorUser> _userManager;
        //private readonly RoleManager<IntegratorRole> _roleManager;
        private readonly SignInManager<BeachClubMember> _signInManager;
        #endregion


        #region Cstor
        public MembersController(
            IUserViewModelFactory userViewModelFactory,
            IUserRegistrationService userRegistrationService,
            SignInManager<BeachClubMember> signInManager
            )
        {
            this._userViewModelFactory = userViewModelFactory;
            this._userRegistrationService = userRegistrationService;
            this._signInManager = signInManager;
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

        [HttpPost]
        [AllowAnonymous]
        public virtual async Task<IActionResult> Register(RegisterViewModel model)
        {
            RedirectToActionResult RedirectNextPage = RedirectToAction("Register", "Members");
            if (ModelState.IsValid)
            {
                model.UserRole = "Member";
                UserRegistrationResult Result = _userRegistrationService.RegisterUser(model);

                if (Result.Success)
                {
                    await _signInManager.SignInAsync(Result.NewlyRegistredUser, isPersistent: false);

                    RedirectNextPage = RedirectToAction("Index", "DashBoard");
                }
            }
            return RedirectNextPage;
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