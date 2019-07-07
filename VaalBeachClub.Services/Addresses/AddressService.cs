using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VaalBeachClub.Models.Domain;
using VaalBeachClub.Models.Domain.Addresses;
using VaalBeachClub.Models.Domain.Interfaces;
using VaalBeachClub.Services.Authentication;

namespace VaalBeachClub.Services.Addresses
{
    public interface IAddressService<TEntity> where TEntity : Address
    {
        #region Insert Section
        void AddAddress(TEntity Entity);
        #endregion

        #region Update Section
        void UpdateAddress(TEntity Entity);

        #endregion

        #region Delete Section
        void RemoveAddress(TEntity Entity);
        #endregion

        #region List Addresses
        TEntity GetAddress(int AddressID);

        List<TEntity> ListAddressesByMember(int MemberID);

        List<TEntity> ListAllAddresses();

        //POBoxAddress GetPOBoxAddress(int Addresss);
        #endregion
    }
    public partial class AddressService<TEntity> : IAddressService<TEntity> where TEntity : Address
    {
        #region Fields
        private readonly IRepository<TEntity> _addressRepository;
        private readonly IUserService _userService;
        #endregion
        #region Cstor

        public AddressService(IRepository<TEntity> addressRepository,
            IUserService userService)
        {
            this._addressRepository = addressRepository;
            this._userService = userService;
        }

        public void AddAddress(TEntity Entity)
        {
            _addressRepository.Insert(Entity);
        }

        public TEntity GetAddress(int AddressID)
        {
            return _addressRepository.Table
                .Include(x => x.aCountry)
                .Where(x => x.Id == AddressID)
                .FirstOrDefault();
        }

        public List<TEntity> ListAddressesByMember(int MemberID)
        {
            var ListOfAddresses =
                _addressRepository.Table
                .Include(x=>x.aCountry)
                .Where(x => x.BeachClubMemberID == MemberID).ToList();

            return ListOfAddresses;
        }

        public List<TEntity> ListAllAddresses()
        {
            return _addressRepository.Table
                .Include(x => x.aCountry)
                .ToList();
        }

        public void RemoveAddress(TEntity Entity)
        {
            _addressRepository.Delete(Entity);
        }

        public void UpdateAddress(TEntity Entity)
        {
            _addressRepository.Update(Entity);
        }


        #endregion
    }
}
