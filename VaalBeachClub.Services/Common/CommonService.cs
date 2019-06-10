using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VaalBeachClub.Models.Common.Enum;
using VaalBeachClub.Models.Domain.Common;
using VaalBeachClub.Models.Domain.Interfaces;
using VaalBeachClub.Models.Domain.Items;
using VaalBeachClub.Models.ViewModels.Assets;
using VaalBeachClub.Models.ViewModels.Common;
using VaalBreachClub.Web.Data.Intefaces;

namespace VaalBeachClub.Services.Common
{
    public interface ICommonService
    {

        List<Country> ListCountries();

        List<ContactDetailType> ListContactDetailTypes();

       

    }
    public class CommonService : ICommonService
    {
        #region Fields
        private readonly IRepository<Country> _countriesRepository;
        private readonly IRepository<ContactDetailType> _contactDetailTypesRepository;
        private readonly IRepository<ItemType> _itemTypeRepository;
        private readonly IRepository<ItemTypeProperty> _itemTypePropertyRepository;
        private readonly IRepository<ItemProperty> _itemPropertyRepository;
        private readonly IRepository<ItemTypeHierarchy> _itemTypeHierarchyRepository;
        #endregion

        #region Cstor
        public CommonService(
                IRepository<Country> countriesRepository,
                IRepository<ContactDetailType> contactDetailTypesRepository
                
            )
        {
            this._countriesRepository = countriesRepository;
            this._contactDetailTypesRepository = contactDetailTypesRepository;
           
        }
      



        public List<ContactDetailType> ListContactDetailTypes()
        {
            var query = _contactDetailTypesRepository.Table;

            return query.ToList();
        }
        #endregion

        public List<Country> ListCountries()
        {
            var query = _countriesRepository.Table;

            return query.ToList();
        }

       
    }
}
