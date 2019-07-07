using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Addresses;

namespace VaalBeachClub.Models.ViewModels.Members
{
    public static class MemberInfoModelExtension
    {
        public static MemberInfoModel AddAddressToCollection(this MemberInfoModel aMemberInfoModel, List<Address> AddressesToAdd)
        {

            foreach (var item in AddressesToAdd)
            {

                if (item is StreetAddress)
                {
                    StreetAddress aStreetAddress = item as StreetAddress;

                    aMemberInfoModel.MemberAddresses.Add(new MemberAddress()
                    {
                        Id = item.Id,
                        AreaCode = item.AreaCode,
                        City = item.City,
                        Suburb = item.Suburb,
                        CountryName = item.aCountry.CountryName,
                        IsPrimaryAddress = item.IsPrimaryAddress,
                        //Custom Properties
                        StreetNumber = aStreetAddress.StreetNumber,
                        StreetName = aStreetAddress.StreetName,

                        AddressType = AddressTypes.StreetAddress

                    });
                }

                if (item is ComplexAddress)
                {
                    ComplexAddress aComplextAddress = item as ComplexAddress;

                    aMemberInfoModel.MemberAddresses.Add(new MemberAddress()
                    {
                        Id = item.Id,
                        AreaCode = item.AreaCode,
                        City = item.City,
                        Suburb = item.Suburb,
                        CountryName = item.aCountry.CountryName,
                        IsPrimaryAddress = item.IsPrimaryAddress,
                        //Custom Properties
                        ComplexUnitNumber = aComplextAddress.ComplexUnitNumber,
                        ComplexName = aComplextAddress.ComplexName,
                        AddressType = AddressTypes.ComplexAddress

                    });
                }

                if (item is POBoxAddress)
                {
                    POBoxAddress aPOBoxAddress = item as POBoxAddress;

                    aMemberInfoModel.MemberAddresses.Add(new MemberAddress()
                    {
                        Id = item.Id,
                        AreaCode = item.AreaCode,
                        City = item.City,
                        Suburb = item.Suburb,
                        CountryName = item.aCountry.CountryName,
                        IsPrimaryAddress = item.IsPrimaryAddress,
                        //Custom Properties
                         POBoxNumber = aPOBoxAddress.POBoxNumber,

                        AddressType = AddressTypes.POBoxAddress

                    });
                }

            };

            return aMemberInfoModel;
        }

        public static MemberInfoModel AddAddressToCollection(this MemberInfoModel aMemberInfoModel, Address AddressesToAdd)
        {

           

                if (AddressesToAdd is StreetAddress)
                {
                    StreetAddress aStreetAddress = AddressesToAdd as StreetAddress;

                    aMemberInfoModel.MemberAddresses.Add(new MemberAddress()
                    {
                        Id = AddressesToAdd.Id,
                        AreaCode = AddressesToAdd.AreaCode,
                        City = AddressesToAdd.City,
                        Suburb = AddressesToAdd.Suburb,
                        CountryName = AddressesToAdd.aCountry.CountryName,
                        IsPrimaryAddress = AddressesToAdd.IsPrimaryAddress,
                        //Custom Properties
                        StreetNumber = aStreetAddress.StreetNumber,
                        StreetName = aStreetAddress.StreetName,

                        AddressType = AddressTypes.StreetAddress

                    });
                }

                if (AddressesToAdd is ComplexAddress)
                {
                    ComplexAddress aComplextAddress = AddressesToAdd as ComplexAddress;

                    aMemberInfoModel.MemberAddresses.Add(new MemberAddress()
                    {
                        Id = AddressesToAdd.Id,
                        AreaCode = AddressesToAdd.AreaCode,
                        City = AddressesToAdd.City,
                        Suburb = AddressesToAdd.Suburb,
                        CountryName = AddressesToAdd.aCountry.CountryName,
                        IsPrimaryAddress = AddressesToAdd.IsPrimaryAddress,
                        //Custom Properties
                        ComplexUnitNumber = aComplextAddress.ComplexUnitNumber,
                        ComplexName = aComplextAddress.ComplexName,
                        AddressType = AddressTypes.ComplexAddress

                    });
                }

                if (AddressesToAdd is POBoxAddress)
                {
                    POBoxAddress aPOBoxAddress = AddressesToAdd as POBoxAddress;

                    aMemberInfoModel.MemberAddresses.Add(new MemberAddress()
                    {
                        Id = AddressesToAdd.Id,
                        AreaCode = AddressesToAdd.AreaCode,
                        City = AddressesToAdd.City,
                        Suburb = AddressesToAdd.Suburb,
                        CountryName = AddressesToAdd.aCountry.CountryName,
                        IsPrimaryAddress = AddressesToAdd.IsPrimaryAddress,
                        //Custom Properties
                        POBoxNumber = aPOBoxAddress.POBoxNumber,

                        AddressType = AddressTypes.POBoxAddress

                    });
                }

            

            return aMemberInfoModel;
        }
    }
}
