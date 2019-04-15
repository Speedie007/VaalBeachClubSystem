using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VaalBeachClub.Common.Interfaces;
using VaalBeachClub.Models.Common;
using VaalBeachClub.Models.Domain.BoatHouses;
using VaalBeachClub.Models.ViewModels.BoatHouses;

namespace VaalBeachClub.Services.BoatHouses
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
        IList<BoatHouse> ListBoatHouses();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        BoatHouse GetBoatHouse(int BoatHouseID);
        IList<BoatHouseSize> ListBoatHouseSizes();
        BoatHouseSize GetBoatHouseSize(int BoatHouseSizeID);
        #region Insert Methods
        /// <summary>
        /// Insert a BoatHouse
        /// </summary>
        /// <param name="BoatHouse">BoatHouse</param>
        void AddBoatHouse(BoatHouse BoatHouse);

        /// <summary>
        /// Adds a BoatHouse Size
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        IEntityCRUDResponse AddBoatHouseSize(BoatHouseSize Entity);
        #endregion
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

        void UpdateBoatHouseSize(BoatHouseSize Entity);


    }
}
