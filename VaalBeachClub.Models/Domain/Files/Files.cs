using System;
using System.Collections.Generic;
using VaalBeachClub.Models.Domain.Members;

namespace VaalBeachClub.Models.Domain.Files
{
    public partial class File: BaseEntity
    {
        public File()
        {
            MemberProfileImages = new HashSet<MemberProfileImage>();
        }

        
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<MemberProfileImage> MemberProfileImages { get; set; }
    }
}