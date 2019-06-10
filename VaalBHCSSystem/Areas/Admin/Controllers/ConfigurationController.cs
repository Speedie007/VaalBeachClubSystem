using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VaalBreachClub.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ConfigurationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AssestList()
        {
            return View();
        }

        public IActionResult SystemUsers()
        {
            return View();
        }

        public IActionResult EmailSettings()
        {
            return View();
        }
    }
}