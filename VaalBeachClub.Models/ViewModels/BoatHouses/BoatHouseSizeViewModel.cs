using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaalBeachClub.Models.ViewModels.ViewModelComponents;

namespace VaalBeachClub.Models.ViewModels.BoatHouses
{
    public partial class BoatHouseSizeViewModel : BaseBeachClubEntityViewModel
    {
        public string Description { get; set; }
        [Display(Name="Cost")]
        public string aCost { get; set; }
        [Display(Name = "Height")]
        public string aHieght { get; set; }
        [Display(Name = "Length")]
        public string aLength { get; set; }
        [Display(Name = "Width")]
        public string aWidth { get; set; }
        public string Dimensions => $"{Description}-{aWidth}Mx{aLength}Mx{aHieght}H";
    }
}
