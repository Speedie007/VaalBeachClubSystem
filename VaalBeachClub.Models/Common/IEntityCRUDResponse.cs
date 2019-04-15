using System;
using System.Collections.Generic;
using System.Text;

namespace VaalBeachClub.Models.Common
{
   public partial  interface IEntityCRUDResponse
    {
        int Returned_ID { get; set; }
        string Message { get; set; }
        Boolean Success { get; set; }
    }
}
