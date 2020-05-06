using System;
using System.Collections.Generic;

namespace CarEncylopedia.Main.ViewModels
{
    public class CompareMakesViewModel
    {
        public List<Tuple<string, double>> MakeAverages { get; set; }
       
        public string CompareOn { get; set; }

        public List<string> ChartSort 
        {
            get 
            {
                List<string> chartSort = new List<string>
                {
                    "A-Z",
                    "Z-A",
                    "Low-High",
                    "High-Low"
                };

                return chartSort;
            }        
        }

        public List<string> ChartType
        {
            get 
            {
                List<string> chartType = new List<string>
                {
                    "Bar",
                    "Horizontal Bar"
                };

                return chartType;
            }
        }
    }
}