using AutoMapper;
using CarEncylopedia.Main.ViewModels;
using CarEncylopedia.Service;
using CarEncylopedia.Service.Interfaces;
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

        [HttpPost]
        public ActionResult DisplayByMake(FormCollection form)
        {
            var carData = _homeService.GetCars();
            
            var cars = carData.GroupBy(c => new { c.Make, c.Model })
                                .Select(d => d.First())                                
                                .ToList();

            var vm = new DisplayCarsViewModel();
            var sortedByMake = cars.Where(c => c.Make == form["CarMakes"]).ToList();
            vm.Cars = sortedByMake;

            return View("DisplayCars", vm);
        }
    }
}