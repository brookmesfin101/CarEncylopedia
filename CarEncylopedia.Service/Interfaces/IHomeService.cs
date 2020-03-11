using CarEncylopedia.Service.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarEncylopedia.Service.Interfaces
{
    public interface IHomeService
    {
        List<CarDTO> GetCars();
    }
}
