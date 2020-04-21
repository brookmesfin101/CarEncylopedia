using CarEncylopedia.Service.DTOModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarEncylopedia.Main.ViewModels
{
    public enum CompareCar
    {
        [Display(Name = "Price")]
        Price,
        [Display(Name = "City MPG")]
        CityMPG,
        [Display(Name = "Hwy MPG")]
        HwyMPG,
        [Display(Name = "Weight")]
        Weight,
        [Display(Name = "Horsepower")]
        Horsepower
    }
    public class CompareMakesViewModel
    {
        public List<Tuple<string, double>> MakeAverages { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public CompareCar CompareOn { get; set; }
    }
}