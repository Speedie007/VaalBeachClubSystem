using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Common;
using VaalBeachClub.Common.Interfaces;
using VaalBeachClub.Models.Domain.BoatHouses;

using VaalBeachClub.Services.Interfaces.BoatHouses;
using VaalBreachClub.Web.Data.Intefaces;
using System.Linq;
using VaalBeachClub.Common.Events;

namespace VaalBeachClub.Services.BoatHouses
{
    public partial class BoatHouseService : IBoatHouseService
    {

        private readonly IRepository<BoatHouse> _boatHouseRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly string _entityName;

        public BoatHouseService(
            IRepository<BoatHouse> boatHouseRepository)
        {
            this._boatHouseRepository = boatHouseRepository;
            // this._eventPublisher = eventPublisher;
            this._entityName = typeof(BoatHouse).Name;
        }

        public virtual IQueryable<BoatHouse> GetAllBoatHouses()
        {
            //var query = _boatHouseRepository.Table.ToList();

            //var boatHouses = new PagedList<BoatHouse>(query, pageIndex, pageSize, getOnlyTotalCount);
            return _boatHouseRepository.Table;

        }

        /// <summary>
        /// Insert a customer
        /// </summary>
        /// <param name="customer">Customer</param>
        public virtual void InsertBoatHouse(BoatHouse boatHouse)
        {
            if (boatHouse == null)
                throw new ArgumentNullException(nameof(boatHouse));

            _boatHouseRepository.Insert(boatHouse);

            //event notification
            _eventPublisher.EntityInserted(boatHouse);
        }

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
            _eventPublisher.EntityUpdated(boatHouse);
        }

        public virtual void DeleteBoatHouse(BoatHouse boatHouse)
        {
            if (boatHouse == null)
                throw new ArgumentNullException(nameof(boatHouse));

            _boatHouseRepository.Delete(boatHouse);

            //event notification that BoatHouse Item is deleted.
            _eventPublisher.EntityDeleted(boatHouse);
        }


    }
}
