using Autofac;
using Autofac.Integration.WebApi;
using EFPersonnel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Theatre.DAL;
using Theatre.Repository;
using Theatre.Repository.Common;
using Theatre.Service;
using Theatre.Service.Common;
using WebGrease;

namespace Theatre.WebApi.App_Start
{
    public class DIConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            //Register WEB API CONTROLLERS
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register individual components
            builder.RegisterType<PersonnelService>().As<IPersonnelService>();
            builder.RegisterType<EFPersonnelRepository>().As<IPersonnelRepository>();
            builder.RegisterType<TheatreContext>().AsSelf();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}