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
            this.cars = ProcessCSV("C:\\Users\\brook.mesfin\\source\\repos\\CarEncylopedia\\CarEncylopedia.Data\\fullspecs.csv");
        }

        private List<List<string>> ProcessCSV (string path)
        {
            var raw = File.ReadAllLines(path).Take(2).ToList<string>();
            List<List<string>> processed = new List<List<string>>();            

            foreach(var c in raw)
            {
                string[] cols;

                if (c.StartsWith("MSRP"))
                {                    
                    cols = Regex.Split(c, ",(?=(?:[^']*'[^']*')*[^']*$)");
                } 
                else
                {
                    cols = c.Split(',');
                }
                
                processed.Add(cols.Take(7).ToList());
            }

            return processed;
        }

        public List<List<string>> GetCars()
        {
            return cars;
        }
    }
}
