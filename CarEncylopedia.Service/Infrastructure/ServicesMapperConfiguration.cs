using AutoMapper;
using CarEncylopedia.DAL.Models;
using CarEncylopedia.Service.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarEncylopedia.Service.Infrastructure
{
    public class ServicesMapperConfiguration
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Car, CarDTO>();
            });

            return config;
        }
    }
}
