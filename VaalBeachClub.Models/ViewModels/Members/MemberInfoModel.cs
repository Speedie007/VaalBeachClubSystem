using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Addresses;
using VaalBeachClub.Models.Domain.Intefaces;
using VaalBeachClub.Models.Domain.Members;

namespace VaalBeachClub.Models.ViewModels.Members
{
    public partial class MemberInfoModel : BaseBeachClubEntityViewModel
    {

        public MemberInfoModel()
        {
            MainMemberAfilliates = new List<AffiliatedMembersModel>();
            MemberAddresses = new List<IAddress>();
        }

        public int BeachClubMemberID { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }


        public IList<IAddress> MemberAddresses { get; set; }
        public IList<AffiliatedMembersModel> MainMemberAfilliates { get; set; }
        public IList<MemberBoatLockerRentalViewModel> MemeberBoatLockerRentals { get; set; }
        // public IList<M>

        #region Nested Classes

        public partial class MemberBoatLockerRentalViewModel : BaseBeachClubEntityViewModel
        {
            public string MemberFirstName { get; set; }
            public string LockerNumber { get; set; }
            public  DateTime StartDate { get; set; }
            public  DateTime EndDate { get; set; }
            public Boolean hasBeenPaid { get; set; }

            
        }

        public partial class AffiliatedMembersModel : BaseBeachClubEntityViewModel
        {
            public int MainMemberID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FullName
            {
                get
                {
                    return $"{FirstName} {LastName}";
                }
            }
            public AffiliatedMemberType TypeOfAffiliation { get; set; }
        }


       
        #endregion

    }
}
