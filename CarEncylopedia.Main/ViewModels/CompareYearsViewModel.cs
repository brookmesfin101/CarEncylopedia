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
        public string Make { get; set; }

        [Display(Name = "Choose Car Model")]
        public List<string> Models { get; set; }  
    }
}