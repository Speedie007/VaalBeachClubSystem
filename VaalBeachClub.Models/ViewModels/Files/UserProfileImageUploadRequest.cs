using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.ViewModels.ViewModelComponents;

namespace VaalBeachClub.Models.ViewModels.Files
{
    public partial class UserProfileImageUploadRequest : BaseBeachClubViewModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string ImageData { get; set; }
    }
}
