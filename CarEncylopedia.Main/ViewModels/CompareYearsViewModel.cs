using CarEncylopedia.Service.DTOModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarEncylopedia.Main.ViewModels
{
    public class CompareYearsViewModel
    {
        [Display(Name = "Choose Car Make")]
        public List<string> Makes { get; set; }

        [Display(Name = "Choose Car Model")]
        public List<string> Models { get; set; }

        [Display(Name = "Choose Car Year")]
        public List<int> Years { get; set; }   
        
        public List<CarDTO> Cars { get; set; }
    }
}