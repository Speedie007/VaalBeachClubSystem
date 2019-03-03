using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VaalBeachClub.Models.Domain.CampSites;

namespace VaalBeachClub.Services.Interfaces.CampSites
{
    public interface ICampSitesService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="getOnlyTotalCount"></param>
        /// <returns></returns>
        //IPagedList<BoatHouse> GetAllBoatHouses(int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false);
        IQueryable<CampSite> GetAllBoatHouses();


        /// <summary>
        /// Insert a BoatHouse
        /// </summary>
        /// <param name="BoatHouse">BoatHouse</param>
        void InsertBoatHouse(CampSite BoatHouse);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boatHouse"></param>
        void UpdateBoatHouse(CampSite boatHouse);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boatHouse"></param>
        void DeleteBoatHouse(CampSite boatHouse);
    }
}
