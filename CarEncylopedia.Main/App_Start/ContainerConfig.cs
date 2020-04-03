
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using CarEncylopedia.Main.Infrastructure.AutoFac_Modules;
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

            builder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerDependency();

            builder.RegisterType<HomeService>()
                   .As<IHomeService>();

            builder.RegisterModule<AutoMapperModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    } 
}