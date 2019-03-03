using System;
using System.Collections.Generic;
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

        public string CampSiteNumber { get; set; }



        #region Nested Classes
        public virtual ICollection<CampSiteBookingViewModel> CampSiteBookings { get; set; }

        #endregion
    }
}
