using Autofac;
using AutoMapper;
using CarEncylopedia.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CarEncylopedia.Main.Infrastructure.AutoFac_Modules
{
    public class AutoMapperModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ServicesProfile>();

            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            }).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}