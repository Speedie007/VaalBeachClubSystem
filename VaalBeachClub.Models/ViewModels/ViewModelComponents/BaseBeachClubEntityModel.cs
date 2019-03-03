using System;
using System.Collections.Generic;
using System.Text;

namespace VaalBeachClub.Models.ViewModels.ViewModelComponents
{
    public partial class BaseBeachClubEntityViewModel : BaseBeachClubViewModel
    {
        /// <summary>
        /// Gets or sets model identifier
        /// </summary>
        public virtual int Id { get; set; }
    }
}
