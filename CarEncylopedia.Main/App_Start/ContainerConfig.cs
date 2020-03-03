using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using CarEncylopedia.Service;
using CarEncylopedia.Service.Infrastructure;
using CarEncylopedia.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarEncylopedia.Main
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ServicesProfile>();
            });

            builder.RegisterType<HomeService>()
                   .As<IHomeService>();
            builder.RegisterType<Mapper>()
                   .As<IMapper>().WithParameter(new TypedParameter (typeof(MapperConfiguration), config));
            builder.RegisterType<Mapper>()
                   .As<IMapper>().WithParameter(new TypedParameter(typeof(MapperConfiguration), config));

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    } 
}