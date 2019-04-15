using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaalBeachClub.Models.Domain.BoatHouses;
using VaalBeachClub.Models.ViewModels.ViewModelComponents;
using VaalBeachClub.Web.Data.Identity;

namespace VaalBeachClub.Models.ViewModels.BoatHouses
{
    public partial class BoatHouseInfoViewModel : BaseBeachClubEntityViewModel
    {
        public BoatHouseInfoViewModel()
        {
            BoatHouseSizes = new List<SelectListItem>();
        }

        [Display(Name = "Number")]
        public string BoatHouseNumber { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Area => Length * Width;
        
        public decimal Cost { get; set; }
        [Display(Name = "Is Available")]
        public Boolean IsCurrentlyAvailable { get; set; }

        public int BoatHouseSizeID { get; set; }
        [Display(Name = "Boat House Size")]
        public List<SelectListItem> BoatHouseSizes { get; set; }

    }
}
