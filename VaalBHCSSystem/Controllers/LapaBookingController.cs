﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VaalBreachClub.Web.Controllers
{
    public class LapaBookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}