using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VaalBeachClub.Common.Events;
using VaalBeachClub.Models.Domain.CampSites;
using VaalBeachClub.Services.Interfaces.CampSites;
using VaalBreachClub.Web.Data.Intefaces;

namespace VaalBeachClub.Services.CampSites
{
    public partial class CampSiteService : ICampSitesService
    {

        private readonly IRepository<CampSite> _campSiteRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly string _entityName;

        public CampSiteService(IRepository<CampSite> campSiteRepository, IEventPublisher eventPublisher)
        {
            this._campSiteRepository = campSiteRepository;
            this._eventPublisher = eventPublisher;
            this._entityName = typeof(CampSite).Name;
        }
        public void DeleteBoatHouse(CampSite boatHouse)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CampSite> GetAllBoatHouses()
        {
            return _campSiteRepository.Table;
        }

        public void InsertBoatHouse(CampSite BoatHouse)
        {
            throw new NotImplementedException();
        }

        public void UpdateBoatHouse(CampSite boatHouse)
        {
            throw new NotImplementedException();
        }
    }
}
