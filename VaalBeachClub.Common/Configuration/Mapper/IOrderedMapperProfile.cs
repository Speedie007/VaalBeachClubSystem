using System;
using System.Collections.Generic;
using System.Text;

namespace VaalBeachClub.Common.Configuration.Mapper
{
    public interface IOrderedMapperProfile
    {
        /// <summary>
        /// Gets order of this configuration implementation
        /// </summary>
        int Order { get; }
    }
}
