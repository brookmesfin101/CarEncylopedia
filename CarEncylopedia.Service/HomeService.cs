using CarEncylopedia.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarEncylopedia.Service
{
    public class HomeService
    {
        CarRepository carRepo;

        public HomeService()
        {
            carRepo = new CarRepository();
        }

        public List<List<string>> GetCars()
        {
            return carRepo.GetCars();
        }
    }
}
