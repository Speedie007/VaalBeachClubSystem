﻿using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Common;
using VaalBeachClub.Models.Domain.Intefaces;
using VaalBeachClub.Models.Domain.Members;

namespace VaalBeachClub.Models.Domain.Addresses
{
    public abstract partial class Address : BaseEntity, IAddress
    {
        public virtual string City { get; set; }
        public virtual string Suburb { get; set; }

        public virtual string AreaCode { get; set; }
        public virtual bool IsPrimaryAddress { get; set; }
        public virtual int BeachClubMemberID { get; set; }

        public int CountryID { get; set; }

        public virtual BeachClubMember BeachClubMember { get; set; }
        public virtual Country aCountry { get; set; }
    }

    public partial class POBoxAddress : Address, IAddress
    {
        public virtual string POBoxNumber { get; set; }
    }

    public partial class StreetAddress : Address, IAddress
    {
        public virtual string StreetNumber { get; set; }
        public virtual string StreetName { get; set; }
    }

    public partial class ComplexAddress : Address, IAddress
    {
        public virtual string ComplexName { get; set; }
        public virtual string ComplexUnitNumber { get; set; }
    }

    public enum AddressTypes
    {
        StreetAddress = 1, ComplexAddress = 2, POBoxAddress = 3
    }
}
