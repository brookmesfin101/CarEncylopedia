using CarEncylopedia.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarEncylopedia.Main.Controllers
{
    public class MainController : Controller
    {
        HomeService homeService;

        public MainController()
        {
            homeService = new HomeService();
        }

        // GET: Main
        public ActionResult Index()
        {
            var carData = homeService.GetCars();
                        
            return View(carData);
        }
    }
}