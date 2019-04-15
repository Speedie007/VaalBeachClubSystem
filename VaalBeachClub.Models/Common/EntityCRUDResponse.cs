using System;
using System.Collections.Generic;
using System.Text;

namespace VaalBeachClub.Models.Common
{
    public partial class EntityCRUDResponse : IEntityCRUDResponse
    {
        public int Returned_ID { get; set; }
        public string Message { get; set; }
        public Boolean Success { get; set; }
    }
}
