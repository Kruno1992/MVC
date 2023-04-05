using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Theatre.DAL;
using Theatre.Repository;
using Theatre.Repository.Common;
using Theatre.Service;
using Theatre.Service.Common;

namespace Theatre.MVC.App_Start
{
    public class DIConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            //Register MVC CONTROLLERS
            builder.RegisterType<PersonnelService>().As<IPersonnelService>();
            builder.RegisterType<PersonnelRepository>().As<IPersonnelRepository>();
            builder.RegisterType<TheatreContext>().AsSelf();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}