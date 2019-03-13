using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.ViewModels.CampStites;

namespace VaalBeachClub.ViewFactory.CampSites
{
    public partial class CampSiteModelFactory : ICampSiteModelFactory
    {
      // private readonly 


        public CampSiteViewModel PrepareBoatHouseListModel()
        {
            var model = new CampSiteViewModel();


            return model;
        }

        public CampSiteViewModel PrepareCampSiteViewModel()
        {
            throw new NotImplementedException();
        }

        public ICollection<CampSiteBookingViewModel> PrepareMemeberCampSiteBookingListModel()
        {
            throw new NotImplementedException();
        }
    }
}
