using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Common;
using VaalBeachClub.Common.Interfaces;
using VaalBeachClub.Models.Domain.BoatHouses;


using VaalBreachClub.Web.Data.Intefaces;
using System.Linq;
using VaalBeachClub.Common.Events;
using VaalBeachClub.Models.ViewModels.BoatHouses;
using Microsoft.EntityFrameworkCore;
using VaalBeachClub.Models.Common;
using VaalBeachClub.Models.Domain.Interfaces;

namespace VaalBeachClub.Services.BoatHouses
{
    public partial class BoatHouseService : IBoatHouseService
    {

        #region Fields
        private readonly IRepository<BoatHouse> _boatHouseRepository;
        private readonly IRepository<BoatHouseSize> _boatHouseSizeRepository;
        //private readonly IEventPublisher _eventPublisher;
        private IEntityCRUDResponse _entityCRUDResponse;
        private readonly string _entityName;

        #endregion

        #region Cstor
        public BoatHouseService(
            IRepository<BoatHouse> boatHouseRepository,
            IRepository<BoatHouseSize> boatHouseSizeRepository,
            IEntityCRUDResponse entityCRUDResponse
            //IEventPublisher eventPublisher
            )
        {
            this._boatHouseRepository = boatHouseRepository;
            this._boatHouseSizeRepository = boatHouseSizeRepository;
            //this._eventPublisher = eventPublisher;
            this._entityCRUDResponse = entityCRUDResponse;
            this._entityName = typeof(BoatHouse).Name;
        }
        #endregion

        public virtual IList<BoatHouse> ListBoatHouses()
        {
            var query = from AllBoatHouseInfo in _boatHouseRepository.Table
                        .Include(x => x.BoatHouseSize)
                        .Include(x => x.BoatHouseRentals)
                        select AllBoatHouseInfo;

            //var boatHouses = new PagedList<BoatHouse>(query, pageIndex, pageSize, getOnlyTotalCount);
            return query.ToList();

        }

        #region Insert Methods
        /// <summary>
        /// Insert a customer
        /// </summary>
        /// <param name="customer">Customer</param>
        public virtual void AddBoatHouse(BoatHouse boatHouse)
        {
            if (boatHouse == null)
                throw new ArgumentNullException(nameof(boatHouse));

            _boatHouseRepository.Insert(boatHouse);
            
            //event notification
            //_eventPublisher.EntityInserted(boatHouse);
        }

        /// <summary>
        /// Adds a BoatHouse Size
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns>Successfull or Failure Response</returns>
        public IEntityCRUDResponse AddBoatHouseSize(BoatHouseSize Entity)
        {
            try
            {
                _boatHouseSizeRepository.Insert(Entity);
                _entityCRUDResponse.Success = true;
                _entityCRUDResponse.Message = "Boat House Size Successfully Added";
                _entityCRUDResponse.Returned_ID = Entity.Id;
            }
            catch (Exception e)
            {
                _entityCRUDResponse.Success = false;
                _entityCRUDResponse.Message = "Boat House Size Was Not Successfully Added - " + e.Message;
                _entityCRUDResponse.Returned_ID = 0;
            }

            return _entityCRUDResponse;
        }
        #endregion
        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer">Customer</param>
        public virtual void UpdateBoatHouse(BoatHouse boatHouse)
        {
            if (boatHouse == null)
                throw new ArgumentNullException(nameof(boatHouse));

            _boatHouseRepository.Update(boatHouse);

            //event notification
            //_eventPublisher.EntityUpdated(boatHouse);
        }

        public virtual void DeleteBoatHouse(BoatHouse boatHouse)
        {
            if (boatHouse == null)
                throw new ArgumentNullException(nameof(boatHouse));

            _boatHouseRepository.Delete(boatHouse);

            //event notification that BoatHouse Item is deleted.
            //_eventPublisher.EntityDeleted(boatHouse);
        }

        public IList<BoatHouseSize> ListBoatHouseSizes()
        {
            var query = from a in _boatHouseSizeRepository.Table

                        select a;



            return query.ToList();
        }

        public BoatHouseSize GetBoatHouseSize(int BoatHouseSizeID)
        {
            var query = _boatHouseSizeRepository.Table.Where(x => x.Id == BoatHouseSizeID);

            return query.FirstOrDefault();
        }

        public void UpdateBoatHouseSize(BoatHouseSize Entity)
        {
            _boatHouseSizeRepository.Update(Entity);
        }

        public BoatHouse GetBoatHouse(int BoatHouseID)
        {
            var query = _boatHouseRepository.Table;

            return query.FirstOrDefault();
        }
    }
}
