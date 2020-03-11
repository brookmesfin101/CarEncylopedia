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
        IMapper _mapper;

        public MainController(IHomeService homeService, IMapper mapper)
        {
            _homeService = homeService;
            _mapper = mapper;
        }

        // GET: Main
        public ActionResult Index()
        {
            var carData = _homeService.GetCars();

            var vm = new IndexViewModel();
            vm.Cars = carData;

            return View(vm);            
        }
    }
}