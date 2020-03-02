using AutoMapper;
using CarEncylopedia.DAL.Models;
using CarEncylopedia.DAL.Repositories;
using CarEncylopedia.Service.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarEncylopedia.Service
{
    public class HomeService
    {
        CarRepository carRepo;
        private readonly IMapper _mapper;

        public HomeService(IMapper mapper)
        {
            carRepo = new CarRepository();
            _mapper = mapper;
        }

        public List<CarDTO> GetCars()
        {
            var cars = carRepo.GetCars();
            var carDTOs = _mapper.Map<List<CarDTO>>(cars);

            return carDTOs;
        }
    }
}
