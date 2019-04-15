using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using VaalBeachClub.Models.ViewModels.ViewModelComponents;

namespace VaalBeachClub.Models.ViewModels.CampStites
{
    public partial class CampSiteViewModel : BaseBeachClubEntityViewModel
    {

        public CampSiteViewModel()
        {
            CampSiteBookings = new List<CampSiteBookingViewModel>();
        }
        [Display(Name = "Site Number")]
        public string CampSiteNumber { get; set; }
        [Display(Name = "Has Electricy")]
        public bool HasElectricity { get; set; }


        #region Nested Classes
        public virtual ICollection<CampSiteBookingViewModel> CampSiteBookings { get; set; }

        #endregion
    }
}
