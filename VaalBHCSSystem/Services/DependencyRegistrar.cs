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
using VaalBeachClub.Data.Interfaces;
using VaalBeachClub.Models.Common;
using VaalBeachClub.Services.Authentication;
using VaalBeachClub.Services.BoatHouses;
using VaalBeachClub.Services.CampSites;

using VaalBeachClub.Services.Interfaces.CampSites;
using VaalBeachClub.ViewFactory.BoatHouses;
using VaalBeachClub.ViewFactory.CampSites;
using VaalBeachClub.ViewFactory.Users;
using VaalBreachClub.Web.Data.Intefaces;

namespace VaalBeachClub.Web.Services
{
    public partial class DependencyRegistrar : IDependencyRegistrar
    {


        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, VaalBeachClubConfig config)
        {

            builder.RegisterType<EntityCRUDResponse>().As<IEntityCRUDResponse>().InstancePerLifetimeScope();
            //file provider
            builder.RegisterType<VaalBeachClubFileProvider>().As<IVaalBeachClubFileProvider>().InstancePerLifetimeScope();

            //web helper
            builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerLifetimeScope();


            //repositories
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();


            //services
            //builder.RegisterType<SubscriptionService>().As<ISubscriptionService>().InstancePerLifetimeScope();
            builder.RegisterType<BoatHouseService>().As<IBoatHouseService>().InstancePerLifetimeScope();
            builder.RegisterType<CampSiteService>().As<ICampSitesService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<UserRegistrationService>().As<IUserRegistrationService>().InstancePerLifetimeScope();
            

            //Factories
            builder.RegisterType<BoatHouseModelFactory>().As<IBoatHouseModelFactory>().InstancePerLifetimeScope();
            builder.RegisterType<CampSiteModelFactory>().As<ICampSiteModelFactory>().InstancePerLifetimeScope();
            builder.RegisterType<UserViewModelFactory>().As<IUserViewModelFactory>().InstancePerLifetimeScope();


            //Event publisher
            // builder.RegisterType<EventPublisher>().As<IEventPublisher>().SingleInstance();

            builder.RegisterType<DbInitializer>().As<IDbInitializer>().SingleInstance();
        }

        public int Order
        {
            get { return 0; }
        }
    }
}
