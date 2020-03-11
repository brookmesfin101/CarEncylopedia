using System;
using System.Collections.Generic;
using System.Text;

namespace CarEncylopedia.DAL.Models
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Package { get; set; }
        public int? Price { get; set; }
        public int? Year { get; set; }
        public int? CityMPG { get; set; }
        public int? HwyMPG { get; set; }
        public string Class { get; set; }
        public int? Weight { get; set; }
        public string Horsepower { get; set; }        
    }
}
