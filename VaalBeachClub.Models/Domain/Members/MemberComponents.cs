using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaalBeachClub.Models;
using VaalBeachClub.Models.Domain;
using VaalBeachClub.Models.Domain.Addresses;
using VaalBeachClub.Models.Domain.Bookings;
using VaalBeachClub.Models.Domain.Common;
using VaalBeachClub.Models.Domain.Members;
using VaalBeachClub.Models.Domain.Rentals;

namespace VaalBeachClub.Web.Data.Identity
{

    public partial class BeachClubMember : IdentityUser<int>, IBaseEntity
    {
        public BeachClubMember() : base()
        {
            this.Init();
        }


        protected virtual void Init()
        {
            Addresses = new List<Address>();
            BoatHouseRentals = new List<BoatHouseRental>();
            AffiliatedMembers = new List<AffiliatedMember>();
            CampSiteBookings = new List<CampSiteBooking>();
            MemberItems = new List<MemberItem>();
            MemberRegistrations = new HashSet<MemberRegistration>();
            ContactDetails = new HashSet<ContactDetail>();
            MemberProfileImages = new HashSet<MemberProfileImage>();
        }

        public BeachClubMember(string UserName) : base(UserName) { this.Init(); }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }

        public virtual ICollection<BeachClubMemberClaim> Claims { get; set; }
        public virtual ICollection<BeachClubMemberLogin> Logins { get; set; }
        public virtual ICollection<BeachClubMemberToken> Tokens { get; set; }
        public virtual ICollection<BeachClubMemberRole> UserRoles { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<BoatHouseRental> BoatHouseRentals { get; set; }
        public virtual ICollection<AffiliatedMember> AffiliatedMembers { get; set; }
        public virtual ICollection<CampSiteBooking> CampSiteBookings { get; set; }
        public virtual ICollection<MemberItem> MemberItems { get; set; }

        public virtual ICollection<MemberRegistration> MemberRegistrations { get; set; }

        public virtual ICollection<ContactDetail> ContactDetails { get; set; }

        public virtual ICollection<MemberProfileImage> MemberProfileImages { get; set; }

    }

    public class BeachClubRole : IdentityRole<int>
    {
        public BeachClubRole() : base() { }
        public BeachClubRole(string roleName) : base(roleName) { }

        public virtual ICollection<BeachClubMemberRole> UserRoles { get; set; }
        public virtual ICollection<BeachClubRoleClaim> RoleClaims { get; set; }
    }

    public class BeachClubMemberRole : IdentityUserRole<int>
    {
        public BeachClubMemberRole() : base() { }
        public virtual BeachClubMember Member { get; set; }
        public virtual BeachClubRole Role { get; set; }
    }

    public class BeachClubMemberClaim : IdentityUserClaim<int>
    {
        public BeachClubMemberClaim() : base() { }
        public virtual BeachClubMember Member { get; set; }
    }

    public class BeachClubMemberLogin : IdentityUserLogin<int>
    {
        public BeachClubMemberLogin() : base() { }
        public virtual BeachClubMember Member { get; set; }
    }

    public class BeachClubRoleClaim : IdentityRoleClaim<int>
    {

        public BeachClubRoleClaim() : base() { }
        public virtual BeachClubRole Role { get; set; }
    }

    public class BeachClubMemberToken : IdentityUserToken<int>
    {
        public BeachClubMemberToken() : base() { }
        public virtual BeachClubMember Member { get; set; }
    }

}
