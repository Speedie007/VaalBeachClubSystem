using System;
using System.Collections.Generic;
using System.Text;

namespace VaalBeachClub.Models.Domain.Files
{
    public partial class FileBlob : BaseEntity
    {
        public byte[] BlobData { get; set; }
        public virtual BeachClubFile BeachClubFile { get; set; }
    }
}
