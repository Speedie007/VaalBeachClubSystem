using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VaalBreachClub.Web.Controllers
{
    public class MemberRegistrationController : Controller
    {
        [HttpGet]
        public IActionResult MemeberRegistration()
        {
            return View();
        }
    }
}