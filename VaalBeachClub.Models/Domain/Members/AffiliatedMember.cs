using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Web.Data.Identity;

namespace VaalBeachClub.Models.Domain.Members
{
    public class AffiliatedMember : BaseEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int BeachClubMemberID { get; set; }
        public virtual AffiliatedMemberType MemberAffiliation { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public virtual BeachClubMember Member { get; set; }
    }

    public enum AffiliatedMemberType
    {
        Wife, Husband, Son, Daughter
    }
}
