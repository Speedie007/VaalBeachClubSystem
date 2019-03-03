using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using VaalBeachClub.Common;
using VaalBeachClub.Common.Configuration;
using VaalBeachClub.Common.Events;
using VaalBeachClub.Common.Interfaces;
using VaalBeachClub.Data;
using VaalBeachClub.Services.BoatHouses;
using VaalBeachClub.Services.CampSites;
using VaalBeachClub.Services.Interfaces.BoatHouses;
using VaalBeachClub.Services.Interfaces.CampSites;
using VaalBeachClub.ViewFactory.BoatHouses;
using VaalBreachClub.Web.Data.Intefaces;

namespace VaalBeachClub.Web.Services
{
    public partial class DependencyRegistrar : IDependencyRegistrar
    {


        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, VaalBeachClubConfig config)
        {
            //file provider
            builder.RegisterType<VaalBeachClubFileProvider>().As<IVaalBeachClubFileProvider>().InstancePerLifetimeScope();

            //web helper
            builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerLifetimeScope();


            //repositories
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();


            //services
            builder.RegisterType<BoatHouseService>().As<IBoatHouseService>().InstancePerLifetimeScope();
            builder.RegisterType<CampSiteService>().As<ICampSitesService>().InstancePerLifetimeScope();
            

            //Factories
            builder.RegisterType<BoatHouseModelFactory>().As<IBoatHouseModelFactory>().InstancePerLifetimeScope();


            //Event publisher
            builder.RegisterType<EventPublisher>().As<IEventPublisher>().SingleInstance();
        }

        public int Order
        {
            get { return 0; }
        }
    }
}
