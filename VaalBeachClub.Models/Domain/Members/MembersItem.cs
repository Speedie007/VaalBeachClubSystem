using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Items;
using VaalBeachClub.Models.Domain.Rentals;


namespace VaalBeachClub.Models.Domain.Members
{
    public partial class MemberItem : BaseEntity
    {

        public MemberItem()
        {
            MemberItemsInStorage = new List<MemberItemInStorage>();
            MemberAssetProperties = new HashSet<MemberItemProperty>();

        }


        public int MemberItemParentID { get; set; }
        public int BeachClubMemberID { get; set; }
        public int ItemID { get; set; }
        public Boolean IsOnSite { get; set; }


        public virtual BeachClubMember BeachClubMember { get; set; }
        public virtual ItemType Item { get; set; }
        public virtual ICollection<MemberItemInStorage> MemberItemsInStorage { get; set; }
        public virtual ICollection<MemberItemProperty> MemberAssetProperties { get; set; }

    }
}
