using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_Core_2_2.Controllers.Controllers
{
    public class MetricsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}