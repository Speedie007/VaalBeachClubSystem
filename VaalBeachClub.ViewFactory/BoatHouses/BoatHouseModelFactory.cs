using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VaalBeachClub.Models.Domain.BoatHouses;
using VaalBeachClub.Models.ViewModels.BoatHouses;
using VaalBeachClub.Services.BoatHouses;

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

        public BoatHouseInfoViewModel PrepareAddBoatHouseModel()
        {
            BoatHouseInfoViewModel model = new BoatHouseInfoViewModel();

            model.BoatHouseSizeID = 0;

            foreach (var item in _boatHouseService.ListBoatHouseSizes())
            {
                model.BoatHouseSizes.Add(new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = item.Dimensions
                });
            }

            return model;
        }

        public BoatHouseInfoViewModel PrepareEditBoatHouseModel(int BoatHouseID)
        {
            BoatHouseInfoViewModel model = new BoatHouseInfoViewModel();

            var BH = _boatHouseService.GetBoatHouse(BoatHouseID);

            model.BoatHouseNumber = BH.BoatHouseNumber;
            model.BoatHouseSizeID = BH.BoatHouseSizeID;

            foreach (var item in _boatHouseService.ListBoatHouseSizes())
            {
                Boolean Isselected = false;
                if (model.BoatHouseSizeID == item.Id)
                {
                    Isselected = true;
                }
                model.BoatHouseSizes.Add(new SelectListItem()
                {
                    Selected = Isselected,
                    Value = item.Id.ToString(),
                    Text = item.Dimensions
                });
            }

            return model;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare the boatHouse list model
        /// </summary>
        /// <returns>BoatHouse List Model</returns>
        public virtual List<BoatHouseInfoViewModel> PrepareBoatHouseListModel()
        {
            var model = new List<BoatHouseInfoViewModel>();
            var ListOfAllBoatHouses = _boatHouseService.ListBoatHouses();

            foreach (BoatHouse item in ListOfAllBoatHouses)
            {
                BoatHouseInfoViewModel VM = new BoatHouseInfoViewModel()
                {
                    Id = item.Id,
                    BoatHouseNumber = item.BoatHouseNumber,
                    Cost = item.BoatHouseSize.Cost,
                    Height = Convert.ToDouble(item.BoatHouseSize.Hieght),
                    Length = Convert.ToDouble(item.BoatHouseSize.Length),
                    Width = Convert.ToDouble(item.BoatHouseSize.Width),

                };

                model.Add(VM);
            }

            //TODO: Must still determine if boathouse ia avaiable for  rental.
            return model;
        }

        public virtual List<BoatHouseSizeViewModel> PrepareBostHouseSizeViewModel()
        {
            var model = new List<BoatHouseSizeViewModel>();

            var ListOfAllBoatHouseSizes = _boatHouseService.ListBoatHouseSizes();

            foreach (var item in ListOfAllBoatHouseSizes)
            {
                model.Add(new BoatHouseSizeViewModel()
                {
                    Id = item.Id,
                    Description = item.Description,
                    aCost = String.Format("R{0:0.00}", item.Cost),
                    aHieght = item.Hieght.ToString(),
                    aLength = item.Length.ToString(),
                    aWidth = item.Width.ToString()
                });


            }

            //TODO: Must still determine if boathouse ia avaiable for  rental.
            return model;
        }


        public virtual BoatHouseSizeViewModel PrepareEditBoatHouseSizeViewModel(int BoatHouseSizeID)
        {


            var _BoatHouseSize = _boatHouseService.GetBoatHouseSize(BoatHouseSizeID);

            var model = new BoatHouseSizeViewModel()
            {
                Description = _BoatHouseSize.Description,
                aHieght = _BoatHouseSize.Hieght.ToString(),
                aCost = _BoatHouseSize.Cost.ToString(),
                aLength = _BoatHouseSize.Length.ToString(),
                aWidth = _BoatHouseSize.Width.ToString(),
                Id = _BoatHouseSize.Id

            };

            //TODO: Must still determine if boathouse ia avaiable for  rental.
            return model;
        }
        #endregion
    }
}
