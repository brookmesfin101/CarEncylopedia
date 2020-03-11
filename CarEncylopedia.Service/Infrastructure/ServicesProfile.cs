using CarEncylopedia.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarEncylopedia.Service.DTOModels;

namespace CarEncylopedia.Service.Infrastructure
{
    public class ServicesProfile : Profile
    {
        public ServicesProfile()
        {
            CreateMap<Car, CarDTO>();
        }
    }
}
