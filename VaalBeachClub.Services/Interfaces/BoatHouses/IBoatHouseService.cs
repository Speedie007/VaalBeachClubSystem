using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VaalBeachClub.Common.Interfaces;
using VaalBeachClub.Models.Domain.BoatHouses;

namespace VaalBeachClub.Services.Interfaces.BoatHouses
{
    public interface IBoatHouseService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="getOnlyTotalCount"></param>
        /// <returns></returns>
        //IPagedList<BoatHouse> GetAllBoatHouses(int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false);
        IQueryable<BoatHouse> GetAllBoatHouses();


        /// <summary>
        /// Insert a BoatHouse
        /// </summary>
        /// <param name="BoatHouse">BoatHouse</param>
        void InsertBoatHouse(BoatHouse BoatHouse);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boatHouse"></param>
        void UpdateBoatHouse(BoatHouse boatHouse);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boatHouse"></param>
        void DeleteBoatHouse(BoatHouse boatHouse);


    }
}
