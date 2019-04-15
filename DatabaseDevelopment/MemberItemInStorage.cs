using System;
using System.Collections.Generic;

namespace DatabaseDevelopment
{
    public partial class MemberItemInStorage
    {
        public int MemberItemInStorageId { get; set; }
        public string Item { get; set; }
        public int BoatHouseRentalId { get; set; }
        public int MemberItemId { get; set; }

        public virtual MemberItems MemberItem { get; set; }
    }
}