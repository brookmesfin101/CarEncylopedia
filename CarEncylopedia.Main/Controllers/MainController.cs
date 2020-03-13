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
            var carData = _homeService.GetCars();

            var vm = new IndexViewModel();
            vm.Cars = carData.GroupBy(c => new { c.Make, c.Model })
                               .Select(d => d.First())
                               .ToList();

            return View(vm);            
        }

        public ActionResult CarMakesDropDownList()
        {
            var carData = _homeService.GetCars();

            var makes = carData.GroupBy(c => new { c.Make })
                               .Select(d => d.First().Make)
                               .ToList();

            return View(makes);
        }
    }
}