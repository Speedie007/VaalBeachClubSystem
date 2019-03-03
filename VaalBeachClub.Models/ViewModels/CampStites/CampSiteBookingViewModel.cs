using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.ViewModels.ViewModelComponents;

namespace VaalBeachClub.Models.ViewModels.CampStites
{
    public partial class CampSiteBookingViewModel : BaseBeachClubEntityViewModel
    {
        public CampSiteBookingViewModel()
        {

        }

        public string MemberFirstName { get; set; }
        public string MemberLastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        #region Nested Classes


        #endregion

    }
}
