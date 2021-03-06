﻿using System;
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
using VaalBeachClub.Models.Domain.Interfaces;
using VaalBeachClub.Services.Addresses;
using VaalBeachClub.Services.Assests;
using VaalBeachClub.Services.Authentication;
using VaalBeachClub.Services.BoatHouses;
using VaalBeachClub.Services.CampSites;
using VaalBeachClub.Services.Common;
using VaalBeachClub.Services.EmailSending;
using VaalBeachClub.Services.Interfaces.CampSites;
using VaalBeachClub.ViewFactory.BoatHouses;
using VaalBeachClub.ViewFactory.CampSites;
using VaalBeachClub.ViewFactory.Common;
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
            builder.RegisterType<CommonService>().As<ICommonService>().InstancePerLifetimeScope();
            builder.RegisterType<CustomEmailSender>().As<ICustomEmailSender>().InstancePerLifetimeScope();
            builder.RegisterType<AssetService>().As<IAssetService>().InstancePerLifetimeScope();
            builder.RegisterType<AssetService>().As<IAssetService>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(AddressService<>)).As(typeof(IAddressService<>)).InstancePerLifetimeScope();
            

            //Factories
            builder.RegisterType<BoatHouseModelFactory>().As<IBoatHouseModelFactory>().InstancePerLifetimeScope();
            builder.RegisterType<CampSiteModelFactory>().As<ICampSiteModelFactory>().InstancePerLifetimeScope();
            builder.RegisterType<UserViewModelFactory>().As<IUserViewModelFactory>().InstancePerLifetimeScope();
            builder.RegisterType<AssetViewFactory>().As<IAssetViewFactory>().InstancePerLifetimeScope();

            


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
