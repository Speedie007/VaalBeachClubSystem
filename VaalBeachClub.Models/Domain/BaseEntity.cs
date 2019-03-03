using System;
using System.Collections.Generic;
using System.Text;

namespace VaalBeachClub.Models.Domain
{
    public abstract partial class BaseEntity: IBaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int Id { get; set; }
    }
}
