using CarEncylopedia.Main.ViewModels;
using CarEncylopedia.Service.DTOModels;
using CarEncylopedia.Service.Infrastructure.HelperClasses;
using CarEncylopedia.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text.RegularExpressions;
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
        public ActionResult DisplayByMake(string carMake, string sortBy, string sortOrder)
        {
            var _carMake = JsonConvert.DeserializeObject<string>(carMake);
            var _sortBy = JsonConvert.DeserializeObject<string>(sortBy);
            var _sortOrder = JsonConvert.DeserializeObject<string>(sortOrder);

            var carData = _homeService.GetCars();
            
            var cars = carData.GroupBy(c => new { c.Make, c.Model })
                                .Select(d => d.First())                                
                                .ToList();

            var vm = new DisplayCarsViewModel();
            var filteredByMake = cars.Where(c => c.Make == _carMake).ToList();

            List<CarDTO> sortedByModel = new List<CarDTO>();      
            
            if(_sortOrder == "ASC")
            {
                sortedByModel = filteredByMake.AsQueryable().SortBy(_sortBy, false).ToList();                
            }
            else
            {
                sortedByModel = filteredByMake.AsQueryable().SortBy(_sortBy, true).ToList();
            }                        

            vm.Cars = sortedByModel;

            return PartialView("DisplayCars", vm);
        }        

        [HttpPost]
        public ActionResult DisplayByPrice(string carPrice, string sortBy, string sortOrder)
        {
            var _carPrice = JsonConvert.DeserializeObject<string>(carPrice);
            var _sortBy = JsonConvert.DeserializeObject<string>(sortBy);
            var _sortOrder = JsonConvert.DeserializeObject<string>(sortOrder);
            var carData = _homeService.GetCars();

            var rgx = new Regex("(\\d*,\\d*)");
            var matches = rgx.Matches(_carPrice);
            List<CarDTO> sortedByPrice;

            if(matches.Count > 1)
            {
                var min = int.Parse(matches[0].Value.Replace(",", ""));
                var max = int.Parse(matches[1].Value.Replace(",", ""));

                sortedByPrice = carData.Where(c => c.Price >= min && c.Price <= max).ToList();
            } 
            else
            {
                var min = int.Parse(matches[0].Value.Replace(",", ""));

                sortedByPrice = carData.Where(c => c.Price >= min).ToList();
            }

            if (_sortOrder == "ASC")
            {
                sortedByPrice = sortedByPrice.AsQueryable().SortBy(_sortBy, false).ToList();
            }
            else
            {
                sortedByPrice = sortedByPrice.AsQueryable().SortBy(_sortBy, true).ToList();
            }

            var vm = new DisplayCarsViewModel();
            vm.Cars = sortedByPrice;

            return PartialView("DisplayCars", vm);
        }

        [HttpPost]
        public ActionResult CompareMakes(string compare)
        {
            var _compare = JsonConvert.DeserializeObject<string>(compare);

            var carData = _homeService.GetCars();
            var makes = carData.Select(c => c.Make).Distinct().ToList();

            var vm = new CompareMakesViewModel();
            List<Tuple<string, double>> makeAverages = new List<Tuple<string, double>>();

            if(_compare == "Price")
            {
                makeAverages = carData.GroupBy(c => c.Make)
                                    .Select(i => new Tuple<string, double>(i.Key, Math.Round(i.Average(x => x.Price), 2))).ToList();                
            } 
            else if(_compare == "City MPG")
            {
                makeAverages = carData.GroupBy(c => c.Make)
                                    .Select(i => new Tuple<string, double>(i.Key, Math.Round(i.Average(x => x.CityMPG), 2))).ToList();                
            }
            else if(_compare == "Hwy MPG")
            {
                makeAverages = carData.GroupBy(c => c.Make)
                                    .Select(i => new Tuple<string, double>(i.Key, Math.Round(i.Average(x => x.HwyMPG), 2))).ToList();                
            }                
            
            vm.MakeAverages = makeAverages;
            vm.CompareOn = _compare;

            return PartialView("CompareMakes", vm);
        }

        [HttpGet]
        public ActionResult ComparePackages()
        {
            var carData = _homeService.GetCars();
            var makes = carData.Select(c => c.Make).Distinct().ToList();

            var vm = new ComparePackagesViewModel
            {
                Makes = makes
            };

            return PartialView("ComparePackages", vm);
        }

        [HttpPost]
        public ActionResult ComparePackages(string make, string model)
        {
            var _model = JsonConvert.DeserializeObject<string>(model);
            var _make = JsonConvert.DeserializeObject<string>(make);

            var carData = _homeService.GetCars();

            var cars = carData.Where(c => c.Make == _make && c.Model == _model && c.Year == 2019).ToList();
            var packages = cars.Select(c => c.Package).ToList();

            var vm = new PackageComparisonViewModel
            {
                Cars = cars,
                Packages = packages
            };

            return PartialView("PackageComparison", vm);
        }

        [HttpPost]
        public ActionResult DisplayModelsDropDown(string make)
        {
            var _make = JsonConvert.DeserializeObject<string>(make);
            var carData = _homeService.GetCars();

            var models = carData.Where(c => c.Make == _make).Select(c => c.Model).Distinct().ToList();            

            return PartialView("ModelsDropDown", models);
        }

        [HttpGet]
        public ActionResult CompareYears()
        {
            var carData = _homeService.GetCars();
            var makes = carData.Select(c => c.Make).Distinct().ToList();
            var models = carData.Where(c => c.Make == "Acura").Select(m => m.Model).Distinct().ToList();
            var years = carData.Where(c => c.Make == "Acura").Select(m => m.Year).Distinct().ToList();

            var cars = carData.Where(c => c.Make == "Acura" && c.Model == "RDX").ToList();

            var vm = new CompareYearsViewModel
            {
                Makes = makes,
                Models = models,
                Years = years,
                Cars = cars
            };

            return PartialView("CompareYears", vm);
        }
    }
}