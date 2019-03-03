using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.ViewModels.BoatHouses;
using VaalBeachClub.Services.Interfaces.BoatHouses;

namespace VaalBeachClub.ViewFactory.BoatHouses
{
    public partial class BoatHouseModelFactory : IBoatHouseModelFactory
    {

        #region Fields
        private readonly IBoatHouseService _boatHouseService;
        #endregion

        #region Constuctor
        public BoatHouseModelFactory(IBoatHouseService boatHouseService)
        {
            this._boatHouseService = boatHouseService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare the boatHouse list model
        /// </summary>
        /// <returns>BoatHouse List Model</returns>
        public virtual BoatHouseInfoViewModel PrepareBoatHouseListModel()
        {
            var model = new BoatHouseInfoViewModel();
            var boatHouses = _boatHouseService.GetAllBoatHouses();

            foreach(var boatHouse in boatHouses)
            {
                model.BoatHouseNumber = boatHouse.BoatHouseNumber;
            }
            return model;
        }

       
        #endregion
    }
}
