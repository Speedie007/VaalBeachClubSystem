using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaalBeachClub.Models.Domain.CampSites;

namespace VaalBeachClub.Services.Interfaces.CampSites
{
    public interface ICampSitesService
    {
        void DeleteCampSite(CampSite Entity);
        Task<List<CampSite>> ListCampSites();
        Task<CampSite> GetCampSite(int? CampSiteID);
        void InsertCampSite(CampSite Entity);
        void UpdateCampSite(CampSite Entity);
    }
}
