using AutoMapper;
using CarEncylopedia.Main.ViewModels;
using CarEncylopedia.Service;
using CarEncylopedia.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarEncylopedia.Main.Controllers
{
    public class MainController : Controller
    {
        IHomeService _homeService;

        public MainController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        // GET: Main
        public ActionResult Index()
        {            
            return View();            
        }

        public ActionResult DisplayCars()
        {
            var carData = _homeService.GetCars();

            var vm = new DisplayCarsViewModel();
            vm.Cars = carData.GroupBy(c => new { c.Make, c.Model })
                               .Select(d => d.First())
                               .ToList();

            return PartialView(vm);
        }

        public ActionResult CarMakesDropDownList()
        {
            var carData = _homeService.GetCars();

            var makes = carData.GroupBy(c => new { c.Make })
                               .Select(d => d.First().Make)
                               .ToList();

            return PartialView(makes);
        }

        public ActionResult CarPricesDropDownList()
        {
            var prices = new List<string>()
            {
                "10,000 - 20,000",
                "20,000 - 30,000",
                "30,000 - 40,000",
                "40,000 - 50,000",
                "50,000 - 60,000",
                "60,000 - 90,000",
                "100,000 - 200,000",
                "200,000 - 500,000",
                "500,000+"
            };

            return PartialView(prices);
        }

        [HttpPost]
        public ActionResult DisplayByMake(string carMake)
        {
            var _carMake = JsonConvert.DeserializeObject<string>(carMake);

            var carData = _homeService.GetCars();
            
            var cars = carData.GroupBy(c => new { c.Make, c.Model })
                                .Select(d => d.First())                                
                                .ToList();

            var vm = new DisplayCarsViewModel();
            var sortedByMake = cars.Where(c => c.Make == _carMake).ToList();
            vm.Cars = sortedByMake;

            return PartialView("DisplayCars", vm);
        }
    }
}