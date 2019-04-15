using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaalBeachClub.Common.Events;
using VaalBeachClub.Models.Domain.CampSites;
using VaalBeachClub.Services.Interfaces.CampSites;
using VaalBreachClub.Web.Data.Intefaces;

namespace VaalBeachClub.Services.CampSites
{
    public partial class CampSiteService : ICampSitesService
    {

        private readonly IRepository<CampSite> _campSiteRepository;
       // private readonly IEventPublisher _eventPublisher;
        private readonly string _entityName;

        public CampSiteService(
            IRepository<CampSite> campSiteRepository
            //, IEventPublisher eventPublisher
            )
        {
            this._campSiteRepository = campSiteRepository;
            //this._eventPublisher = eventPublisher;
            this._entityName = typeof(CampSite).Name;
        }


        public void DeleteCampSite(CampSite Entity)
        {
            _campSiteRepository.Delete(Entity);
        }

        
        public async Task<List<CampSite>> ListCampSites()
        {
            return await _campSiteRepository.Table.ToListAsync();
        }
        
        public async Task<CampSite> GetCampSite(int? CampSiteID)
        {
            return  await _campSiteRepository.Table.Where(x=>x.Id == CampSiteID).FirstOrDefaultAsync<CampSite>();
        }

        public void InsertCampSite(CampSite Entity)
        {
            _campSiteRepository.Insert(Entity);
        }

        public void UpdateCampSite(CampSite Entity)
        {
            _campSiteRepository.Update(Entity);
        }
    }
}
