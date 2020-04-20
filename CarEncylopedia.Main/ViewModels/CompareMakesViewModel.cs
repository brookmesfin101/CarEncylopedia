using CarEncylopedia.Service.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarEncylopedia.Main.ViewModels
{
    public class CompareMakesViewModel
    {
        public List<Tuple<string, double>> MakeAverages { get; set; }
    }
}