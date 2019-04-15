using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.ViewModels.BoatHouses;

namespace VaalBeachClub.ViewFactory.BoatHouses
{
    public partial interface IBoatHouseModelFactory
    {

        /// <summary>
        /// Prepare the boathouse list model
        /// </summary>
        /// <returns>BoatHouse List Model used in the views</returns>
        List<BoatHouseInfoViewModel> PrepareBoatHouseListModel();
        BoatHouseInfoViewModel PrepareAddBoatHouseModel();
        BoatHouseInfoViewModel PrepareEditBoatHouseModel(int BoatHouseID);
        List<BoatHouseSizeViewModel> PrepareBostHouseSizeViewModel();
        BoatHouseSizeViewModel PrepareEditBoatHouseSizeViewModel(int BoatHouseSizeID);
    }
}
