using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Common.Configuration;

namespace VaalBeachClub.Common.Interfaces
{
    public interface IDependencyRegistrar
    {
        ///// <summary>
        ///// Register services and interfaces
        ///// </summary>
        ///// <param name="builder">Container builder</param>
        ///// <param name="typeFinder">Type finder</param>
        ///// <param name="config">Config</param>
        void Register(ContainerBuilder builder, ITypeFinder typeFinder, VaalBeachClubConfig config);

        ///// <summary>
        ///// Gets order of this dependency registrar implementation
        ///// </summary>
        int Order { get; }
    }
}
