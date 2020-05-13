using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarEncylopedia.Main.ViewModels
{
    public class ComparePackagesViewModel
    {        
        public List<string> Makes { get; set; }

        [Display(Name = "Sort Packages By")]
        public List<string> SortPackagesBy
        {
            get
            {
                return new List<string>
                {
                    "Price",
                    "CityMPG",
                    "HwyMPG",
                    "Horsepower",
                    "Weight"
                };
            }
        }
    }
}