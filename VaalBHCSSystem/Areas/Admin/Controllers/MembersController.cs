using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VaalBeachClub.Models.Domain.Addresses;
using VaalBeachClub.Models.Domain.Intefaces;
using VaalBeachClub.Services.Addresses;

namespace VaalBreachClub.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MembersController : Controller
    {
        private readonly IAddressService<Address> _addressService;

        public MembersController(IAddressService<Address> addressService)
        {
            this._addressService = addressService;
        }

        public IActionResult Index()
        {
            return View();
        }
      


    }
    

}