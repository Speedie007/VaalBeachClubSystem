using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaalBeachClub.Models.Domain.Addresses;
using VaalBeachClub.Models.Domain.Intefaces;
using VaalBeachClub.Models.Domain.Members;
using VaalBeachClub.Models.ViewModels.ViewModelComponents;


namespace VaalBeachClub.Models.ViewModels.Members
{
    public partial class MemberInfoModel : BaseBeachClubEntityViewModel
    {

        public MemberInfoModel()
        {
            MemberContactDetails = new List<MemeberContactDetails>();
            MainMemberAfilliates = new List<AffiliatedMembersModel>();
            MemberAddresses = new List<MemberAddress>();
            MemeberBoatLockerRentals = new List<MemberBoatLockerRentalViewModel>();
        }

     
        public BeachClubMember Memeber { get; set; }

        public MemberProfilePicture ProfilePicture { get; set; }

        public ICollection<MemeberContactDetails> MemberContactDetails { get; set; }
        public ICollection<MemberAddress> MemberAddresses { get; set; }

        public ICollection<AffiliatedMembersModel> MainMemberAfilliates { get; set; }
        public ICollection<MemberBoatLockerRentalViewModel> MemeberBoatLockerRentals { get; set; }
        // public IList<M>
    }
    #region Nested Classes

    public partial class MemberAddress : BaseBeachClubEntityViewModel
    {
        public string City { get; set; }
        public string Suburb { get; set; }
        public string AreaCode { get; set; }
        public bool IsPrimaryAddress { get; set; }
        public AddressTypes AddressType { get; set; }
        public string CountryName { get; set; }
        public string ComplexName { get; set; }
        public string ComplexUnitNumber { get; set; }
        public string POBoxNumber { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
    }

    public partial class MemberProfilePicture : BaseBeachClubEntityViewModel
    {
        public byte[] ProfileImage { get; set; }
        public string ContentType { get; set; }
    }
    public partial class MemeberContactDetails : BaseBeachClubEntityViewModel
    {
        public string TypeDescription { get; set; }
        public string ContactValue { get; set; }
        public int ContactTypeID { get; set; }
    }

    public partial class MemberBoatLockerRentalViewModel : BaseBeachClubEntityViewModel
    {
        public string MemberFirstName { get; set; }
        public string LockerNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean hasBeenPaid { get; set; }


    }

    public partial class AffiliatedMembersModel : BaseBeachClubEntityViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AffiliatedMemberTypeID { get; set; }

    }

    #endregion
}
