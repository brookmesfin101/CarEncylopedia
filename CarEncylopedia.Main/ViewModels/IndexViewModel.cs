﻿using CarEncylopedia.Service.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarEncylopedia.Main.ViewModels
{
    public class DisplayCarsViewModel
    {
        public List<CarDTO> Cars { get; set; }
    }
}