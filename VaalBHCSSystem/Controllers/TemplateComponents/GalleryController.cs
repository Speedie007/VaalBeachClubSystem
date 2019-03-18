using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_Core_2_2.Controllers.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult BasicGallery()
        {
            return View();
        }

        public IActionResult BootstrapCarusela()
        {
            return View();
        }

        public IActionResult SlickCarusela()
        {
            return View();
        }
    }
}