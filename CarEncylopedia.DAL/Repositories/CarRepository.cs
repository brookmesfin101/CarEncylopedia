using CarEncylopedia.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CarEncylopedia.DAL.Repositories
{
    public class CarRepository
    {
        List<List<string>> cars;

        public CarRepository()
        {
            //var path = Path.Combine(Environment.CurrentDirectory, @"Data\", "fullspecs.csv");
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("CarEncylopedia.Main\\", "CarEncylopedia.Data\\"), "fullspecs.csv");
            this.cars = ProcessCSV(path);
        }

        private List<List<string>> ProcessCSV (string path)
        {
            var raw = File.ReadAllLines(path).ToList();
            var rows = new List<string>()
            {
                raw[0], raw[1], raw[2], raw[4], raw[12], raw[39]
            };
            

            List<List<string>> processed = new List<List<string>>();
            Regex r = new Regex(@",(?=(?:[""]\$\d*[,]\d*[""]))");

            foreach(var c in rows)
            {
                string[] cols;

                if (c.StartsWith("MSRP"))
                {
                    cols = r.Split(c);
                } 
                else
                {
                    cols = c.Split(',');
                }
                
                processed.Add(cols.Take(7).ToList());
            }

            CreateCars(processed);

            return processed;
        }

        private List<Car> CreateCars(List<List<string>> processed)
        {
            var cars = new List<Car>();

            var names = processed[0];
            var msrp = processed[1];
            var mpgs = processed[2];
            var classes = processed[3];
            var weights = processed[4];
            var hpowers = processed[5];

            for (var i = 1; i < names.Count; i++)
            {
                int year;
                string make;
                string model;
                SplitName(names[i], out year, out make, out model);

                int cityMPG;
                int hwyMPG;
                SplitMPG(mpgs[i], out cityMPG, out hwyMPG);

                cars.Add(new Car()
                {
                    Make = make,
                    Model = model,
                    Year = year,                                       
                    Price = ParseMSRP(msrp[i]),
                    CityMPG = cityMPG,
                    HwyMPG = hwyMPG,
                    Class = classes[i],
                    Weight = int.Parse(weights[i]),
                    Horsepower = hpowers[i]
                });
            }

            return cars;
        }

        private void SplitName(string name, out int year, out string make, out string model)
        {
            Regex yearRegex = new Regex("\\d{4}");
            Regex makeRegex = new Regex("(?<=\\d{4}\\s)\\w*");
            Regex modelRegex = new Regex("(?<=\\d{4}\\s\\w*\\s)[:/A-Za-z\\s]*");

            year = int.Parse(yearRegex.Match(name).Value);
            make = makeRegex.Match(name).Value;
            model = modelRegex.Match(name).Value;
        }

        private void SplitMPG(string mpg, out int cityMPG, out int hwyMPG)
        {
            Regex cityMPGRegex = new Regex("\\d{2}(?=\\smpg City)");
            Regex hwyMPGRegex = new Regex("\\d{2}(?=\\smpg Hwy)");

            cityMPG = int.Parse(cityMPGRegex.Match(mpg).Value);
            hwyMPG = int.Parse(hwyMPGRegex.Match(mpg).Value);
        }

        private int ParseMSRP(string msrp)
        {
            msrp = msrp.Replace("\"", "");
            msrp = msrp.Replace(",", "");
            msrp = msrp.Replace("$", "");

            var MSRP = int.Parse(msrp);

            return MSRP;
        }

        public List<List<string>> GetCars()
        {
            return cars;
        }
    }
}
