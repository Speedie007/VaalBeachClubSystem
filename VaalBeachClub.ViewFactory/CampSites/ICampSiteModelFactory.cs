using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.ViewModels.CampStites;

namespace VaalBeachClub.ViewFactory.CampSites
{
    public interface ICampSiteModelFactory
    {

        /// <summary>
        /// Prepare the boathouse list model
        /// </summary>
        /// <returns>BoatHouse List Model used in the views</returns>
        CampSiteViewModel PrepareCampSiteViewModel();

        ICollection<CampSiteBookingViewModel> PrepareMemeberCampSiteBookingListModel();

    }
}
