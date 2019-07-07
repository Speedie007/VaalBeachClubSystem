using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VaalBeachClub.Models.Domain.Members;

namespace VaalBeachClub.Models.Domain.Files
{
    public partial class BeachClubFile: BaseEntity
    {
        public BeachClubFile()
        {
            //MemberProfileImages = new HashSet<MemberProfileImage>();
        }


        [Required]
        [StringLength(100)]
        public string ContentType { get; set; }
        [Required]
        [StringLength(200)]
        public string FileName { get; set; }
        [Required]
        [StringLength(25)]
        public string FileExtension { get; set; }

        public Int64 FileSize { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }


        public string FileFullName => $"{FileName}.{FileExtension}";

        public virtual FileBlob FileBlob { get; set; }

        public virtual MemberProfileImage MemberProfileImage { get; set; }
    }
}