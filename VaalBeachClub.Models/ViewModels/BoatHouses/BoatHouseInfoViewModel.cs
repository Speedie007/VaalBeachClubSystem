using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Web.Data.Identity;

namespace VaalBeachClub.Models.ViewModels.BoatHouses
{
    public partial class BoatHouseInfoViewModel : BaseBeachClubEntityViewModel
    {

        public BoatHouseInfoViewModel()
        {
            BeachClubMembers = new List<BeachClubMember>();
        }
        public string BoatHouseNumber { get; set; }
        public int BoatHouseSize { get; set; }
        public decimal BoatHouseCost { get; set; }

        public IList<BeachClubMember> BeachClubMembers { get; set; }

        #region Nested Classes

        public partial class MemberBoatHouseRentalsViewModel : BaseBeachClubEntityViewModel
        {
            public MemberBoatHouseRentalsViewModel()
            {

            }

            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public Boolean HasBeenPaided { get; set; }
            public BeachClubMember Member { get; set; }
        }
        #endregion
    }
}
