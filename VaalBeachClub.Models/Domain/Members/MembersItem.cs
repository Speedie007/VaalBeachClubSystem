using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Items;
using VaalBeachClub.Models.Domain.Rentals;
using VaalBeachClub.Web.Data.Identity;

namespace VaalBeachClub.Models.Domain.Members
{
    public partial class MemberItem : BaseEntity
    {

        public MemberItem()
        {
            MemberItemsInStorage = new List<MemberItemInStorage>();
        }


        public int BeachClubMemberID { get; set; }
        public int ItemID { get; set; }
        public Boolean IsOnSite { get; set; }

        public virtual BeachClubMember BeachClubMember { get; set; }
        public virtual ItemType Item { get; set; }
        public virtual ICollection<MemberItemInStorage> MemberItemsInStorage { get; set; }


    }
    //public partial class Boat : MemberItem
    //{
    //    public virtual string BoatModel { get; set; }
    //    public string BoatMake { get; set; }
    //    public string BoatRegistration { get; set; }
    //}

    //public partial class Trailer : MemberItem
    //{

    //    public virtual string TrailerRegistration { get; set; }
    //}
    //public partial class JetSki : MemberItem
    //{

    //    public virtual string JetSkiModel { get; set; }
    //    public virtual string JetSkiMake { get; set; }
    //    public virtual string JetSkiRegistration { get; set; }
    //}

    //public partial class MotorHome : MemberItem
    //{

    //    public virtual string JetSkiModel { get; set; }
    //    public virtual string JetSkiMake { get; set; }
    //    public virtual string JetSkiRegistration { get; set; }
    //}
    //public enum MemberItemType
    //{
    //    Boat, Trailer, JetSki, Caravans, MotorHouses
    //}
}
