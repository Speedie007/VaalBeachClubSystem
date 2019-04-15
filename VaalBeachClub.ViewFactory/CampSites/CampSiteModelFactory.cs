using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VaalBeachClub.Models.ViewModels.CampStites;

using VaalBeachClub.Services.Interfaces.CampSites;

namespace VaalBeachClub.ViewFactory.CampSites
{
    public partial class CampSiteModelFactory : ICampSiteModelFactory
    {
        private readonly ICampSitesService _campSiteService;

        #region Cstr
        public CampSiteModelFactory(
            ICampSitesService campSitesService
            )
        {
            this._campSiteService = campSitesService;
        }
        #endregion


        public async Task<List<CampSiteViewModel>> PrepareCampSiteListViewModel()
        {
            var model = new List<CampSiteViewModel>();
            var CampSiteList = await _campSiteService.ListCampSites();

            foreach (var item in CampSiteList)
            {
                model.Add(new CampSiteViewModel()
                {
                    Id = item.Id,
                    HasElectricity = item.hasElectricity,
                    CampSiteNumber = item.CampSiteNumber
                });
            }
            return model;
        }

        public async Task<CampSiteViewModel> PrepareCampSiteViewModel(int? CampSiteID)
        {

            var CampSite = await _campSiteService.GetCampSite(CampSiteID);

            var model = new CampSiteViewModel()
            {
                Id = CampSite.Id,
                HasElectricity = CampSite.hasElectricity,
                CampSiteNumber = CampSite.CampSiteNumber
            };
            return model;
        }

        public ICollection<CampSiteBookingViewModel> PrepareMemeberCampSiteBookingListModel()
        {
            throw new NotImplementedException();
        }
    }
}
