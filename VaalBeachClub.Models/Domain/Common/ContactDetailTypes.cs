using System;
using System.Collections.Generic;

namespace VaalBeachClub.Models.Domain.Common
{
    public partial class ContactDetailType: BaseEntity
    {
        public ContactDetailType()
        {
            ContactDetails = new HashSet<ContactDetail>();
        }

        public string ContactDetailTypeValue { get; set; }

        public virtual ICollection<ContactDetail> ContactDetails { get; set; }
    }
}